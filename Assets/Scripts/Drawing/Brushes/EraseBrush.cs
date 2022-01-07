using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseBrush : IBrush
{
    private LineEraser _eraser;

    public EraseBrush(LineEraser eraser)
    {
        _eraser = eraser;
    }
    public void EnableBrush()
    {
        InputController.DownUpdate += _eraser.StartSearchPoints;
        InputController.DragUpdate += _eraser.SearchPoints;
        InputController.DragUpdate += ErasingExecutor.Execute;
        InputController.UpUpdate += _eraser.StopSearchPoints;
    }
    public void DisableBrush()
    {
        InputController.DownUpdate -= _eraser.StartSearchPoints;
        InputController.DragUpdate -= _eraser.SearchPoints;
        InputController.DragUpdate -= ErasingExecutor.Execute;
        InputController.UpUpdate -= _eraser.StopSearchPoints;
    }
}
