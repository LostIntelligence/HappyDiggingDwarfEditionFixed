using HarmonyLib;
using Klei.AI;
using TMPro;
using UnityEngine;

namespace HappyDiggingDwarfEditionFixed
{
    [HarmonyPatch(typeof(WorldDamage), "OnDigComplete")]
    public class Class3
    {
        public static bool Prefix(int cell, ref float mass)
        {
            StandardWorker w = null;
            foreach (var keyValuePair in Helper.DiggedCell)
            {
                if (keyValuePair.Value == cell)
                {
                    w = keyValuePair.Key;
                    break;
                }
            }
            if (w != null)
            {
                mass = Class3.CalculateMass(w, mass, Config.Cfg.ShowRatio);
            }
            else
            {
                mass = mass * 2f * Config.Cfg.NonDuplicantMiningEfficiency;
                Helper.OtherDigNumber++;
                Helper.OtherMass += mass / 2f;
            }
            return true;
        }

        private static float CalculateMass(StandardWorker w, float mass, bool ShowRatio = false)
        {
            if (w == null)
            {
                Debug.LogError("StandardWorker is null.");
                return mass;
            }

            var component = w.GetComponent<MinionResume>();
            if (component == null)
            {
                Debug.Log("Resume = null.");
                return mass;
            }

            var totalValue = ModifiersExtensions.GetAttributes((KMonoBehaviour)w)
                                .Get(((Resource)((ModifierSet)Db.Get()).Attributes.Digging).Id)
                                .GetTotalValue();

            bool hasDiggingAptitude;
            var ratio = Class3.ComputeRatio(Class3.ComputeSkill(component, out hasDiggingAptitude), totalValue, hasDiggingAptitude);

            if (ShowRatio)
            {
                var effectColor = Config.Cfg.TextEffectColor;
                if (Config.Cfg.CanUseGradient)
                {
                    var ratioPercent = Mathf.Clamp(ratio * 100f, 50f, 150f);
                    if (ratioPercent > 100f)
                    {
                        effectColor = Color32.Lerp(Config.Cfg.Color100Eff, Config.Cfg.Color150Eff, (ratioPercent - 100f) / 50f);
                    }
                    else if (ratioPercent < 75f)
                    {
                        effectColor = Color32.Lerp(Config.Cfg.Color50Eff, Config.Cfg.Color75Eff, (ratioPercent - 50f) / 25f);
                    }
                    else
                    {
                        effectColor = Color32.Lerp(Config.Cfg.Color75Eff, Config.Cfg.Color100Eff, (ratioPercent - 75f) / 25f);
                    }
                }

                var popFx = PopFXManager.Instance.SpawnFX(PopFXManager.Instance.sprite_Resource, $"{ratio * 100f:F2} %", component.transform, Config.Cfg.TextEffectDuration, false);
                if (popFx != null)
                {
                    popFx.TextDisplay.color = effectColor;
                    ((TMP_Text)popFx.TextDisplay).fontSize = 29f;
                    KMonoBehaviourExtensions.SetAlpha(popFx.IconDisplay, 0.0f);
                    Traverse.Create(popFx).Field("Speed").SetValue(Config.Cfg.TextEffectSpeed);
                    Traverse.Create(popFx).Field("offset").SetValue(new Vector3(0.0f, 2.5f));
                }
            }

            var modifiedMass = mass * ratio * Config.Cfg.GeneralMassMultiplier;
            Helper.MassTotal += modifiedMass;
            Helper.DigNumber++;
            Helper.DuplEff += ratio;

            var gameObject = w.gameObject;
            if (gameObject != null)
            {
                Data data;
                if (Helper.Info.TryGetValue(gameObject, out data))
                {
                    data.DiggNumber++;
                    data.MassTotal += modifiedMass;
                }
                else
                {
                    data = new Data { DiggNumber = 1, MassTotal = modifiedMass };
                    Helper.Info.Add(gameObject, data);
                }
            }

            return 2f * modifiedMass;
        }

        public static int ComputeSkill(MinionResume resume, out bool hasDiggingAptitude)
        {
            int skill = 0;
            if (resume.HasMasteredSkill(((Resource)Db.Get().Skills.Mining1).Id)) skill++;
            if (resume.HasMasteredSkill(((Resource)Db.Get().Skills.Mining2).Id)) skill++;
            if (resume.HasMasteredSkill(((Resource)Db.Get().Skills.Mining3).Id)) skill++;
            hasDiggingAptitude = Helper.MinionHasDigAptitude(resume);
            return skill;
        }

        public static float ComputeRatio(int skill, float stat, bool hasDiggingAptitude)
        {
            float ratio;
            switch (skill)
            {
                case 1:
                    ratio = Config.Cfg.HardDiggingSkill + stat / Config.Cfg.HardDiggingStat;
                    break;
                case 2:
                    ratio = Config.Cfg.SuperHardDiggingSkill + stat / Config.Cfg.SuperHardDiggingStat;
                    break;
                case 3:
                    ratio = Config.Cfg.ImprovedDiggingSkill + stat / Config.Cfg.ImprovedDiggingStat;
                    break;
                default:
                    ratio = Config.Cfg.DumbDiggerSkill + stat / Config.Cfg.DumbDiggerStat;
                    break;
            }

            if (hasDiggingAptitude)
            {
                ratio += Config.Cfg.BonusDiggingAptitude;
            }

            if (ratio > 1.0f && !Config.Cfg.CanEfficiencyGoesOver100)
            {
                ratio = 1.0f;
            }

            return Mathf.Clamp(ratio, 0.1f, float.MaxValue);
        }
    }
}
