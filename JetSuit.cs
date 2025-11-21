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
