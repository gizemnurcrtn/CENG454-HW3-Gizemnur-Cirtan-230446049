using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 8f;
    public float lifeTime = 2f;

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
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0)
        {
            ReturnToPool();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        ReturnToPool();
    }

    void ReturnToPool()
    {
        if (pool != null)
        {
            pool.ReturnProjectile(this);
        }
    }
}