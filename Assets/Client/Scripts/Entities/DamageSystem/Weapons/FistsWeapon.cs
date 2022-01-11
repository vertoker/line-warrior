using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistsWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private float _punchRegistration = 0.1f;
    [SerializeField] private float _punchTemp = 0.25f;
    [SerializeField] private GameObject _punch;
    [SerializeField] private Transform _body;
    private Coroutine _fistUpdate;
    private Vector2 _target = Vector2.zero;
    private Vector3 _angle = Vector3.zero;

    public void Enabled(bool enabled)
    {
        this.enabled = enabled;
    }
    public void StartAttack()
    {
        _fistUpdate = StartCoroutine(FistUpdate());
    }
    public void StopAttack()
    {
        StopCoroutine(_fistUpdate);
    }
    public void LookAt(Vector3 target)
    {
        _target = (target - _body.position).normalized * 50f;
        _body.eulerAngles = _angle = new Vector3(0, 0, Mathf.Atan2(_target.y, _target.x) * Mathf.Rad2Deg + 90f);
    }
    private void Punch()
    {
        _punch.SetActive(true);
        StartCoroutine(FistCancel());
    }

    private IEnumerator FistUpdate()
    {
        yield return new WaitForSeconds(_punchTemp);
        Punch();
    }
    private IEnumerator FistCancel()
    {
        yield return new WaitForSeconds(_punchRegistration);
        _punch.SetActive(false);
    }
}
