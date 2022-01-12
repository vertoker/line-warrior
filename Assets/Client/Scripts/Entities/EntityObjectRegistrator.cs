using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityObjectRegistrator : MonoBehaviour
{
    private Vector3 _lastPosition;
    private Transform _tr;
    private float _moveSpeed;

    private void Awake()
    {
        _tr = transform;
    }
    private void FixedUpdate()
    {
        _moveSpeed = Vector3.Distance(_tr.position, _lastPosition);
        _lastPosition = _tr.position;
    }

    public bool IsMove { get { return _moveSpeed != 0f; } }
    public bool IsSlowMove { get { return _moveSpeed > 0.005f; } }
}
