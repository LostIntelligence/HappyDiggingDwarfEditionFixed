// Decompiled with JetBrains decompiler
// Type: HappyDiggingDwarfEditionFixed.Config
// Assembly: HappyDiggingDwarfEditionFixed, Version=2023.11.17.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C11C437-743F-4CFF-B542-FEC40313547E
// Assembly location: C:\Users\Luca\Documents\Klei\OxygenNotIncluded\mods\Steam\3088461193\HappyDiggingDwarfEditionFixed.dll

using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace HappyDiggingDwarfEditionFixed
{
  public class Config
    {
    [NonSerialized]
    private static Config cfg;

    public int Ver { get; set; } = 1;

    public float DumbDiggerSkill { get; set; } = 0.5f;

    public float DumbDiggerStat { get; set; } = 120f;

    public float HardDiggingSkill { get; set; } = 0.55f;

    public float HardDiggingStat { get; set; } = 100f;

    public float SuperHardDiggingSkill { get; set; } = 0.6f;

    public float SuperHardDiggingStat { get; set; } = 90f;

    public float SuperDuperhardDiggingSkill { get; set; } = 0.65f;

    public float SuperDuperhardDiggingStat { get; set; } = 70f;

    public float HazmatDiggingSkill { get; set; } = 0.7f;

    public float HazmatDiggingStat { get; set; } = 60f;

    public bool CanEfficiencyGoesOver100 { get; set; } = false;

    public float GeneralMassMultiplier { get; set; } = 1f;

    public float NonDuplicantMiningEfficiency { get; set; } = 0.5f;

    public bool FullInfo { get; set; } = true;

    public float BonusDiggingAptitude { get; set; } = 0.07f;

    public bool FullDecsriptionInToolTip { get; set; } = true;

    public bool ShowRatio { get; set; } = true;

    public float TextEffectDuration { get; set; } = 5f;

    public float TextEffectSpeed { get; set; } = 0.5f;

    public Color32 TextEffectColor { get; set; } = (Color32) Color.green;

    public bool CanUseGradient { get; set; } = true;

    public Color32 Color50Eff { get; set; } = (Color32)Color.red;

    public Color32 Color75Eff { get; set; } = (Color32)Color.yellow;

    public Color32 Color100Eff { get; set; } = (Color32)Color.green;

        public Color32 Color150Eff { get; set; } = (Color32)Color.blue;

        public bool Remove10MiningFromAtmosuit { get; set; } = false;

    public bool ChangeMiningToStrengthInAtmoSuit { get; set; } = false;

    public bool Remove10MiningFromJetsuit { get; set; } = false;

    public bool ChangeMiningToStrengthInJetSuit { get; set; } = false;

    public static string GetConfigFileName()
    {
      return Path.Combine(Path.GetDirectoryName(typeof (Class1).Assembly.Location), "HappyDiggingConfig.TxT");
    }

    public static void SaveConfig(Config C)
    {
      if (C == null)
        return;
      try
      {
        using (StreamWriter streamWriter = new StreamWriter(Config.GetConfigFileName()))
        {
          new XmlSerializer(typeof (Config)).Serialize((TextWriter) streamWriter, (object) Config.cfg);
          streamWriter.Flush();
        }
      }
      catch (Exception ex)
      {
        Debug.Log((object) ("Something goes wrong, can not save config (" + Config.GetConfigFileName() + "), Exception: " + ex.ToString()));
      }
    }

    public static Config Cfg
    {
      get
      {
        if (Config.cfg != null)
          return Config.cfg;
        if (!File.Exists(Config.GetConfigFileName()))
        {
          Debug.Log((object) ("Config file not found (" + Config.GetConfigFileName() + "). Creating new one with default values."));
          Config.cfg = new Config();
          Config.cfg.Ver = 4;
          Config.SaveConfig(Config.cfg);
          return Config.cfg;
        }
        try
        {
          using (FileStream fileStream = File.OpenRead(Config.GetConfigFileName()))
          {
            Config.cfg = new XmlSerializer(typeof (Config)).Deserialize((Stream) fileStream) as Config;
            if ((double) Config.cfg.HardDiggingStat == 0.0)
              Config.cfg.HardDiggingStat = 100f;
            if ((double) Config.cfg.SuperHardDiggingSkill == 0.0)
              Config.cfg.SuperHardDiggingStat = 100f;
            if ((double) Config.cfg.SuperDuperhardDiggingStat == 0.0)
              Config.cfg.SuperDuperhardDiggingStat = 100f;
            if ((double) Config.cfg.DumbDiggerStat == 0.0)
              Config.cfg.DumbDiggerStat = 100f;
          }
          if (Config.cfg.Ver == 1)
          {
            Config.cfg.Ver = 2;
            Config.cfg.BonusDiggingAptitude = 0.07f;
            Debug.Log((object) "Configuration updated to version 2.");
            Config.SaveConfig(Config.cfg);
          }
          if (Config.cfg.Ver == 2)
          {
            Config.cfg.Ver = 3;
            Config.cfg.FullDecsriptionInToolTip = true;
            Config.cfg.ShowRatio = true;
            Debug.Log((object) "Configuration updated to version 3.");
            Config.SaveConfig(Config.cfg);
          }
          if (Config.cfg.Ver != 5)
          {
            Config.cfg.Ver = 5;
            Debug.Log((object) "HappyDigging updated to version 5.");
            Config.SaveConfig(Config.cfg);
          }
          if (Config.cfg.Ver != 6)
          {
            Config.cfg.Ver = 6;
            Config.cfg.HazmatDiggingSkill = 0.7f;
            Config.cfg.HazmatDiggingStat = 60f;
            Debug.Log((object) "HappyDigging updated to version 6.");
            Config.SaveConfig(Config.cfg);
          }
        }
        catch (Exception ex)
        {
          Debug.Log((object) ("Something goes wrong, can not load config (" + Config.GetConfigFileName() + "), Exception: " + ex.ToString()));
          Config.cfg = new Config();
        }
        return Config.cfg;
      }
    }
  }
}
