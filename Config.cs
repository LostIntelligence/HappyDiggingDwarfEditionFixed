using UnityEngine;

namespace HappyDiggingDwarfEditionFixed
{
    public class Config
    {
        // Holds the current settings instance
        private static HappyDiggingSettings settings;

        public static void Init(HappyDiggingSettings s)
        {
            settings = s;
        }

        // Now all properties read from the settings instance
        public static Config Cfg { get; } = new Config();

        public float DumbDiggerSkill => settings.DumbDiggerSkill;
        public float DumbDiggerStat => settings.DumbDiggerStat;

        public float HardDiggingSkill => settings.HardDiggingSkill;
        public float HardDiggingStat => settings.HardDiggingStat;

        public float SuperHardDiggingSkill => settings.SuperHardDiggingSkill;
        public float SuperHardDiggingStat => settings.SuperHardDiggingStat;

        public float SuperDuperhardDiggingSkill => settings.SuperDuperhardDiggingSkill;
        public float SuperDuperhardDiggingStat => settings.SuperDuperhardDiggingStat;

        public float HazmatDiggingSkill => settings.HazmatDiggingSkill;
        public float HazmatDiggingStat => settings.HazmatDiggingStat;

        public bool CanEfficiencyGoesOver100 => settings.CanEfficiencyGoesOver100;
        public float GeneralMassMultiplier => settings.GeneralMassMultiplier;
        public float NonDuplicantMiningEfficiency => settings.NonDuplicantMiningEfficiency;
        public bool FullInfo => settings.FullInfo;
        public float BonusDiggingAptitude => settings.BonusDiggingAptitude;
        public bool FullDecsriptionInToolTip => settings.FullDescriptionInToolTip;
        public bool ShowRatio => settings.ShowRatio;

        public float TextEffectDuration => settings.TextEffectDuration;
        public float TextEffectSpeed => settings.TextEffectSpeed;
        public Color32 TextEffectColor => settings.TextEffectColor;
        public bool CanUseGradient => settings.CanUseGradient;
        public Color32 Color50Eff => settings.Color50Eff;
        public Color32 Color75Eff => settings.Color75Eff;
        public Color32 Color100Eff => settings.Color100Eff;
        public Color32 Color150Eff => settings.Color150Eff;

        public bool Remove10MiningFromAtmosuit => settings.Remove10MiningFromAtmosuit;
        public bool ChangeMiningToStrengthInAtmoSuit => settings.ChangeMiningToStrengthInAtmosuit;
        public bool Remove10MiningFromJetsuit => settings.Remove10MiningFromJetsuit;
        public bool ChangeMiningToStrengthInJetSuit => settings.ChangeMiningToStrengthInJetsuit;

        // Optional: path for migration
        public static string GetConfigFileName() =>
            System.IO.Path.Combine(System.IO.Path.GetDirectoryName(typeof(Class1).Assembly.Location), "HappyDiggingConfig.TxT");
    }
}
