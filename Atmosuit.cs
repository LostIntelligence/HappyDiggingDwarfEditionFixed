// Decompiled with JetBrains decompiler
// Type: HappyDiggingDwarfEditionFixed.Atmosuit
// Assembly: HappyDiggingDwarfEditionFixed, Version=2023.11.17.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C11C437-743F-4CFF-B542-FEC40313547E
// Assembly location: C:\Users\Luca\Documents\Klei\OxygenNotIncluded\mods\Steam\3088461193\HappyDiggingDwarfEditionFixed.dll

using HarmonyLib;
using Klei.AI;
using System.Collections.Generic;

namespace HappyDiggingDwarfEditionFixed
{
  [HarmonyPatch(typeof (AtmoSuitConfig), "CreateEquipmentDef")]
  public static class Atmosuit
  {
    public static void DoThatThing(List<AttributeModifier> list, bool v1, bool v2, string Name)
    {
      foreach (AttributeModifier attributeModifier in list)
      {
        if (attributeModifier.AttributeId == ((Resource) ((ModifierSet) Db.Get()).Attributes.Digging).Id)
        {
          if (v1)
          {
            Traverse.Create((object) attributeModifier).Property("AttributeId", (object[]) null).SetValue((object) ((Resource) ((ModifierSet) Db.Get()).Attributes.Strength).Id);
            Debug.Log((object) ("Happy Digging: Digging is changed to Strength in " + Name + "."));
          }
          if (!v2 | v1)
            break;
          Debug.Log((object) ("Happy Digging: Digging is removed from " + Name + "."));
          list.Remove(attributeModifier);
          break;
        }
      }
    }

    public static void Postfix(EquipmentDef __result)
    {
      Atmosuit.DoThatThing(__result.AttributeModifiers, Config.Cfg.ChangeMiningToStrengthInAtmoSuit, Config.Cfg.Remove10MiningFromAtmosuit, "AtmoSuit");
    }
  }
}
