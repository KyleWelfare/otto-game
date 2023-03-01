using UnityEngine;

public class ActionSelectState : State
{
   public ActionSelectState(string name, BattleManager battleManager) : base(name, battleManager)
   {
      this.uiInputEnabled = true;
      this.gameplayInputEnabled = false;
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
