using UnityEngine;

public enum EAttackStates
{
    MovingToEnemy,
    Attacking,
    DoneAttacking
}

public abstract class AttackState : State
{
    protected GameObject attacker;
    protected GameObject target;

    protected MoveToTargetInSeconds movementScript;
    protected Vector3 startPosition;
    protected Vector3 targetPosition;
    protected EAttackStates attackState;

    public AttackState(BattleManager battleManager) : base(battleManager)
    {
        this.gameplayInputEnabled = true;
        this.uiInputEnabled = false;
    }

    public override void Enter()
    {
        base.Enter();
        this.attackState = EAttackStates.MovingToEnemy;
        this.startPosition = this.attacker.transform.position;

        this.movementScript = this.attacker.GetComponent<MoveToTargetInSeconds>();
        this.movementScript.move(this.targetPosition, 1f);
    }

    public override void Update()
    {
        base.Update();
        Vector3 attackerPosition = this.attacker.transform.position;

        if (attackerPosition == this.targetPosition && this.attackState == EAttackStates.MovingToEnemy)
        {
            this.Attack();
        }

        if (attackerPosition == this.targetPosition && this.attackState == EAttackStates.DoneAttacking)
        {
            this.ReturnToStart();
        }


    }

    protected virtual void Attack()
    {
        this.attackState = EAttackStates.Attacking;
        this.target.GetComponent<UnitHealth>().Damage(3);
        this.attackState = EAttackStates.DoneAttacking;
    }

    protected virtual void ReturnToStart()
    {
        this.movementScript.move(this.startPosition, 1f);
    }
}
