using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour, IHealthBar
{
    [SerializeField] private RectTransform _bar;
    private HealthTransfer _transfer;

    public void SetTransfer(HealthTransfer transfer)
    {
        _transfer = transfer;
        _transfer.SetHealthBar(this);
    }

    public void UpdateBar(float progress)
    {
        Debug.Log(progress);
        _bar.localScale = new Vector3(progress, 1, 1);
    }
}
