using UnityEngine;

public class CoreDamageLogger : MonoBehaviour
{
    void OnEnable()
    {
        CoreHealth.OnCoreDamaged += LogCoreDamage;
    }

    void OnDisable()
    {
        CoreHealth.OnCoreDamaged -= LogCoreDamage;
    }

    void LogCoreDamage(int currentHealth)
    {
        Debug.Log("Observer 1: Core health changed to " + currentHealth);
    }
}
