using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushSwitcher : MonoBehaviour
{
    private IBrush[] _brushes;
    private IBrush _activeBrush;
    private int _activeBrushID;

    private void Start()
    {
        _brushes = new IBrush[] 
        {
            new DrawBrush(gameObject.GetComponent<LineDrawer>()),
            new EraseBrush(gameObject.GetComponent<LineEraser>())
        };
        _activeBrushID = 0;
        _activeBrush = _brushes[0];
        _activeBrush.EnableBrush();
    }

    public void Switch(int ID)
    {
        if (_activeBrushID == ID)
            return;
        _activeBrush.DisableBrush();
        _activeBrushID = ID;
        _activeBrush = _brushes[ID];
        _activeBrush.EnableBrush();
        print(ID);
    }
}
