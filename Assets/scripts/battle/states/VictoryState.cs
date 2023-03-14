using UnityEngine;

public class VictoryState : State
{
    public VictoryState(BattleManager battleManager) : base(battleManager)
    {
    }

    public override void Enter()
    {
        base.Enter();

        this.battleManager.bamMenu.SetActive(false);
        this.battleManager.victoryScreen.SetActive(true);
    }
}
