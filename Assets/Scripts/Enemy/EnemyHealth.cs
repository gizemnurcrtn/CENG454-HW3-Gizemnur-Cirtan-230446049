using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 30;

    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log("Enemy Health: " + health);

        if (health <= 0)
        {
            Debug.Log("Enemy destroyed!");

            GameStateUI ui = FindFirstObjectByType<GameStateUI>();

            if (ui != null)
            {
                ui.ShowWin();
            }

            Destroy(gameObject);
        }
    }

    void Die()
    {
        Debug.Log("Enemy destroyed!");

        Destroy(gameObject);
    }
}