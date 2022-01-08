using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushEraserTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Line line))
        {
            ErasingExecutor.Add(line);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Line line))
        {
            ErasingExecutor.Remove(line);
        }
    }
}
