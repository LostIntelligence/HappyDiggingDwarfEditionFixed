// Decompiled with JetBrains decompiler
// Type: HappyDiggingDwarfEditionFixed.EarlyInit
// Assembly: HappyDiggingDwarfEditionFixed, Version=2023.11.17.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C11C437-743F-4CFF-B542-FEC40313547E
// Assembly location: C:\Users\Luca\Documents\Klei\OxygenNotIncluded\mods\Steam\3088461193\HappyDiggingDwarfEditionFixed.dll

using HarmonyLib;
using KMod;

namespace HappyDiggingDwarfEditionFixed
{
  public class EarlyInit : UserMod2
  {
    private static bool Init;

    public virtual void OnLoad(Harmony harmony)
    {
      base.OnLoad(harmony);
      EarlyInit.PostInit();
    }

    public static void PostInit()
    {
      if (EarlyInit.Init)
        return;
      EarlyInit.Init = true;
      Debug.Log((object) (string.Format("HappyDigging mod - Initialize. (Version: {0})", (object) Config.Cfg.Ver) + "@Build: " + typeof (EarlyInit).Assembly.GetName().Version.ToString()));
    }
  }
}
