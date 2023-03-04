using UnityEngine;

public class BattleIntroState : State
{
    private float introDuration = 2f;

    public BattleIntroState(string name, BattleManager battleManager) : base(name, battleManager)
    {
        this.uiInputEnabled = false;
        this.gameplayInputEnabled = false;
    }

    public override void Update()
    {
        if (Time.time - this.startTime > introDuration)
        {
            this.battleManager.stateMachine.ChangeState(this.battleManager.states["actionSelect"]);
        }
    }
}
