using UnityEngine;

public class DefeatState : State
{
    public DefeatState(BattleManager battleManager) : base(battleManager)
    {
    }

    public override void Enter()
    {
        base.Enter();

        this.battleManager.bamMenu.SetActive(false);
        this.battleManager.defeatScreen.SetActive(true);
    }
}
