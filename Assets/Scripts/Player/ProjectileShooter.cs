using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public ProjectilePool projectilePool;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Projectile projectile = projectilePool.GetProjectile();

        if (projectile != null)
        {
            projectile.transform.position = transform.position + transform.forward;

            projectile.Initialize(transform.forward, projectilePool);

            Debug.Log("Projectile fired from pool");
        }
    }
}
