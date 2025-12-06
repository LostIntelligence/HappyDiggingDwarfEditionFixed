using HarmonyLib;
using Klei.AI;
using System.Collections;
using System.Collections.Generic;
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
                // Spawn PopFX normally
                var popFx = PopFXManager.Instance.SpawnFX(
                    PopFXManager.Instance.sprite_Resource,
                    $"{ratio * 100f:F2} %",
                    component.transform,
                    Config.Cfg.TextEffectDuration,
                    false
                );
                if (popFx != null)
                {
                    // Run modifications *after PopFX finishes its own initialization*
                    PopFxModifier.Apply(popFx, effectColor);
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
            bool enable_dlc3 = Game.IsDlcActiveForCurrentSave("DLC3_ID");
            if (!enable_dlc3 || resume.GetIdentity.model == GameTags.Minions.Models.Standard)
            {
                if (resume.HasMasteredSkill(((Resource)Db.Get().Skills.Mining1).Id)) skill++;
                if (resume.HasMasteredSkill(((Resource)Db.Get().Skills.Mining2).Id)) skill++;
                if (resume.HasMasteredSkill(((Resource)Db.Get().Skills.Mining3).Id)) skill++;
                if (resume.HasMasteredSkill(((Resource)Db.Get().Skills.Mining4).Id)) skill++;
            }
            else if (enable_dlc3 && resume.GetIdentity.model == GameTags.Minions.Models.Bionic)
            {
                Ownables assignables = resume.GetIdentity.GetSoleOwner();
                AssignableSlot bionicUpgradeSlot = Db.Get().AssignableSlots.BionicUpgrade;
                HashSet<Tag> BionicUpgrade = new HashSet<Tag>();
                bool flag1 = false; // Ensure that only calculated once
                bool flag2 = false; // Ensure that only calculated once
                foreach (AssignableSlotInstance slot in assignables.GetSlots(bionicUpgradeSlot))
                {
                    bool showInUI = slot.slot.showInUI;
                    if (showInUI)
                    {

                        bool flag = slot.IsAssigned();
                        if (flag)
                        {
                            Tag assignedName = slot.assignable.GetComponent<KSelectable>().PrefabID();
                            if (assignedName != null && assignedName == BionicUpgradeComponentConfig.Booster_Dig1)
                            {
                                flag1 = true;
                            }
                            if (assignedName != null && assignedName == BionicUpgradeComponentConfig.Booster_Dig2)
                            {
                                flag2 = true;
                            }
                        }
                    }
                }

                if (flag1) skill++;
                if (flag2) skill = skill + 3;

            }

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
                    ratio = Config.Cfg.SuperDuperhardDiggingSkill + stat / Config.Cfg.SuperDuperhardDiggingStat;
                    break;
                case 4:
                    ratio = Config.Cfg.HazmatDiggingSkill + stat / Config.Cfg.HazmatDiggingStat;
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
