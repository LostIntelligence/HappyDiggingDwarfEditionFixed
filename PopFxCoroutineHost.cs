using UnityEngine;

namespace HappyDiggingDwarfEditionFixed
{
    public class PopFxCoroutineHost : MonoBehaviour
    {
        private static PopFxCoroutineHost _instance;

        public static PopFxCoroutineHost Instance
        {
            get
            {
                if (_instance == null)
                {
                    var go = new GameObject("PopFxCoroutineHost");
                    UnityEngine.Object.DontDestroyOnLoad(go);
                    _instance = go.AddComponent<PopFxCoroutineHost>();
                }
                return _instance;
            }
        }
    }

}