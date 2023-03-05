using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    [SerializeField]
    private BattleManager battleManager;
    [SerializeField]
    private EBattleStates stateToEnter;

    private Button button;

    void Awake()
    {
        this.button = this.gameObject.GetComponent<Button>();
        this.button.onClick.AddListener(() => this.battleManager.ChangeState(stateToEnter));
    }
}
