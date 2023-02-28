using UnityEngine;
using System.Collections;

public class BattleIntroState : State {
    private float introDuration = 2f;

    public BattleIntroState(string name, BattleManager battleManager) : base(name, battleManager) {
        this.uiInputEnabled = false;
        this.gameplayInputEnabled = false;
    }

    public override void update() {
        if (Time.time - this.startTime > introDuration) {
            Debug.Log("state change hit");
            this.battleManager.stateMachine.changeState(this.battleManager.states["actionSelect"]);
        }
    }
}
