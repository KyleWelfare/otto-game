using UnityEngine;

public class EntityMoveToPositionState : State
{
    public GameObject objectToMove;
    public Vector3 target;
    public float seconds;

    public EntityMoveToPositionState(BattleManager battleManager) : base(battleManager)
    {
        this.uiInputEnabled = false;
        this.gameplayInputEnabled = true;
    }

    public override void Enter()
    {
        this.objectToMove.GetComponent<MoveToTargetInSeconds>().start(
            target,
            seconds
        );

        MoveToTargetInSeconds.OnArrivedAtTarget += StartAttack;
    }

    private void StartAttack(GameObject movedTarget)
    {
        this.battleManager.stateMachine.ChangeState(this.battleManager.states[EBattleStates.ActionSelect]);
    }

    public void setParams(GameObject objectToMove, Vector3 target, float seconds)
    {
        this.objectToMove = objectToMove;
        this.target = target;
        this.seconds = seconds;
    }
}
