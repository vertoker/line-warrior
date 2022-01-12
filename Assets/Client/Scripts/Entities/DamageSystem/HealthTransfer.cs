using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTransfer : MonoBehaviour
{
    private IHealthBar _healthBar;
    private Entity _entity;

    public void SetHealthBar(IHealthBar healthBar)
    {
        _healthBar = healthBar;
    }
    public void SetTransfer(Entity entity)
    {
        _entity = entity;
        _entity.HealthProgress += _healthBar.UpdateBar;
    }
    private void OnDestroy()
    {
        _entity.HealthProgress -= _healthBar.UpdateBar;
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
