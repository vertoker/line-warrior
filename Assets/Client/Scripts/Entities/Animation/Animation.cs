using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Animation", menuName = "Data/Animation", order = 0)]
public class Animation : ScriptableObject
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private int _frameLength = 3;

    public Sprite GetSprite(int counter, int startCounter)
    {
        int offsetCounter = (counter - startCounter) / _frameLength;
        return _sprites[offsetCounter % _sprites.Length];
    }
}