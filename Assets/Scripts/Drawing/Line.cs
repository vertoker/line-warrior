using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using Game.Pool;

[RequireComponent(typeof(LineRenderer), typeof(EdgeCollider2D))]
public class Line : MonoBehaviour, IErasing
{
    private LineRenderer _lineRenderer;
    private EdgeCollider2D _edgeCollider;
    private List<Vector2> _points = new List<Vector2>();
    private PoolSpawner _spawner;
    private int _counter = 0;

    private const float LINEWIDTH = 0.25f;

    public void SetSpawner(PoolSpawner spawner)
    {
        _spawner = spawner;
    }

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _edgeCollider = GetComponent<EdgeCollider2D>();
    }

    public void SetPoints(List<Vector2> points)
    {
        _points = points;
        _lineRenderer.positionCount = _counter = points.Count;
        for (int i = 0; i < _counter; i++)
            _lineRenderer.SetPosition(i, _points[i]);
        _edgeCollider.SetPoints(_points);
    }
    public void AddPoint(Vector2 screenPosition, Vector2 worldPosition)
    {
        _points.Add(worldPosition);
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_counter, worldPosition);
        _edgeCollider.SetPoints(_points);
        _counter++;
    }
    public void RemovePoint(int id)
    {
        _counter--;
        if (id == _counter) 
            RemoveLastPoint();
        else if (id == 0) 
            RemoveFirstPoint();
        else
            SplitLine(id);

    }

    private void RemoveLastPoint()
    {
        _points.RemoveAt(_counter);
        _lineRenderer.positionCount--;
        _edgeCollider.SetPoints(_points);
    }
    private void RemoveFirstPoint()
    {
        _points.RemoveAt(0);
        for (int i = 0; i < _counter; i++)
            _lineRenderer.SetPosition(i, _lineRenderer.GetPosition(i + 1));
        _lineRenderer.positionCount--;
        _edgeCollider.SetPoints(_points);
    }
    private void SplitLine(int id)
    {
        List<Vector2> pointsNewLine = _points.GetRange(id + 1, _counter - id);
        _points.RemoveRange(id, _counter - id + 1);

        Line newLine = _spawner.Dequeue().GetComponent<Line>();
        newLine.SetSpawner(_spawner);
        newLine.SetPoints(pointsNewLine);
        SetPoints(_points);
    }

    public bool Erase(Vector2 worldPosition, float brushRadius)
    {
        int counter = 0;
        float minDistance = LINEWIDTH + brushRadius;
        while (counter < _points.Count)
        {
            if (Vector2.Distance(_points[counter], worldPosition) < minDistance)
                RemovePoint(counter);
            else
                counter++;
        }
        return _counter == 0;
    }
    public void Delete()
    {
        _spawner.Enqueue(gameObject);
    }
}
