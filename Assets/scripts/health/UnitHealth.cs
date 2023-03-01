using UnityEngine;

public class UnitHealth : MonoBehaviour, IDamageable
{
   [SerializeField] private int maxHealth;
   private int currentHealth;

   void Awake()
   {
      this.currentHealth = this.maxHealth;
   }

   public void Damage(int damageAmt)
   {
      this.currentHealth -= damageAmt;
      if (this.currentHealth <= 0)
      {
         this.Die();
      }
   }

   public void Heal(int healAmt)
   {
      this.currentHealth = Mathf.Min(this.currentHealth += healAmt, this.maxHealth);
   }

   public void Die()
   {
      this.gameObject.SetActive(false);
   }
}
