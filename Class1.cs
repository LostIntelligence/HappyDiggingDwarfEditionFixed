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

