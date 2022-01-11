using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Pool;

public class StandardZombieAttack : IAttack
{
    private IWeapon _fists;
    private Transform _enemy;

    public StandardZombieAttack(Transform enemy, Transform weapon)
    {
        _enemy = enemy;
        _fists = weapon.GetComponent<MachineGunWeapon>();
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
