using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityObjectRegistrator : MonoBehaviour
{
    private Transform _tr;
    private Vector3 _lastPosition;
    private float _distanceMax;
    private bool _isMove;

    private void Awake()
    {
        _tr = transform;
    }
    private void FixedUpdate()
    {
        _isMove = Vector3.Distance(_tr.position, _lastPosition) != 0f;
        _lastPosition = _tr.position;
        _distanceMax = _lastPosition.sqrMagnitude;
    }

    public bool IsMove { get { return _isMove; } }
    public float ProgressPlayer()
    {
        return _tr.position.sqrMagnitude / _distanceMax;
    }
}
