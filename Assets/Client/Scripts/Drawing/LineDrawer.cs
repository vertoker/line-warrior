using System.Collections;
using Game.Pool;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    private Line _activeLine = null;
    [SerializeField] private PoolSpawner poolSpawner;
    private bool beginDrag = false;

    public void SpawnLine(Vector2 screenPosition, Vector2 worldPosition)
    {
        _activeLine = poolSpawner.Dequeue().GetComponent<Line>();
        _activeLine.SetSpawner(poolSpawner);
        InputController.DragUpdate += _activeLine.AddPoint;
        CameraInputUpdater.CameraMoveUpdate += _activeLine.AddPoint;
        beginDrag = true;
    }
    public void StartDestroyLine(Vector2 screenPosition, Vector2 worldPosition)
    {
        if (beginDrag)
        {
            InputController.DragUpdate -= _activeLine.AddPoint;
            CameraInputUpdater.CameraMoveUpdate -= _activeLine.AddPoint;
            //StartCoroutine(ExistTimeDuration(_activeUpdater));
            _activeLine = null;
            beginDrag = false;
        }
    }
}
