using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class EntityExecutor : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] private int moveEventCount = 0;
    [SerializeField] private int attackEventCount = 0;
#endif

    private UnityEvent _moveEvent = new UnityEvent();
    private UnityEvent _attackEvent = new UnityEvent();
    private static bool _pause = true;

    private void OnEnable()
    {
        _pause = false;
    }
    private void OnDisable()
    {
        _pause = true;
    }

    public event UnityAction MoveUpdate
    {
        add
        {
            _moveEvent.AddListener(value);
#if UNITY_EDITOR
            moveEventCount++;
#endif
        }
        remove
        {
            _moveEvent.RemoveListener(value);
#if UNITY_EDITOR
            moveEventCount--;
#endif
        }
    }
    public event UnityAction AttackUpdate
    {
        add
        {
            _attackEvent.AddListener(value);
#if UNITY_EDITOR
            attackEventCount++;
#endif
        }
        remove
        {
            _attackEvent.RemoveListener(value);
#if UNITY_EDITOR
            attackEventCount--;
#endif
        }
    }

    private void Update()
    {
        if (_pause)
            return;
        _moveEvent.Invoke();
        _attackEvent.Invoke();
    }
}
