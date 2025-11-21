using Database;
using System.Collections.Generic;
using UnityEngine;

namespace HappyDiggingDwarfEditionFixed
{
  public static class Helper
  {
    public static Dictionary<StandardWorker, int> DiggedCell = new Dictionary<StandardWorker , int>();
    public static Dictionary<GameObject, Data> Info = new Dictionary<GameObject, Data>();
    private static HashedString hs =null;

    public static int OtherDigNumber { get; set; } = 0;

    public static float OtherMass { get; set; } = 0.0f;

    public static float DuplEff { get; set; } = 0.0f;

    public static int DigNumber { get; set; } = 0;

    public static float MassTotal { get; set; } = 0.0f;

    public static HashedString DiggingHash
    {
      get
      {
        if (Helper.hs == null)
          return Helper.hs;
        foreach (SkillGroup resource in ((ResourceSet<SkillGroup>) Db.Get().SkillGroups).resources)
        {
          if ("Dig" == ((Resource) resource).Id)
          {
            Helper.hs = ((Resource) resource).IdHash;
            break;
          }
        }
        if(Helper.hs == null)
          Helper.hs = HashedString.Invalid;
        return Helper.hs;
      }
    }

    public static Data Empty { get; internal set; } = new Data();

    internal static bool MinionHasDigAptitude(MinionResume mm)
    {
            return mm != null && mm.AptitudeBySkillGroup != null &&
             mm.AptitudeBySkillGroup.TryGetValue((HashedString)((Resource)Db.Get().SkillGroups.Mining).Id, out float _);
        }
    }
}
