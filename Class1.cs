// Decompiled with JetBrains decompiler
// Type: HappyDiggingDwarfEditionFixed.Class1
// Assembly: HappyDiggingDwarfEditionFixed, Version=2023.11.17.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C11C437-743F-4CFF-B542-FEC40313547E
// Assembly location: C:\Users\Luca\Documents\Klei\OxygenNotIncluded\mods\Steam\3088461193\HappyDiggingDwarfEditionFixed.dll

using HarmonyLib;

namespace HappyDiggingDwarfEditionFixed
{
    [HarmonyPatch(typeof(Workable), "WorkTick")]
    public class Class1
    {
        public static StandardWorker WW;

        public static bool Prefix(Workable __instance, bool __result, StandardWorker worker, float dt)
        {
            Class1.WW = worker;
            return true;
        }

        public static void Postfix()
        {
            Class1.WW = null;
        }
    }
}

