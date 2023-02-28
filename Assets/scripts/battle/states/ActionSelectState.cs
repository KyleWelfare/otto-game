using UnityEngine;

public class ActionSelectState : State {
    public ActionSelectState(string name, BattleManager battleManager) : base(name, battleManager) {
        this.uiInputEnabled = true;
        this.gameplayInputEnabled = false;
    }

    public override void enter() {
        base.enter();
        this.battleManager.bamMenu.SetActive(true);
    }

   public override void exit() {
        base.exit();
        this.battleManager.bamMenu.SetActive(false);
    }
}
