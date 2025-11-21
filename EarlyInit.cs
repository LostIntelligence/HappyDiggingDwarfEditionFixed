using HarmonyLib;
using KMod;

namespace HappyDiggingDwarfEditionFixed
{
  public class EarlyInit : UserMod2
  {
    private static bool Init;

    public override void OnLoad(Harmony harmony)
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
