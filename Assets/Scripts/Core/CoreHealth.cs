using UnityEngine;
using System;

public class CoreHealth : MonoBehaviour, IDamageable
{
    public static event Action<int> OnCoreDamaged;

    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Core took damage: " + damage);

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        OnCoreDamaged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            GameStateUI ui = FindFirstObjectByType<GameStateUI>();

            if (ui != null)
            {
                ui.ShowLose();
            }

            Debug.Log("GAME OVER");
        }
    }
}