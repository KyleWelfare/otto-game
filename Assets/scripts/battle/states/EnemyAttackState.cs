using UnityEngine;

public class EnemyAttackState : AttackState
{
    public EnemyAttackState(BattleManager battleManager) : base(battleManager)
    {
        this.attacker = battleManager.enemies[0];
        this.target = battleManager.player;
    }

    public override void Update()
    {
        base.Update();

        if (this.attacker.transform.position == this.startPosition && this.attackState == EAttackStates.DoneAttacking)
        {
            this.battleManager.ChangeState(EBattleStates.ActionSelect);
        }
    }
}
