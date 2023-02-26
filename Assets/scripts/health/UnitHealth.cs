using UnityEngine;

public class UnitHealth : MonoBehaviour, IDamageable {
   [SerializeField] private int maxHealth;
   private int currentHealth;

   void Awake() {
      this.currentHealth = this.maxHealth;
   }

   public void damage(int damageAmt) {
      this.currentHealth -= damageAmt;
      if (this.currentHealth <= 0)
      {
         this.die();
      }
   }

   public void heal(int healAmt) {
      this.currentHealth = Mathf.Min(this.currentHealth += healAmt, this.maxHealth);
   }

   public void die() {
      this.gameObject.SetActive(false);
   }
}
