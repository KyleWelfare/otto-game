using UnityEngine;
using UnityEngine.UI;

public class ActionSelectState : State
{
    private Button[] actionButtons;

    public ActionSelectState(BattleManager battleManager) : base(battleManager)
    {
        this.uiInputEnabled = true;
        this.gameplayInputEnabled = false;

        this.actionButtons = this.battleManager.bamMenu.GetComponentsInChildren<Button>(true);
        Debug.Log("Action Buttons" + this.actionButtons);
        foreach (Button button in actionButtons)
        {
            button.onClick.AddListener(() =>
            {
                this.battleManager.ChangeState(EBattleStates.PlayerAttack);
            });
        }
    }

    public override void Enter()
    {
        base.Enter();
        this.battleManager.bamMenu.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        this.battleManager.bamMenu.SetActive(false);
    }
}
