using UnityEngine;
using UnityEditor;

public class VisualDebugger : MonoBehaviour
{
    [SerializeField]
    private static GameObject textBox;

#if UNITY_EDITOR || DEVELOPMENT_BUILD
    [RuntimeInitializeOnLoadMethod]
    public static void Initialize()
    {
        var go = Instantiate(Resources.Load<GameObject>("VisualDebugger"));

        go.SetActive(false);
        DontDestroyOnLoad(go);
        go.transform.SetParent(FindObjectOfType<Canvas>().transform);
    }
#endif
}
