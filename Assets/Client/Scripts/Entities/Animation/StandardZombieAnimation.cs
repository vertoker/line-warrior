using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class StandardZombieAnimation : IAnimation
{
    private EntityObjectRegistrator _registrator;
    private Animation _walk, _attack, _death;
    private IAttack _attackAction;
    private SpriteRenderer _renderer;

    private int _startCounter;
    private bool _isDeath = false;
    private bool _lastIsMove = true;

    public StandardZombieAnimation(Transform origin, Animation walk, Animation attack, Animation death, IAttack attackAction)
    {
        _registrator = origin.GetComponent<EntityObjectRegistrator>();

        _walk = walk;
        _attack = attack;
        _death = death;
        _renderer = origin.GetChild(0).GetComponent<SpriteRenderer>();
        _attackAction = attackAction;
    }

    public void InitAnimation(int counter)
    {
        _startCounter = counter;
    }
    public void UpdateAnimation(int counter)
    {
        if (_isDeath)
            _renderer.sprite = _death.GetSprite(counter, _startCounter);
        else if (_registrator.IsSlowMove)
            _renderer.sprite = _walk.GetSprite(counter, _startCounter);
        else
            _renderer.sprite = _attack.GetSprite(counter, _startCounter);

        if (_lastIsMove != _registrator.IsSlowMove)
        {
            Debug.Log(_lastIsMove);
            if (_lastIsMove == true)
                _attackAction.StartAttack();
            else
                _attackAction.StopAttack();
            _lastIsMove = _registrator.IsMove;
        }
    }
    public void Death()
    {
        _isDeath = true;
    }
}
