using System.Collections;
using Game.Pool;
using UnityEngine;

public class LineEraser : MonoBehaviour
{
    [SerializeField] private float brushRadius = 1f;
    [SerializeField] private Transform eraserTriggerTransform;
    private CircleCollider2D _eraserTrigger;
    private GameObject _eraserGameObject;
    private PoolSpawner _poolSpawner;

    private void Awake()
    {
        _poolSpawner = GetComponent<PoolSpawner>();
        _eraserGameObject = eraserTriggerTransform.gameObject;
        _eraserTrigger = eraserTriggerTransform.GetComponent<CircleCollider2D>();
        ErasingExecutor.SetBrushRadius(brushRadius);
        _eraserTrigger.radius = brushRadius;
    }

    public void StartSearchPoints(Vector2 screenPosition, Vector2 worldPosition)
    {
        eraserTriggerTransform.position = worldPosition;
        _eraserGameObject.SetActive(true);
        SearchPoints(screenPosition, worldPosition);
    }
    public void SearchPoints(Vector2 screenPosition, Vector2 worldPosition)
    {
        eraserTriggerTransform.position = worldPosition;
    }
    public void StopSearchPoints(Vector2 screenPosition, Vector2 worldPosition)
    {
        _eraserGameObject.SetActive(false);
    }
}
