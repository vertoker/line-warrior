using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabilizing : MonoBehaviour
{
    private Transform _tr;
    private void Awake()
    {
        _tr = transform;
    }
    private void OnEnable()
    {
        StabilizerExecutor.Add(_tr);
    }
    private void OnDisable()
    {
        StabilizerExecutor.Remove(_tr);
    }
}
