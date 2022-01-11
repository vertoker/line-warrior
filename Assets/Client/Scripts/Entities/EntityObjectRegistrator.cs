using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityObjectRegistrator : MonoBehaviour
{
    private Vector3 _lastPosition;
    private Transform _tr;
    private bool _isMove;

    private void Awake()
    {
        _tr = transform;
    }
    private void FixedUpdate()
    {
        _isMove = Vector3.Distance(_tr.position, _lastPosition) != 0f;
        _lastPosition = _tr.position;
    }

    public bool IsMove { get { return _isMove; } }
}
