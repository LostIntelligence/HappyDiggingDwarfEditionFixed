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
        [Option("Mining Skill Tier 0 — Base Efficiency", "Additive base used in efficiency formula for Tier 0 (lowest) duplicants.")]
        [Limit(0f, 1f)]
        [JsonProperty]
        public float DumbDiggerSkill { get; set; } = 0.5f;

        [Option("Mining Skill Tier 0 — Stat Divisor", "Divisor applied to duplicant digging stat (Tier 0). Contribution = diggingStat / StatDivisor.")]
        [Limit(1f, 500f)]
        [JsonProperty]
        public float DumbDiggerStat { get; set; } = 120f;

        [Option("Mining Skill Tier 1 — Base Efficiency", "Base efficiency for Tier 1 duplicants.")]
        [Limit(0f, 1f)]
        [JsonProperty]
        public float HardDiggingSkill { get; set; } = 0.55f;

        [Option("Mining Skill Tier 1 — Stat Divisor", "Divisor applied to duplicant digging stat (Tier 1).")]
        [Limit(1f, 500f)]
        [JsonProperty]
        public float HardDiggingStat { get; set; } = 100f;

        [Option("Mining Skill Tier 2 — Base Efficiency", "Base efficiency for Tier 2 duplicants.")]
        [Limit(0f, 1f)]
        [JsonProperty]
        public float SuperHardDiggingSkill { get; set; } = 0.6f;

        [Option("Mining Skill Tier 2 — Stat Divisor", "Divisor applied to duplicant digging stat (Tier 2).")]
        [Limit(1f, 500f)]
        [JsonProperty]
        public float SuperHardDiggingStat { get; set; } = 90f;

        [Option("Mining Skill Tier 3 — Base Efficiency", "Base efficiency for Tier 3 duplicants.")]
        [Limit(0f, 1f)]
        [JsonProperty]
        public float SuperDuperhardDiggingSkill { get; set; } = 0.65f;

        [Option("Mining Skill Tier 3 — Stat Divisor", "Divisor applied to duplicant digging stat (Tier 3).")]
        [Limit(1f, 500f)]
        [JsonProperty]
        public float SuperDuperhardDiggingStat { get; set; } = 70f;

        [Option("Mining Skill Tier 4 — Base Efficiency (Hazmat/Bionic)", "Base efficiency for Tier 4 (hazmat / bionic) duplicants.")]
        [Limit(0f, 1f)]
        [JsonProperty]
        public float HazmatDiggingSkill { get; set; } = 0.7f;

        [Option("Mining Skill Tier 4 — Stat Divisor", "Divisor applied to duplicant digging stat (Tier 4).")]
        [Limit(1f, 500f)]
        [JsonProperty]
        public float HazmatDiggingStat { get; set; } = 60f;

        // Multipliers & Booleans
        [Option("Allow Efficiency Above 100%", "If enabled, calculated efficiency can exceed 1.0 (100%).")]
        [JsonProperty]
        public bool CanEfficiencyGoesOver100 { get; set; } = false;

        [Option("Global Mined Mass Multiplier", "Multiply mined mass after efficiency is applied.")]
        [Limit(0.1f, 5f)]
        [JsonProperty]
        public float GeneralMassMultiplier { get; set; } = 1f;

        [Option("Non-Duplicant (Auto-Miner) Efficiency", "Efficiency applied to non-duplicant mining sources.")]
        [Limit(0f, 1f)]
        [JsonProperty]
        public float NonDuplicantMiningEfficiency { get; set; } = 0.5f;

        [Option("Show Full Debug Info", "Show extra debug info in logs/popups.")]
        [JsonProperty]
        public bool FullInfo { get; set; } = true;

        [Option("Global Digging Aptitude Bonus", "Flat bonus added to aptitude in the formula if Duplicant likes Diggin.")]
        [Limit(0f, 1f)]
        [JsonProperty]
        public float BonusDiggingAptitude { get; set; } = 0.07f;

        [Option("Show Extended Tooltips", "Include extra descriptions in tooltips.")]
        [JsonProperty]
        public bool FullDescriptionInToolTip { get; set; } = true;

        [Option("Show Efficiency Ratio Popup", "Show the computed efficiency ratio in an on-screen popup when digging.")]
        [JsonProperty]
        public bool ShowRatio { get; set; } = true;

        // PopFX settings
        [Option("Popup Duration (s)", "How long the dig popup text remains visible.")]
        [Limit(0.1f, 20f)]
        [JsonProperty]
        public float TextEffectDuration { get; set; } = 5f;

        [Option("Popup Speed Multiplier", "Speed multiplier applied to popup animation (bigger = faster).")]
        [Limit(0.1f, 5f)]
        [JsonProperty]
        public float TextEffectSpeed { get; set; } = 0.5f;

        [Option("Popup Base Color", "Base color for the popup text (alpha supported).")]
        [JsonProperty]
        public Color TextEffectColor { get; set; } = Color.green;

        [Option("Popup Use Gradient", "Blend popup color between configured gradient stops.")]
        [JsonProperty]
        public bool CanUseGradient { get; set; } = true;

        [Option("Popup Color at 50% Efficiency", "Gradient color when efficiency ≈ 50%")]
        [JsonProperty]
        public Color Color50Eff { get; set; } = Color.red;

        [Option("Popup Color at 75% Efficiency", "Gradient color when efficiency ≈ 75%")]
        [JsonProperty]
        public Color Color75Eff { get; set; } = Color.yellow;

        [Option("Popup Color at 100% Efficiency", "Gradient color when efficiency ≈ 100%")]
        [JsonProperty]
        public Color Color100Eff { get; set; } = Color.green;

        [Option("Popup Color at 150% Efficiency", "Gradient color when efficiency ≥ 150%")]
        [JsonProperty]
        public Color Color150Eff { get; set; } = Color.blue;

        // Suit changes
        [Option("Atmosuit: Add -10 Mining", "Add -10 mining penalty to Atmosuits.")]
        [JsonProperty]
        public bool Remove10MiningFromAtmosuit { get; set; } = false;

        [Option("Atmosuit: Convert use Strength Atttribute", "Make Atmosuit use the Strenght instead of the Mining Skill.")]
        [JsonProperty]
        public bool ChangeMiningToStrengthInAtmosuit { get; set; } = false;

        [Option("Jet Suit: Add -10 Mining", "Add -10 mining penalty to Jet Suits.")]
        [JsonProperty]
        public bool Remove10MiningFromJetsuit { get; set; } = false;

        [Option("Jet Suit: Use Strength Atttribute", "Make Jet Suits use the Strenght instead of the Mining Skill.")]
        [JsonProperty]
        public bool ChangeMiningToStrengthInJetsuit { get; set; } = false;
    }
}