using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigZombieAttack : IAttack
{
    private IWeapon _fists;
    private Transform _enemy;

    public BigZombieAttack(Transform enemy, Transform weapon)
    {
        _enemy = enemy;
        _fists = weapon.GetComponent<FistsWeapon>();
    }

    public void Switch(int id)
    {

    }
    public void StartAttack()
    {
        _fists.StartAttack();
    }
    public void StopAttack()
    {
        _fists.StopAttack();
    }
}
