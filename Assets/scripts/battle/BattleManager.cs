using UnityEngine;
using System.Collections.Generic;
using System;

public class BattleManager : MonoBehaviour
{
    public StateMachine stateMachine { get; private set; }
    public Dictionary<EBattleStates, State> states { get; private set; }

    public GameObject bamMenu;
    public GameObject player;
    public GameObject[] enemies;

    void Awake()
    {
        stateMachine = new StateMachine();
        this.InitStates();
    }

    void Update()
    {
        this.stateMachine.currentState.Update();
    }

    void FixedUpdate()
    {
        this.stateMachine.currentState.FixedUpdate();
    }

    private void InitStates()
    {
        states = new Dictionary<EBattleStates, State>() {
            { EBattleStates.Intro, new BattleIntroState(this) },
            { EBattleStates.ActionSelect, new ActionSelectState(this) },
            { EBattleStates.PlayerAttack, new PlayerAttackState(this) }
        };
        stateMachine.Initialize(states[0]);
    }

    public void ChangeState(EBattleStates newState)
    {
        this.stateMachine.ChangeState(this.states[newState]);
    }
}
