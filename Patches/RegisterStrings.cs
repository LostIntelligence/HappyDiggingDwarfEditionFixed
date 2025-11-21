using HarmonyLib;
using KMod;
using System;
using System.IO;
using System.Reflection;

namespace HappyDiggingDwarfEditionFixed.Patches
{
  internal class RegisterStrings
  {
    [HarmonyPatch(typeof (Localization), "Initialize")]
    [HarmonyPriority(800)]
    public class Localization_Initialize_Patch
    {
      public static void Postfix()
      {
        RegisterStrings.Localization_Initialize_Patch.Translate(typeof (STRINGS));
      }

      public static void Translate(Type root)
      {
        Localization.RegisterForTranslation(root);
        RegisterStrings.Localization_Initialize_Patch.LoadStrings();
        LocString.CreateLocStringKeys(root, (string) null);
        Localization.GenerateStringsTemplate(root, Path.Combine(Manager.GetDirectory(), "strings_templates"));
      }

      private static void LoadStrings()
      {
        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "translations", Localization.GetLocale()?.Code + ".po");
        if (!File.Exists(path))
          return;
        Localization.OverloadStrings(Localization.LoadStringsFile(path, false));
      }
    }
  }
}
