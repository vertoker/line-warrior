using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class MovementToPoint : IMovement
{
    private Transform _origin;
    private AIRandomCircleSetter _setter;

    public MovementToPoint(Transform origin, AIRandomCircleSetter setter)
    {
        _origin = origin;
        _setter = setter;
    }

    public void Move()
    {
        //Добавить pathfinding
        //_origin.position = Vector3.MoveTowards(_origin.position, _target.position, 2f * Time.deltaTime);
    }
}
