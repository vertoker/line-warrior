using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    private IMovement _movement;
    private IAnimation _animation;

    public IMovement Movement
    {
        get
        {
            return _movement;
        }
    }
    public IAnimation Animation
    {
        get
        {
            return _animation;
        }
    }

    public Entity(IMovement movement, IAnimation animation)
    {
        _movement = movement;
        _animation = animation;
    }
}
