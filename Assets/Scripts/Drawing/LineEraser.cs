using System.Collections;
using Game.Pool;
using UnityEngine;

public class LineEraser : MonoBehaviour
{
    [SerializeField] private float brushRadius = 30f;
    private PoolSpawner _poolSpawner;

    private void Awake()
    {
        _poolSpawner = GetComponent<PoolSpawner>();
    }

    public void StartSearchPoints(Vector2 position)
    {

    }
    public void StopSearchPoints(Vector2 position)
    {

    }
}
