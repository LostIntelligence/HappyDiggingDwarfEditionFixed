// Decompiled with JetBrains decompiler
// Type: HappyDiggingDwarfEditionFixed.JetSuit
// Assembly: HappyDiggingDwarfEditionFixed, Version=2023.11.17.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C11C437-743F-4CFF-B542-FEC40313547E
// Assembly location: C:\Users\Luca\Documents\Klei\OxygenNotIncluded\mods\Steam\3088461193\HappyDiggingDwarfEditionFixed.dll

using HarmonyLib;

namespace HappyDiggingDwarfEditionFixed
{
  [HarmonyPatch(typeof (JetSuitConfig), "CreateEquipmentDef")]
  public static class JetSuit
  {
    public static void Postfix(EquipmentDef __result)
    {
      Atmosuit.DoThatThing(__result.AttributeModifiers, Config.Cfg.ChangeMiningToStrengthInJetSuit, Config.Cfg.Remove10MiningFromJetsuit, nameof (JetSuit));
    }
  }
}
