using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnumRandom<T>
{
    [SerializeField] private readonly float _max;
    [SerializeField] private readonly float[] _chances;
    [SerializeField] private readonly T[] _results;

    public EnumRandom(float max, float[] changes, T[] results)
    {
        _max = max;
        _chances = changes;
        _results = results;
    }

    public T Get()
    {
        float num = Random.Range(0, _max);
        float counter = 0;
        for (int i = 0; i < _chances.Length; i++)
        {
            if (num < counter)
                return _results[i];
            else
                counter += _chances[i];
        }
        return _results[_chances.Length - 1];
    } 
}