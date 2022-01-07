using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushSwitcher : MonoBehaviour
{
    private IBrush[] _brushes;
    private IBrush _activeBrush;
    [SerializeField] private Transform brushes;
    [SerializeField] private int activeBrushID;

    private void Start()
    {
        _brushes = new IBrush[] 
        {
            new DrawBrush(brushes.GetComponent<LineDrawer>()),
            new EraseBrush(brushes.GetComponent<LineEraser>())
        };
        activeBrushID = 0;
        _activeBrush = _brushes[0];
        _activeBrush.EnableBrush();
    }

    public void Switch(int ID)
    {
        if (activeBrushID == ID)
            return;
        _activeBrush.DisableBrush();
        activeBrushID = ID;
        _activeBrush = _brushes[ID];
        _activeBrush.EnableBrush();
    }
}
