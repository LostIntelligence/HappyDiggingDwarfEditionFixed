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
