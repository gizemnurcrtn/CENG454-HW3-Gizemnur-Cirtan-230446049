using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 8f;
    public float lifeTime = 2f;
    public int damage = 10;

    private float lifeTimer;
    private Vector3 direction;
    private ProjectilePool pool;

    public void Initialize(Vector3 newDirection, ProjectilePool ownerPool)
    {
        direction = newDirection.normalized;
        pool = ownerPool;
        lifeTimer = lifeTime;
        gameObject.SetActive(true);
    }

    void Update()
    {
        float moveDistance = speed * Time.deltaTime;

        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, moveDistance))
        {
            Debug.Log("Projectile ray hit: " + hit.collider.name);

            EnemyHealth enemy = hit.collider.GetComponentInParent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("Enemy took damage from projectile");
                ReturnToPool();
                return;
            }
        }

        transform.Translate(direction * moveDistance, Space.World);

        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0)
        {
            ReturnToPool();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Projectile trigger hit: " + other.name);

        EnemyHealth enemy = other.GetComponentInParent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Debug.Log("Enemy took damage from trigger");
            ReturnToPool();
        }
    }

    void ReturnToPool()
    {
        if (pool != null)
        {
            pool.ReturnProjectile(this);
        }
    }
}