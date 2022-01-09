using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public void Enabled(bool enabled);
    public void StartAttack();
    public void StopAttack();
}
