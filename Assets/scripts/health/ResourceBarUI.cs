using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceBarUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text barText;
    private Slider slider;

    private int currentHealth;
    private int maxHealth;

    void Awake()
    {
        this.slider = GetComponent<Slider>();
    }

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
        float hpPercent = (float)this.currentHealth / (float)this.maxHealth;
        this.slider.value = hpPercent;
    }
}
