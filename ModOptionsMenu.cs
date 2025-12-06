using UnityEngine;
using PeterHan.PLib.Options;
using Newtonsoft.Json;

namespace HappyDiggingDwarfEditionFixed
{
    // This attribute is optional; you can add metadata (e.g. link or preview image).
    [JsonObject(MemberSerialization.OptIn)]
    [ModInfo("https://github.com/LostIntelligence/HappyDiggingDwarfEditionFixed")]
    public class HappyDiggingSettings
    {
        // Skills
        [Option("Dumb Digger Skill")]
        [Limit(0f, 1f)]
        [JsonProperty]
        public float DumbDiggerSkill { get; set; } = 0.5f;

        [Option("Dumb Digger Stat")]
        [Limit(1f, 500f)]
        [JsonProperty]
        public float DumbDiggerStat { get; set; } = 120f;

        [Option("Hard Digging Skill")]
        [Limit(0f, 1f)]
        [JsonProperty]
        public float HardDiggingSkill { get; set; } = 0.55f;

        [Option("Hard Digging Stat")]
        [Limit(1f, 500f)]
        [JsonProperty]
        public float HardDiggingStat { get; set; } = 100f;

        [Option("Super Hard Digging Skill")]
        [Limit(0f, 1f)]
        [JsonProperty]
        public float SuperHardDiggingSkill { get; set; } = 0.6f;

        [Option("Super Hard Digging Stat")]
        [Limit(1f, 500f)]
        [JsonProperty]
        public float SuperHardDiggingStat { get; set; } = 90f;

        [Option("Super‑Duper Hard Digging Skill")]
        [Limit(0f, 1f)]
        [JsonProperty]
        public float SuperDuperhardDiggingSkill { get; set; } = 0.65f;

        [Option("Super‑Duper Hard Digging Stat")]
        [Limit(1f, 500f)]
        [JsonProperty]
        public float SuperDuperhardDiggingStat { get; set; } = 70f;

        [Option("Hazmat Digging Skill")]
        [Limit(0f, 1f)]
        [JsonProperty]
        public float HazmatDiggingSkill { get; set; } = 0.7f;

        [Option("Hazmat Digging Stat")]
        [Limit(1f, 500f)]
        [JsonProperty]
        public float HazmatDiggingStat { get; set; } = 60f;

        // Multipliers & Booleans
        [Option("Allow efficiency > 100%")]
        [JsonProperty]
        public bool CanEfficiencyGoesOver100 { get; set; } = false;

        [Option("General Mass Multiplier")]
        [Limit(0.1f, 5f)]
        [JsonProperty]
        public float GeneralMassMultiplier { get; set; } = 1f;

        [Option("Non‑Duplicant Mining Efficiency")]
        [Limit(0f, 1f)]
        [JsonProperty]
        public float NonDuplicantMiningEfficiency { get; set; } = 0.5f;

        [Option("Show full info")]
        [JsonProperty]
        public bool FullInfo { get; set; } = true;

        [Option("Bonus Digging Aptitude")]
        [Limit(0f, 1f)]
        [JsonProperty]
        public float BonusDiggingAptitude { get; set; } = 0.07f;

        [Option("Full description in tooltip")]
        [JsonProperty]
        public bool FullDescriptionInToolTip { get; set; } = true;

        [Option("Show ratio popup")]
        [JsonProperty]
        public bool ShowRatio { get; set; } = true;

        // PopFX settings
        [Option("Text effect duration (s)")]
        [Limit(0.1f, 20f)]
        [JsonProperty]
        public float TextEffectDuration { get; set; } = 5f;

        [Option("Text effect speed multiplier")]
        [Limit(0.1f, 5f)]
        [JsonProperty]
        public float TextEffectSpeed { get; set; } = 0.5f;

        [Option("Text effect color")]
        [JsonProperty]
        public Color TextEffectColor { get; set; } = Color.green;

        [Option("Use gradient for effect color")]
        [JsonProperty]
        public bool CanUseGradient { get; set; } = true;

        [Option("50% efficiency color")]
        [JsonProperty]
        public Color Color50Eff { get; set; } = Color.red;

        [Option("75% efficiency color")]
        [JsonProperty]
        public Color Color75Eff { get; set; } = Color.yellow;

        [Option("100% efficiency color")]
        [JsonProperty]
        public Color Color100Eff { get; set; } = Color.green;

        [Option("150% efficiency color")]
        [JsonProperty]
        public Color Color150Eff { get; set; } = Color.blue;

        // Suit changes
        [Option("Remove 10 mining from Atmosuit")]
        [JsonProperty]
        public bool Remove10MiningFromAtmosuit { get; set; } = false;

        [Option("Change mining to strength in Atmosuit")]
        [JsonProperty]
        public bool ChangeMiningToStrengthInAtmosuit { get; set; } = false;

        [Option("Remove 10 mining from Jetsuit")]
        [JsonProperty]
        public bool Remove10MiningFromJetsuit { get; set; } = false;

        [Option("Change mining to strength in Jetsuit")]
        [JsonProperty]
        public bool ChangeMiningToStrengthInJetsuit { get; set; } = false;
    }
}