using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigZombieAnimation : IAnimation
{
    private EntityObjectRegistrator _registrator;
    private Animation _attack1, _attack2, _attack3, _walk, _death;
    private IAttack _attackAction;
    private SpriteRenderer _renderer;

    private int _startCounter;
    private bool _isDeath = false;
    private bool _lastIsMove = true;

    public BigZombieAnimation(Transform origin, Animation attack1, Animation attack2, Animation attack3, Animation walk, Animation death, IAttack attackAction)
    {
        _registrator = origin.GetComponent<EntityObjectRegistrator>();

        _walk = walk;
        _attack1 = attack1;
        _attack2 = attack2;
        _attack3 = attack3;
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
            _renderer.sprite = _attack1.GetSprite(counter, _startCounter);

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
