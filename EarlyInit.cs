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

            // Register options with PLib
            new POptions().RegisterOptions(this, typeof(HappyDiggingSettings));

            // Load saved user settings from disk
            var settings = POptions.ReadSettings<HappyDiggingSettings>();
            if (settings == null)
                settings = new HappyDiggingSettings();
            // Send Settings to config
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
