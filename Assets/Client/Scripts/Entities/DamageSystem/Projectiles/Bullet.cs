using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    private Deactivate _deactivate;
    private Coroutine _coroutine;

    public void SetDelegate(Deactivate deactivate, Coroutine coroutine)
    {
        _deactivate = deactivate;
        _coroutine = coroutine;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthTransfer transfer))
        {
            transfer.Damage(_damage);
        }
    }
}
