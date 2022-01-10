using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Pool;

public class MachineGunWeapon : MonoBehaviour, IWeapon, IPoolSpawnerRequest
{
    [SerializeField] private float _bulletTemp = 0.25f;
    [SerializeField] private float _timeToDelete = 3f;
    [SerializeField] private Transform _body, _pointSpawn;
    private PoolSpawner _spawnerBullets;
    private List<Coroutine> _bullets = new List<Coroutine>();
    private Coroutine _shootUpdate;
    private Vector2 _target = Vector2.zero;
    private Vector3 _angle = Vector3.zero;

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
    public void LookAt(Vector3 target)
    {
        _target = (target - _body.position).normalized * 50f;
        _body.eulerAngles = _angle = new Vector3(0, 0, Mathf.Atan2(_target.y, _target.x) * Mathf.Rad2Deg + 90f);
    }
    public void SetPoolSpawner(PoolSpawner spawner)
    {
        _spawnerBullets = spawner;
    }
    private void Shoot()
    {
        GameObject bullet = _spawnerBullets.Dequeue();
        bullet.transform.position = _pointSpawn.position;
        bullet.transform.eulerAngles = _angle;
        bullet.GetComponent<Rigidbody2D>().velocity = _target;
        Deactivate deactivate = new Deactivate(DeactivateBullet);
        bullet.GetComponent<Bullet>().SetDelegate(deactivate, StartCoroutine(BulletBack(bullet)));
    }

    private IEnumerator ShootUpdate()
    {
        Shoot();
        yield return new WaitForSeconds(_bulletTemp);
        _shootUpdate = StartCoroutine(ShootUpdate());
    }
    private void DeactivateBullet(Coroutine coroutine)
    {
        StopCoroutine(coroutine);
    }
    private IEnumerator BulletBack(GameObject item)
    {
        yield return new WaitForSeconds(_timeToDelete);
        _spawnerBullets.Enqueue(item);
    }
}
