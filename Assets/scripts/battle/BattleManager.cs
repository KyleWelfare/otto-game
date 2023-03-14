using UnityEngine;
using System.Collections.Generic;
using System;

public class BattleManager : MonoBehaviour
{
    public StateMachine stateMachine { get; private set; }
    public Dictionary<EBattleStates, State> states { get; private set; }

    public GameObject bamMenu;
    public GameObject victoryScreen;
    public GameObject defeatScreen;

    public GameObject player;
    public GameObject[] enemies;

    void Awake()
    {
        stateMachine = new StateMachine();
        this.InitStates();
    }

    private void InitStates()
    {
        states = new Dictionary<EBattleStates, State>() {
            { EBattleStates.Intro, new BattleIntroState(this) },
            { EBattleStates.ActionSelect, new ActionSelectState(this) },
            { EBattleStates.PlayerAttack, new PlayerAttackState(this) },
            { EBattleStates.EnemyAttack, new EnemyAttackState(this) },
            { EBattleStates.Victory , new VictoryState(this) },
            { EBattleStates.Defeat , new DefeatState(this) }
        };
        stateMachine.Initialize(states[0]);
    }

    public void ChangeState(EBattleStates newState)
    {
        if (this.player.GetComponent<UnitHealth>().getCurrentHealth() <= 0)
            this.stateMachine.ChangeState(this.states[EBattleStates.Defeat]);
        else if (this.enemies[0].GetComponent<UnitHealth>().getCurrentHealth() <= 0)
            this.stateMachine.ChangeState(this.states[EBattleStates.Victory]);
        else
            this.stateMachine.ChangeState(this.states[newState]);
    }

    void Update()
    {
        this.stateMachine.currentState.Update();
    }

    void FixedUpdate()
    {
        this.stateMachine.currentState.FixedUpdate();
    }
}
