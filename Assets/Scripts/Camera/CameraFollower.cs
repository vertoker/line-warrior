using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private EntityScheduler scheduler;
    [SerializeField] private Transform target;
    private Transform _cameraTransform, _player;
    private Camera _camera;
    private Vector2 _targetWatch;

    [Header("Params")]
    [SerializeField] private float size = 3f;
    [SerializeField] [Range(0f, 1f)] private float f = 0.1f;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _cameraTransform = transform;
    }
    private void Start()
    {
        _player = scheduler.Player.transform;
    }
    private void Update()
    {
        if (TransformInCameraView(target))
            _targetWatch = (_player.position + target.position) / 2f;
        else
            _targetWatch = _player.position + (target.position - _player.position).normalized * size;

        Vector3 nextPosition = Vector3.Lerp(_cameraTransform.position, _targetWatch, f);
        if (_cameraTransform.position != nextPosition) 
        {
            //_inputController.OnDrag();
            _cameraTransform.position = nextPosition;
        }
    }


    private bool TransformInCameraView(Transform target)
    {
        Vector2 cameraPosition = _cameraTransform.position;
        Vector2 targetPosition = target.position;
        Vector2 cameraPoint = GetCameraPoint();
        Vector2 maxPoint = cameraPosition + cameraPoint;
        Vector2 minPoint = cameraPosition - cameraPoint;

        bool minX = targetPosition.x < minPoint.x;
        bool maxX = targetPosition.x > maxPoint.x;
        bool minY = targetPosition.y < minPoint.y;
        bool maxY = targetPosition.y > maxPoint.y;
        return !(minX || maxX || minY || maxY);
    }
    private Vector2 GetCameraPoint()
    {
        return new Vector2(_camera.orthographicSize * _camera.aspect, _camera.orthographicSize);
    }
}
