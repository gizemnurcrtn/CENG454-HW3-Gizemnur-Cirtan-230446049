using UnityEngine;

public interface IMovementStrategy
{
    void Move(Transform enemy, Transform target, float speed);
}
