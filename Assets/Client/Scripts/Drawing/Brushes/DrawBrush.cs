using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBrush : IBrush
{
    private LineDrawer _drawer;

    public DrawBrush(LineDrawer drawer)
    {
        _drawer = drawer;
    }
    public void EnableBrush()
    {
        InputController.BeginDragUpdate += _drawer.SpawnLine;
        InputController.UpUpdate += _drawer.StartDestroyLine;
    }
    public void DisableBrush()
    {
        InputController.BeginDragUpdate -= _drawer.SpawnLine;
        InputController.UpUpdate -= _drawer.StartDestroyLine;
    }
}
