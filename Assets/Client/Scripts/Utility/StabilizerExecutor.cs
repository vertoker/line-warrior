using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class StabilizerExecutor : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] private int stabilizeEventCount = 0;
#endif

    private static List<Transform> _objects = new List<Transform>();
    public static StabilizerExecutor Instance;
    private void Awake()
    {
        Instance = this;
    }

    public static void Add(Transform value)
    {
        _objects.Add(value);
#if UNITY_EDITOR
        Instance.stabilizeEventCount++;
#endif
    }
    public static void Remove(Transform value)
    {
        _objects.Remove(value);
#if UNITY_EDITOR
        Instance.stabilizeEventCount--;
#endif
    }

    private void Update()
    {
        foreach (var item in _objects)
        {
            item.localPosition = Vector3.zero;
            item.eulerAngles = Vector3.zero;
        }
    }
}
