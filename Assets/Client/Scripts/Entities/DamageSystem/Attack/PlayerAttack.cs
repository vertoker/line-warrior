using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Pool;

public class PlayerAttack : IAttack
{
    private IWeapon[] _weapons;
    private Transform _player, _projectiles;
    private IWeapon _activeWeapon;

    public PlayerAttack(Transform player, Transform weapon, Transform projectiles)
    {
        _player = player;
        _projectiles = projectiles;
        _weapons = new IWeapon[]
        {
            weapon.GetComponent<MachineGunWeapon>()
        };
        for (int i = 0; i < _weapons.Length; i++)
            ((IPoolSpawnerRequest)_weapons[i]).SetPoolSpawner(projectiles.GetChild(i).GetComponent<PoolSpawner>());
    }

    public void Switch(int id)
    {
        _activeWeapon?.Enabled(false);
        _activeWeapon = _weapons[id];
        _activeWeapon.Enabled(true);
    }
    public void StartAttack(Transform transform)
    {

    }
    public void StopAttack()
    {

    }
}
