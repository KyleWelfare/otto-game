using UnityEngine;

public class State {
    protected string stateName;
    protected BattleManager battleManager;

    protected bool uiInputEnabled;
    protected bool gameplayInputEnabled;
    protected float startTime;

    public State(string name, BattleManager battleManager) {
        this.stateName = name;
        this.battleManager = battleManager;
    }

    public virtual void enter() {
        Debug.Log(this.stateName + " entered.");
        this.startTime = Time.time;
    }

    public virtual void exit() {
        Debug.Log(this.stateName + " exited.");
    }

    public virtual void update() {}
}