using UnityEngine;
using UnityEngine.UI;

public class ActionSelectState : State
{
    private Button[] actionButtons;

    public ActionSelectState(BattleManager battleManager) : base(battleManager)
    {
        this.uiInputEnabled = true;
        this.gameplayInputEnabled = false;
    }

    void Awake()
    {
        this.actionButtons = GameObject.Find("BAM").GetComponentsInChildren<Button>();
        foreach (Button button in actionButtons)
        {
            button.onClick.AddListener(() =>
            {
                EntityMoveToPositionState moveState = (EntityMoveToPositionState)this.battleManager.states[EBattleStates.EntityMoveToPositionState];
                moveState.setParams(this.battleManager.player, new Vector3(1, 0, 0), 1.5f);
                this.battleManager.stateMachine.ChangeState(moveState);
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
