using UnityEngine;
using UnityEngine.Events;

public class UnitHealth : MonoBehaviour, IDamageable
{
    [SerializeField]
    private ResourceBarUI healthBarUi;

    [SerializeField] private int maxHealth;
    private int currentHealth;

    private UnityEvent onHealthChange;

    void Awake()
    {
        this.currentHealth = this.maxHealth;
        this.UpdateUi();
    }

    public void Damage(int damageAmt)
    {
        this.currentHealth -= damageAmt;

        if (this.currentHealth > 0)
            this.UpdateUi();
        else
            this.Die();
    }

    public void Heal(int healAmt)
    {
        this.currentHealth = Mathf.Min(this.currentHealth += healAmt, this.maxHealth);
        this.UpdateUi();
    }

    public void Die()
    {
        this.gameObject.SetActive(false);
    }

    private void UpdateUi()
    {
        this.healthBarUi.UpdateHealth(this.currentHealth, this.maxHealth);
    }
}
