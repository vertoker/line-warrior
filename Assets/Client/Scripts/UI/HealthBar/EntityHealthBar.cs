using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealthBar : MonoBehaviour, IHealthBar
{
    [SerializeField] private Transform _bar;
    [SerializeField] private HealthTransfer _transfer;

    private void Awake()
    {
        _transfer.SetHealthBar(this);
    }

    public void UpdateBar(float progress)
    {
        _bar.localScale = new Vector3(progress, 1, 1);
        _bar.localPosition = new Vector3(progress / 2f - 0.5f, 0, 0);
    }
}
