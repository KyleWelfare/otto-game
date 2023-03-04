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
        float fillAmt = (float)this.currentHealth / (float)this.maxHealth;
        // handle edge cases
        if (fillAmt < 1 && fillAmt > 0.91)
            fillAmt = (float)0.91;
        else if (fillAmt > 0 && fillAmt < 0.083)
            fillAmt = (float)0.1;

        this.fillBar.fillAmount = fillAmt;
    }
}
