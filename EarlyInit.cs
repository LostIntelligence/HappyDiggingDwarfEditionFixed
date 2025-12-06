using System.IO;
using System.Xml.Serialization;
using HarmonyLib;
using KMod;
using PeterHan.PLib.Core;
using PeterHan.PLib.Options;
namespace HappyDiggingDwarfEditionFixed
{
    public class EarlyInit : UserMod2
    {
        private static bool Init;

        private static HappyDiggingSettings settings;
        public static HappyDiggingSettings Settings => settings;
        public override void OnLoad(Harmony harmony)
        {
            PUtil.InitLibrary(false);

            // Initialize new PLib settings
            settings = new HappyDiggingSettings();
         

            // Register PLib options
            new POptions().RegisterOptions(this, typeof(HappyDiggingSettings));
            Config.Init(settings);
            base.OnLoad(harmony);
            EarlyInit.PostInit();
        }

        public static void PostInit()
        {
            if (EarlyInit.Init)
                return;
            EarlyInit.Init = true;
            Debug.Log((object)string.Format("HappyDigging mod - Initialize"));
        }
    }
}
