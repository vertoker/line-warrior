using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour, IHealthBar
{
    [SerializeField] private RectTransform _bar;

    private void Start()
    {

    }

    public void UpdateBar(float progress)
    {
        _bar.localScale = new Vector3(progress, 1, 1);
    }
}
