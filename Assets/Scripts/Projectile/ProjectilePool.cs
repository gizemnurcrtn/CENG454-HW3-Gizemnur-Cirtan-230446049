using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public Projectile projectilePrefab;
    public int poolSize = 10;

    private Queue<Projectile> availableProjectiles = new Queue<Projectile>();

    void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            Projectile projectile = Instantiate(projectilePrefab, transform);
            projectile.gameObject.SetActive(false);
            availableProjectiles.Enqueue(projectile);
        }
    }

    public Projectile GetProjectile()
{
    if (availableProjectiles.Count == 0)
    {
        Debug.Log("Pool empty!");
        return null;
    }

    Projectile projectile = availableProjectiles.Dequeue();

    Debug.Log("Projectile reused from pool. Remaining: " + availableProjectiles.Count);

    return projectile;
}

    public void ReturnProjectile(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
        availableProjectiles.Enqueue(projectile);
    }
}