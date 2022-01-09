using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    public void Switch(int id);
    public void StartAttack(Transform transform);
    public void StopAttack();
}
