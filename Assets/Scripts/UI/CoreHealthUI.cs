using TMPro;
using UnityEngine;

public class CoreHealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    void OnEnable()
    {
        CoreHealth.OnCoreDamaged += UpdateHealthText;
    }

    void OnDisable()
    {
        CoreHealth.OnCoreDamaged -= UpdateHealthText;
    }

    void Start()
    {
        healthText.text = "CORE HEALTH: 100";
    }

    void UpdateHealthText(int currentHealth)
    {
        healthText.text = "CORE HEALTH: " + currentHealth;
    }
}
