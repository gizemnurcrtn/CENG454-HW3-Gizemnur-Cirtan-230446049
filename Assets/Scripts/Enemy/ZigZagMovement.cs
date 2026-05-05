using UnityEngine;

public class ZigZagMovement : IMovementStrategy
{
    public void Move(Transform enemy, Transform target, float speed)
    {
        Vector3 dir = (target.position - enemy.position).normalized;
        Vector3 zigzag = new Vector3(Mathf.Sin(Time.time * 5f), 0, 0);

        enemy.Translate((dir + zigzag) * speed * Time.deltaTime, Space.World);
    }
}