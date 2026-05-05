using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    public float attackDistance = 3f;
    public int damageAmount = 10;

    private bool hasDamaged = false;
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
}