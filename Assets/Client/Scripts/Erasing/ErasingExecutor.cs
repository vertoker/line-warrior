using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ErasingExecutor
{
    private static List<IErasing> _erasings = new List<IErasing>();
    private static float _brushRadius;

    public static void SetBrushRadius(float brushRadius)
    {
        _brushRadius = brushRadius;
    }
    public static void Add(IErasing erasing)
    {
        _erasings.Add(erasing);
    }
    public static void Remove(IErasing erasing)
    {
        _erasings.Remove(erasing);
    }
    public static void Delete(IErasing erasing)
    {
        Remove(erasing);
        erasing.Delete();
    }

    public static void Execute(Vector2 screenPosition, Vector2 worldPosition)
    {
        int counter = 0;
        while (counter < _erasings.Count)
        {
            if (_erasings[counter].Erase(worldPosition, _brushRadius))
                Delete(_erasings[counter]);
            else
                counter++;
        }
    }
}
