using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    private IMovement _movement;
    private IAnimation _animation;
    private IAttack _attack;
    private IDeath _death;
    private int _health, _maxHealth;

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

    public Entity(int health, IMovement movement, IAnimation animation, IAttack attack, IDeath death)
    {
        _health = _maxHealth = health;
        _movement = movement;
        _animation = animation;
        _attack = attack;
        _death = death;
    }

    public void Damage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _health = 0;
            _death.Death();
        }
    }
}
