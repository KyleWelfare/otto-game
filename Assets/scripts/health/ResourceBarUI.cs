using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceBarUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text barText;
    [SerializeField]
    private Image fillBar;

    private int currentHealth;
    private int maxHealth;

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
        this.UpdateText();
        this.UpdateFill();
    }

    private void UpdateText()
    {
        this.barText.text = $"{this.currentHealth} / {this.maxHealth}";
    }

    private void UpdateFill()
    {
        float fillAmount = this.maxHealth / this.currentHealth;
        this.fillBar.fillAmount = fillAmount;
    }
}
