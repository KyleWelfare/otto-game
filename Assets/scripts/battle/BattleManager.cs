using UnityEngine;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{
    public StateMachine stateMachine { get; private set; }
    public Dictionary<string, State> states { get; private set; }
    [SerializeField]
    public GameObject bamMenu;

    void Awake()
    {
        VisualDebugger.Log("test");
        stateMachine = new StateMachine();
        states = new Dictionary<string, State>() {
            { "intro", new BattleIntroState("intro", this) },
            { "actionSelect", new ActionSelectState("actionSelect", this) }
        };
        stateMachine.Initialize(states["intro"]);
    }

    void Update()
    {
        this.stateMachine.currentState.Update();
    }
}
