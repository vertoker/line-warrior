using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class StandardZombieAnimation : IAnimation
{
    private EntityObjectRegistrator _registrator;
    private Animation _walk, _attack, _death;
    private SpriteRenderer _renderer;
    private int _startCounter;
    private bool _isDeath = false;

    public StandardZombieAnimation(Transform origin, Animation walk, Animation attack, Animation death)
    {
        _registrator = origin.GetComponent<EntityObjectRegistrator>();

        _walk = walk;
        _attack = attack;
        _death = death;
        _renderer = origin.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void InitAnimation(int counter)
    {
        _startCounter = counter;
    }
    public void UpdateAnimation(int counter)
    {
        if (_isDeath)
            _renderer.sprite = _death.GetSprite(counter, _startCounter);
        else if (_registrator.IsMove)
            _renderer.sprite = _walk.GetSprite(counter, _startCounter);
        else
            _renderer.sprite = _attack.GetSprite(counter, _startCounter);
    }
    public void Attack()
    {

    }
    public void Death()
    {
        _isDeath = true;
    }
}
