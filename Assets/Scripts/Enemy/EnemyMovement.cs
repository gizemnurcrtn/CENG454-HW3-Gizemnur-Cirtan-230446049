using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    public float attackDistance = 1.2f;
    public int damageAmount = 10;

    private bool hasDamaged = false;

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            Vector3 dir = (target.position - transform.position).normalized;
            transform.Translate(dir * speed * Time.deltaTime, Space.World);
        }
        else if (!hasDamaged)
        {
            IDamageable damageable = target.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(damageAmount);
                Debug.Log("Enemy damaged the core");
                hasDamaged = true;
            }
        }
    }
    void OnCollisionEnter(Collision other)
{
    if (other.gameObject.CompareTag("Core"))
    {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(10);
            Debug.Log("Enemy hit core");
        }
    }
}
}