using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public void Enabled(bool enabled);
    public void StartAttack();
    public void StopAttack();
    public void LookAt(Vector3 target);
}
public delegate void Deactivate(Coroutine coroutine);