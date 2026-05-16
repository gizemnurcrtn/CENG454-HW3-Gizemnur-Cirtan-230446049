using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 1.5f;
    public float attackDistance = 4f;
    public int damageAmount = 25;
    public float attackCooldown = 1f;

    private float attackTimer = 0f;
    private IMovementStrategy movementStrategy;

    void Start()
    {
        movementStrategy = new DirectMovement();
    }

    void Update()
    {
        if (target == null) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movementStrategy = new ZigZagMovement();
            Debug.Log("Strategy switched to ZigZagMovement");
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            movementStrategy.Move(transform, target, speed);
        }
        else
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0f)
            {
                IDamageable damageable = target.GetComponentInChildren<IDamageable>();

                if (damageable != null)
                {
                    damageable.TakeDamage(damageAmount);
                    Debug.Log("Enemy damaged the core");
                }
                else
                {
                    Debug.Log("No IDamageable found on Core or children");
                }

                attackTimer = attackCooldown;
            }
        }
    }
}