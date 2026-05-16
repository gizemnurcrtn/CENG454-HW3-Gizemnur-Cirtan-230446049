using UnityEngine;
using TMPro;

public class ProjectileShooter : MonoBehaviour
{
    public ProjectilePool projectilePool;
    public Transform shootPoint;
    public Transform shootTarget;
    public TMP_Text gameStateText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        IProjectile projectileData = new BasicProjectile();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            projectileData = new FireDecorator(projectileData);
            Debug.Log("Fire decorator applied!");
        }
        if (gameStateText != null)
        {
            gameStateText.text = "FIRE SHOT ACTIVATED";
        }

        int damage = projectileData.GetDamage();
        Debug.Log("Projectile Damage: " + damage);

        Projectile projectile = projectilePool.GetProjectile();

        if (projectile != null)
        {
            Transform origin = shootPoint != null ? shootPoint : transform;

            projectile.transform.position = origin.position;

            Vector3 targetPosition = shootTarget.position + Vector3.up * 1f;
            Vector3 shootDirection = (targetPosition - origin.position).normalized;

            projectile.Initialize(shootDirection, projectilePool);

            EnemyHealth enemy = shootTarget.GetComponentInParent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("Enemy took direct projectile damage");
            }

            Debug.Log("Projectile fired from pool");
        }
    }
}