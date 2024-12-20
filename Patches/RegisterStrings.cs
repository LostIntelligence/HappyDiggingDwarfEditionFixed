// Decompiled with JetBrains decompiler
// Type: HappyDiggingDwarfEditionFixed.Patches.RegisterStrings
// Assembly: HappyDiggingDwarfEditionFixed, Version=2023.11.17.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C11C437-743F-4CFF-B542-FEC40313547E
// Assembly location: C:\Users\Luca\Documents\Klei\OxygenNotIncluded\mods\Steam\3088461193\HappyDiggingDwarfEditionFixed.dll

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
