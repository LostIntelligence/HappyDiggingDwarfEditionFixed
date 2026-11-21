using HarmonyLib;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HappyDiggingDwarfEditionFixed
{
  [HarmonyPatch(typeof (Diggable), "DoDigTick", new[] { typeof (float) })]
  public class Class2
  {
    public static bool Prefix(int ___cached_cell)
    {
      if (Class1.WW == null)
        return true;
      int num;
      if (!Helper.DiggedCell.TryGetValue((StandardWorker)Class1.WW, out num))
        Helper.DiggedCell.Add(Class1.WW, ___cached_cell);
      else if (num != ___cached_cell)
        Helper.DiggedCell[Class1.WW] = ___cached_cell;
      return true;
    }
  }
}
