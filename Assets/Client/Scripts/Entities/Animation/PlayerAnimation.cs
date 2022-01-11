using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerAnimation : IAnimation
{
    private EntityObjectRegistrator _registrator;
    private SpriteRenderer _body, _legs;
    private Transform _bodyTransform;
    private Animation _legsAnim;
    private int _startCounter;

    public PlayerAnimation(Transform origin, Animation legsAnim)
    {
        _bodyTransform = origin.GetChild(0);
        _registrator = origin.GetComponent<EntityObjectRegistrator>();
        _body = _bodyTransform.GetComponent<SpriteRenderer>();
        _legs = origin.GetChild(1).GetComponent<SpriteRenderer>();
        _legsAnim = legsAnim;
    }

    public void InitAnimation(int counter)
    {
        _startCounter = counter;
    }
    public void UpdateAnimation(int counter)
    {
        if (_registrator.IsMove)
        {
            _legs.sprite = _legsAnim.GetSprite(counter, _startCounter);
        }
        else
        {
            _legs.sprite = null;
        }
    }
    public void Death()
    {

    }
}
