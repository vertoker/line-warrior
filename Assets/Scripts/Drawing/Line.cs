using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[RequireComponent(typeof(LineRenderer), typeof(EdgeCollider2D))]
public class Line : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private EdgeCollider2D _edgeCollider;
    private List<Vector2> _points = new List<Vector2>();
    private Vector2 _lastPosition = Vector2.zero;
    private int _counter = 0;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _edgeCollider = GetComponent<EdgeCollider2D>();
    }

    public void DrawPoint(Vector2 position)
    {
        _points.Add(position);
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_counter, position);
        _edgeCollider.SetPoints(_points);
        _lastPosition = position;
        _counter++;
    }
}
