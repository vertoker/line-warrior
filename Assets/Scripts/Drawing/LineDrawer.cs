using System.Collections;
using Game.Pool;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    private Line _activeUpdater = null;
    private PoolSpawner _poolSpawner;
    private bool beginDrag = false;

    private void Awake()
    {
        _poolSpawner = GetComponent<PoolSpawner>();
    }
    public void SpawnLine(Vector2 position)
    {
        _activeUpdater = _poolSpawner.Dequeue().GetComponent<Line>();
        InputController.DragUpdate += _activeUpdater.DrawPoint;
        beginDrag = true;
    }
    public void StartDestroyLine(Vector2 position)
    {
        if (beginDrag)
        {
            InputController.DragUpdate -= _activeUpdater.DrawPoint;
            //StartCoroutine(ExistTimeDuration(_activeUpdater));
            _activeUpdater = null;
            beginDrag = false;
        }
    }
    /*private IEnumerator ExistTimeDuration(Line updater)
    {
        yield return new WaitForSeconds(lifetime);
        DeleteLine(updater);
    }*/
    private void DeleteLine(Line updater)
    {
        _poolSpawner.Enqueue(updater.gameObject);
    }
}
