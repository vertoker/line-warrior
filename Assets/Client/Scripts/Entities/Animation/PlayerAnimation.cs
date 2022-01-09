using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerAnimation : AnimationBehaviour, IAnimation
{
    private SpriteRenderer _legs;
    private Transform _legsTransform;
    private EntityObjectRegistrator _registrator;
    private AIPath _aipath;

    public PlayerAnimation(Transform origin, Animation animation)
    {
        _legsTransform = origin.GetChild(0);
        _aipath = origin.GetComponent<AIPath>();
        _registrator = origin.GetComponent<EntityObjectRegistrator>();
        _legs = _legsTransform.GetComponent<SpriteRenderer>();
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
            _legsTransform.eulerAngles = _aipath.rotation.eulerAngles;
        }
        else
        {
            _legs.sprite = null;
            _legsTransform.eulerAngles = Vector3.zero;
        }
    }
}
