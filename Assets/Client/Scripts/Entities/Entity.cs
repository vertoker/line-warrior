using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    private IMovement _movement;

    public IMovement Movement
    {
        get
        {
            return _movement;
        }
    }

    public Entity(IMovement movement)
    {
        _movement = movement;
    }
}
