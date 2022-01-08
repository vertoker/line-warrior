using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PathfindingUpdater : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    private GridGraph _grid;

    private void Awake()
    {
        _grid = (GridGraph)GetComponent<AstarPath>().graphs[0];
        _grid.center = ConvertIntVector3(_camera.position);
    }
    private void Start()
    {
        _grid.Scan();
    }
    private void Update()
    {
        _grid.center = ConvertIntVector3(_camera.position);
        _grid.Scan();
    }

    private Vector3 ConvertIntVector3(Vector3 vector)
    {
        return new Vector3((int)vector.x, (int)vector.y, (int)vector.z);
    }
}
