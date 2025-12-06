using System.Collections;
using HarmonyLib;
using TMPro;
using UnityEngine;

namespace HappyDiggingDwarfEditionFixed
{
    public static class PopFxModifier
    {
        public static void Apply(PopFX popFx, Color color)
        {
            // Run on guaranteed-active host (never PopFX)
            PopFxCoroutineHost.Instance.StartCoroutine(ModifyRoutine(popFx, color));
        }

        private static IEnumerator ModifyRoutine(PopFX popFx, Color color)
        {
            // 🔒 Ensures PopFX is fully active
            yield return new WaitUntil(() => popFx != null && popFx.gameObject.activeInHierarchy);

            // 🔒 Ensures TMP, icons, masks, canvasGroup etc. are created
            yield return null;

            // Add the suppressor if not already present
            if (!popFx.gameObject.TryGetComponent<PopFxSuppressor>(out _))
                popFx.gameObject.AddComponent<PopFxSuppressor>();


            var tr = Traverse.Create(popFx);

            // =============================
            // TEXT HANDLING
            // =============================
            TMP_Text tmp = popFx.TextDisplay as TMP_Text;
            if (tmp != null)
            {
                tmp.maxVisibleCharacters = int.MaxValue;
                tmp.maxVisibleWords = int.MaxValue;
                tmp.maxVisibleLines = int.MaxValue;

                tmp.enableWordWrapping = false;

                tmp.color = color;
                tmp.alpha = 1f;
                tmp.fontSize = 24f;

                tmp.ForceMeshUpdate();
            }

            // =============================
            // REMOVE ICONS
            // =============================
            if (popFx.IconDisplay != null)
                popFx.IconDisplay.gameObject.SetActive(false);

            if (popFx.MainIconDisplay != null)
                popFx.MainIconDisplay.gameObject.SetActive(false);

            // Make sure canvas group is fully visible
            if (popFx.canvasGroup != null)
                popFx.canvasGroup.alpha = 1f;


            // =============================
            // SCALE LIFETIME
            // =============================
            float baseLifetime = tr.Field("lifetime").GetValue<float>();
            tr.Field("lifetime").SetValue(baseLifetime / Config.Cfg.TextEffectSpeed);

            // =============================
            // OFFSET
            // =============================
            tr.Field("offset").SetValue(new Vector3(0f, 2.5f));

            popFx.transform.localScale = Vector3.one;
        }
    }
}