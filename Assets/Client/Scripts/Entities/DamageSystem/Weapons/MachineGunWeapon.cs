using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Pool;

public class MachineGunWeapon : MonoBehaviour, IWeapon, IPoolSpawnerRequest
{
    [SerializeField] private float _bulletTemp = 0.25f;
    [SerializeField] private float _timeToDelete = 3f;
    private PoolSpawner _spawnerBullets;
    private List<Coroutine> _bullets = new List<Coroutine>();
    private Coroutine _shootUpdate;

    public void Enabled(bool enabled)
    {
        this.enabled = enabled;
    }
    public void StartAttack()
    {
        _shootUpdate = StartCoroutine(ShootUpdate());
    }
    public void StopAttack()
    {
        StopCoroutine(_shootUpdate);
    }
    public void SetPoolSpawner(PoolSpawner spawner)
    {
        _spawnerBullets = spawner;
    }
    private void Shoot()
    {
        StartCoroutine(BulletBack(_spawnerBullets.Dequeue()));
    }

    private IEnumerator ShootUpdate()
    {
        Shoot();
        yield return new WaitForSeconds(_bulletTemp);
        _shootUpdate = StartCoroutine(ShootUpdate());
    }
    private IEnumerator BulletBack(GameObject item)
    {
        yield return new WaitForSeconds(_timeToDelete);
        _spawnerBullets.Enqueue(item);
    }
}
