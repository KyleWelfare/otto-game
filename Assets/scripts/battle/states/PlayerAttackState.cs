using UnityEngine;

enum EAttackStates
{
    MovingToEnemy,
    Attacking,
    DoneAttacking
}

public class PlayerAttackState : State
{
    private MoveToTargetInSeconds movementScript;
    private Vector3 startPosition;
    private Vector3 targetPosition = new Vector3(1, 0, 0);
    private EAttackStates attackState;

    public PlayerAttackState(BattleManager battleManager) : base(battleManager)
    {
        this.gameplayInputEnabled = true;
        this.uiInputEnabled = false;
    }

    public override void Enter()
    {
        base.Enter();
        this.startPosition = this.battleManager.player.transform.position;
        this.attackState = EAttackStates.MovingToEnemy;

        this.movementScript = this.battleManager.player.GetComponent<MoveToTargetInSeconds>();
        this.movementScript.start(this.targetPosition, 1f);
    }

    public override void Update()
    {
        base.Update();
        Vector3 playerPosition = this.battleManager.player.transform.position;

        if (playerPosition == this.targetPosition && this.attackState == EAttackStates.MovingToEnemy)
        {
            this.Attack();
        }

        if (playerPosition == this.targetPosition && this.attackState == EAttackStates.DoneAttacking)
        {
            this.ReturnToStart();
        }

        if (playerPosition == this.startPosition && this.attackState == EAttackStates.DoneAttacking)
        {
            this.battleManager.ChangeState(EBattleStates.ActionSelect);
        }
    }

    private void Attack()
    {
        this.attackState = EAttackStates.Attacking;
        this.battleManager.enemies[0].GetComponent<UnitHealth>().Damage(3);
        this.attackState = EAttackStates.DoneAttacking;
    }

    private void ReturnToStart()
    {
        this.movementScript.start(this.startPosition, 1f);
    }
}
