using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTransfer : MonoBehaviour
{
    private Entity _entity;

    public void SetTransfer(Entity entity)
    {
        _entity = entity;
    }
    public void Damage(int damage)
    {
        _entity.Damage(damage);
    }
    public void Erase()
    {
        _entity.Death();
    }
}
