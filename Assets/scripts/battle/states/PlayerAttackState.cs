using UnityEngine;

public class PlayerAttackState : AttackState
{
    public PlayerAttackState(BattleManager battleManager) : base(battleManager)
    {
        this.attacker = battleManager.player;
        this.target = battleManager.enemies[0];
    }

    public override void Update()
    {
        base.Update();

        if (this.attacker.transform.position == this.startPosition && this.attackState == EAttackStates.DoneAttacking)
        {
            this.battleManager.ChangeState(EBattleStates.EnemyAttack);
        }
    }
}
