

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
