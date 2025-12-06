using HarmonyLib;
using TMPro;
using UnityEngine;

namespace HappyDiggingDwarfEditionFixed
{
    public class PopFxSuppressor : MonoBehaviour
    {
        private PopFX fx;
        private TMP_Text tmp;
        private Traverse tr;
        // The below might look unused but its important as it holds togehter the instant text reveal for the popup
        void Awake()
        {
            fx = GetComponent<PopFX>();
            tmp = fx?.TextDisplay as TMP_Text;
            if (fx != null) tr = Traverse.Create(fx);
        }

        void LateUpdate()
        {
            if (fx == null || tmp == null) return;

            // Fully reveal text
            tmp.maxVisibleCharacters = int.MaxValue;
            tmp.maxVisibleWords = int.MaxValue;
            tmp.maxVisibleLines = int.MaxValue;
            tmp.alpha = 1f;

            // Override internal animation fields
            if (tr != null)
            {
                tr.Field("revealProgress").SetValue(1f);
                tr.Field("alpha").SetValue(1f);
                tr.Field("fadeInFraction").SetValue(0f);
                tr.Field("fadeOutFraction").SetValue(0f);
            }

            // Remove any mask fill if used
            if (fx.mask != null) fx.mask.fillAmount = 1f;
        }
    }


}
