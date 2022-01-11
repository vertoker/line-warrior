using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class MovementToTarget : IMovement
{
    private Transform _origin, _target;
    private AIDestinationSetter _setter;

    public MovementToTarget(Transform origin, Transform target)
    {
        _origin = origin; 
        _target = target;
        _setter = origin.GetComponent<AIDestinationSetter>();
        _setter.target = target;
    }

    public void Move()
    {
        //Добавить pathfinding
        //_origin.position = Vector3.MoveTowards(_origin.position, _target.position, 2f * Time.deltaTime);
    }
}
