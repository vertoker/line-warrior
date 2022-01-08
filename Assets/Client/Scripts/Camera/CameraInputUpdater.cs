using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

/// <summary>
/// Класс для исправления бага с передвижением камеры и рисованием
/// </summary>
public class CameraInputUpdater : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] private int cameraMoveEventCount = 0;
#endif
    [SerializeField] private float departureTime = 0.25f;
    private bool _isDeparture = false;
    private static UnityEvent<Vector2, Vector2> _cameraMoveEvent = new UnityEvent<Vector2, Vector2>();

    private static CameraInputUpdater Instance;
    private Vector2 _screenPosition;

    public static event UnityAction<Vector2, Vector2> CameraMoveUpdate
    {
        add
        {
            _cameraMoveEvent.AddListener(value);
#if UNITY_EDITOR
            Instance.cameraMoveEventCount++;
#endif
        }
        remove
        {
            _cameraMoveEvent.RemoveListener(value);
#if UNITY_EDITOR
            Instance.cameraMoveEventCount--;
#endif
        }
    }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        InputController.DragUpdate += SaveLastScreenPosition;
        CameraFollower.CameraMoveUpdate += CameraMove;
    }
    private void OnDisable()
    {
        InputController.DragUpdate -= SaveLastScreenPosition;
        CameraFollower.CameraMoveUpdate -= CameraMove;
    }
    private void SaveLastScreenPosition(Vector2 screenPosition, Vector2 worldPosition)
    {
        _screenPosition = screenPosition;
    }
    private void CameraMove()
    {
        if (_isDeparture)
            return;
        _isDeparture = true;
        Vector2 worldPosition = CameraFollower.Instance.ScreenToWorldPoint(_screenPosition);
        _cameraMoveEvent.Invoke(_screenPosition, worldPosition);
        StartCoroutine(Departure());
    }

    private IEnumerator Departure()
    {
        yield return new WaitForSeconds(departureTime);
        _isDeparture = false;
    }
}
