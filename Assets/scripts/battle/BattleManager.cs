using UnityEngine;
using System.Collections.Generic;
using System;

public class BattleManager : MonoBehaviour
{
    public StateMachine stateMachine { get; private set; }
    public Dictionary<EBattleStates, State> states { get; private set; }

    public GameObject bamMenu;

    void Awake()
    {
        stateMachine = new StateMachine();
        this.InitStates();
    }

    void Update()
    {
        this.stateMachine.currentState.Update();
    }

    private void InitStates()
    {
        states = new Dictionary<EBattleStates, State>() {
            { EBattleStates.Intro, new BattleIntroState(this) },
            { EBattleStates.ActionSelect, new ActionSelectState(this) }
            // { EBattleStates.PlayerAttack, new PlayerAttackState(this) },
            // { EBattleStates.EnemyAttack, new EnemyAttackState(this) }
        };
        stateMachine.Initialize(states[EBattleStates.Intro]);
    }

    public void ChangeState(EBattleStates newState)
    {
        this.stateMachine.ChangeState(this.states[newState]);
    }
}
