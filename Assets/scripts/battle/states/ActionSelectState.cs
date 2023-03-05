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
