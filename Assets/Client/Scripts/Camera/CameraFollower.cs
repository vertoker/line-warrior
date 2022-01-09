using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] private int cameraMoveEventCount = 0;
#endif
    [SerializeField] private EntityScheduler scheduler;
    //[SerializeField] private Transform target;

    public static CameraFollower Instance;
    private Transform _cameraTransform, _player;
    private Vector2 _targetWatch;
    private Camera _camera;
    private UnityEvent _cameraMoveEvent = new UnityEvent();

    [Header("Params")]
    //[SerializeField] private float size = 3f;
    [SerializeField] [Range(0f, 1f)] private float f = 0.1f;


    public static event UnityAction CameraMoveUpdate
    {
        add
        {
            Instance._cameraMoveEvent.AddListener(value);
#if UNITY_EDITOR
            Instance.cameraMoveEventCount++;
#endif
        }
        remove
        {
            Instance._cameraMoveEvent.RemoveListener(value);
#if UNITY_EDITOR
            Instance.cameraMoveEventCount--;
#endif
        }
    }

    private void Awake()
    {
        Instance = this;
        _camera = GetComponent<Camera>();
        _cameraTransform = transform;
    }
    private void OnEnable()
    {
        _player = scheduler.Player.transform;
    }
    private void Update()
    {
        _targetWatch = _player.position;
        /*if (TransformInCameraView(target))
            _targetWatch = (_player.position + target.position) / 2f;
        else
            _targetWatch = _player.position + (target.position - _player.position).normalized * size;*/

        Vector3 nextPosition = Vector3.Lerp(_cameraTransform.position, _targetWatch, f);
        if (_cameraTransform.position != nextPosition) 
        {
            _cameraMoveEvent.Invoke();
            _cameraTransform.position = nextPosition;
        }
    }

    public Vector2 ScreenToWorldPoint(Vector2 screenPosition)
    {
        return _camera.ScreenToWorldPoint(screenPosition);
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
