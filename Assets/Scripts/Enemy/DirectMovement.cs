using UnityEngine;

public class DirectMovement : IMovementStrategy
{
    public void Move(Transform enemy, Transform target, float speed)
    {
        Vector3 dir = (target.position - enemy.position).normalized;
        enemy.Translate(dir * speed * Time.deltaTime, Space.World);
    }
}