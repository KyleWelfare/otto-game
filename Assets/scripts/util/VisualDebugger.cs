using UnityEngine;

public class VisualDebugger : MonoBehaviour
{
    private static GameObject visualDebuggerGO;

    public static void Log(string message)
    {
        if (!VisualDebugger.visualDebuggerGO)
        {
            // VisualDebugger.visualDebuggerGO = Instantiate(debugger prefab);
        }
    }
}
