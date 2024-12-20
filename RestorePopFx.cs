// Decompiled with JetBrains decompiler
// Type: HappyDiggingDwarfEditionFixed.RestorePopFx
// Assembly: HappyDiggingDwarfEditionFixed, Version=2023.11.17.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C11C437-743F-4CFF-B542-FEC40313547E
// Assembly location: C:\Users\Luca\Documents\Klei\OxygenNotIncluded\mods\Steam\3088461193\HappyDiggingDwarfEditionFixed.dll

using HarmonyLib;
using System;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HappyDiggingDwarfEditionFixed
{
  [HarmonyPatch(typeof (PopFXManager), "SpawnFX", new Type[] {typeof (Sprite), typeof (string), typeof (Transform), typeof (Vector3), typeof (float), typeof (bool), typeof (bool)})]
  public static class RestorePopFx
  {
    public static void Postfix(PopFX __result)
    {
            if (__result == null)
              return;
      ((TMP_Text) __result.TextDisplay).fontSize = 24f;
      KMonoBehaviourExtensions.SetAlpha(__result.IconDisplay, 1f);
    }
  }
}
