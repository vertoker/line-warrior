using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerAnimation : AnimationBehaviour, IAnimation
{
    private SpriteRenderer _legs;
    private Transform _bodyTransform;
    private EntityObjectRegistrator _registrator;
    private AIPath _aipath;

    public PlayerAnimation(Transform origin, Animation animation)
    {
        _bodyTransform = origin.GetChild(0);
        _aipath = origin.GetComponent<AIPath>();
        _registrator = origin.GetComponent<EntityObjectRegistrator>();
        _legs = origin.GetChild(1).GetComponent<SpriteRenderer>();
        BaseInit(origin, animation);
    }

    public void InitAnimation(int counter)
    {
        _startCounter = counter;
    }
    public void UpdateAnimation(int counter)
    {
        if (_registrator.IsMove)
        {
            _legs.sprite = _animation.GetSprite(counter, _startCounter);
        }
        else
        {
            _legs.sprite = null;
        }
    }
}
