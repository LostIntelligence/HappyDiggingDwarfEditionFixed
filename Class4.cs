using HarmonyLib;
using Klei.AI;
using UnityEngine;

namespace HappyDiggingDwarfEditionFixed
{
    [HarmonyPatch(typeof(Attribute), "GetTooltip")]
    public class Class4
    {
        public static void Postfix(
          Attribute __instance,
          AttributeInstance instance,
          ref string __result)
        {
            GameObject gameObject = ((ModifierInstance<Attribute>)instance).gameObject;
            if (gameObject == null || instance.Id != ((Resource)((ModifierSet)Db.Get()).Attributes.Digging).Id)
                return;
            MinionResume component = gameObject.GetComponent<MinionResume>();
            float totalValue = instance.GetTotalValue();
            bool HasDiggingAp;
            int skill = Class3.ComputeSkill(component, out HasDiggingAp);
            float ratio = Class3.ComputeRatio(skill, totalValue, HasDiggingAp);
            __result += string.Format("\n\nDigging efficiency: {0:F2}%", (object)(ratio * 100f));
            if (Config.Cfg.FullDecsriptionInToolTip)
            {
                float num1 = 0.0f;
                float num2 = 0.0f;
                switch (skill)
                {
                    case 0:
                        __result += string.Format("\n  No digging skills: {0:F2} %", (object)(Config.Cfg.DumbDiggerSkill * 100f));
                        num1 = Config.Cfg.DumbDiggerSkill;
                        num2 = Config.Cfg.DumbDiggerStat;
                        break;
                    case 1:
                        __result += string.Format("\n  'Hard digging' skills: {0:F2} %", (object)(Config.Cfg.HardDiggingSkill * 100f));
                        num1 = Config.Cfg.HardDiggingSkill;
                        num2 = Config.Cfg.HardDiggingStat;
                        break;
                    case 2:
                        __result += string.Format("\n  'Super hard digging' skills: {0:F2} %", (object)(Config.Cfg.SuperHardDiggingSkill * 100f));
                        num1 = Config.Cfg.SuperHardDiggingSkill;
                        num2 = Config.Cfg.SuperHardDiggingStat;
                        break;
                    case 3:
                        __result += string.Format("\n  'Improved digging' skills: {0:F2} %", (object)(Config.Cfg.SuperDuperhardDiggingSkill * 100f));
                        num1 = Config.Cfg.SuperDuperhardDiggingSkill;
                        num2 = Config.Cfg.SuperDuperhardDiggingStat;
                        break;
                    case 4:
                        __result += string.Format("\n  'Improved digging' skills: {0:F2} %", (object)(Config.Cfg.HazmatDiggingSkill * 100f));
                        num1 = Config.Cfg.HazmatDiggingSkill;
                        num2 = Config.Cfg.HazmatDiggingStat;
                        break;
                }
                if (HasDiggingAp)
                {
                    num1 += Config.Cfg.BonusDiggingAptitude;
                    __result += string.Format("\n  Has digging aptitude: {0:F2} % ({1:F2} %)", (object)(Config.Cfg.BonusDiggingAptitude * 100f), (object)(num1 * 100f));
                }
                __result += string.Format("\n  Bonus per Digging stat: {0:F2} % * {1} = {2:F2} % (total: {3:F2} %)", (object)(float)(1.0 / (double)num2 * 100.0), (object)totalValue, (object)(float)((double)totalValue / (double)num2 * 100.0), (object)(float)(((double)num1 + (double)totalValue / (double)num2) * 100.0));
            }
            if (!Config.Cfg.FullInfo)
                return;
            Data data;
            Helper.Info.TryGetValue(gameObject, out data);
            data = data ?? Helper.Empty;
            __result += string.Format("\nDigged tiles: {0} Mass: {1}", (object)data.DiggNumber, (object)GameUtil.GetFormattedMass(data.MassTotal, (GameUtil.TimeSlice)0, (GameUtil.MetricMassFormat)0, true, "{0:0.#}"));
            __result += string.Format("\nTotals:\n Digged tiles: {0} mass: {1} Efficiency: {2:F2}%", (object)Helper.DigNumber, (object)GameUtil.GetFormattedMass(Helper.MassTotal, (GameUtil.TimeSlice)0, (GameUtil.MetricMassFormat)0, true, "{0:0.#}"), (object)((double)Helper.DuplEff / (Helper.DigNumber > 0 ? (double)Helper.DigNumber : 1.0) * 100.0));
            __result += string.Format("\nOthers:\n Digged tiles: {0} mass: {1}", (object)Helper.OtherDigNumber, (object)GameUtil.GetFormattedMass(Helper.OtherMass, (GameUtil.TimeSlice)0, (GameUtil.MetricMassFormat)0, true, "{0:0.#}"));
        }
    }
}
