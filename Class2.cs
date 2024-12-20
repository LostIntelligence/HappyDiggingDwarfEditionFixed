// Decompiled with JetBrains decompiler
// Type: HappyDiggingDwarfEditionFixed.Class2
// Assembly: HappyDiggingDwarfEditionFixed, Version=2023.11.17.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C11C437-743F-4CFF-B542-FEC40313547E
// Assembly location: C:\Users\Luca\Documents\Klei\OxygenNotIncluded\mods\Steam\3088461193\HappyDiggingDwarfEditionFixed.dll

using HarmonyLib;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HappyDiggingDwarfEditionFixed
{
  [HarmonyPatch(typeof (Diggable), "DoDigTick", new Type[] {typeof (int), typeof (float)})]
  public class Class2
  {
    public static bool Prefix(int cell, float dt)
    {
      if (Class1.WW == null)
        return true;
      int num;
      if (!Helper.DiggedCell.TryGetValue((StandardWorker)Class1.WW, out num))
        Helper.DiggedCell.Add(Class1.WW, cell);
      else if (num != cell)
        Helper.DiggedCell[Class1.WW] = cell;
      return true;
    }
  }
}
