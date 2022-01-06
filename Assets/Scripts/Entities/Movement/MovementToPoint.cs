using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementToPoint : IMovement
{
    private Transform _origin, _target;

    public MovementToPoint(Transform origin, Transform target)
    {
        _origin = origin;
        _target = target;
    }

    public void Move()
    {
        //Добавить pathfinding
        _origin.position = Vector3.MoveTowards(_origin.position, _target.position, 2f * Time.deltaTime);
    }
}
