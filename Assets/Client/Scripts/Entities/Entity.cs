using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Entity
{
    private IMovement _movement;
    private IAnimation _animation;
    private IAttack _attack;
    private Death _death;

    private int _health, _maxHealth;
    private GameObject _obj;
    private UnityEvent<float> _healthProgressEvent = new UnityEvent<float>();

    public event UnityAction<float> HealthProgress
    {
        add => _healthProgressEvent.AddListener(value);
        remove => _healthProgressEvent.RemoveListener(value);
    }

    public GameObject Obj
    {
        get
        {
            return _obj;
        }
    }
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

    public Entity(int health, IMovement movement, IAnimation animation, IAttack attack, Death death, HealthTransfer transfer, GameObject obj)
    {
        _health = _maxHealth = health;
        _movement = movement;
        _animation = animation;
        _attack = attack;
        _death = death;
        _obj = obj;
        transfer.SetTransfer(this);
    }

    public void Damage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _health = 0;
            Death();
        }
        //Debug.Log(_health);
    }
    public void Death() 
    {
        _death?.Invoke(this);
    }
}
