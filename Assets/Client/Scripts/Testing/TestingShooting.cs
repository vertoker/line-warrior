using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingShooting : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private MachineGunWeapon machineGun;


    private void Start()
    {
        machineGun = EntityScheduler.Player.transform.GetChild(2).GetComponent<MachineGunWeapon>();
    }

    private void Update()
    {
        Vector2 position = _camera.ScreenToWorldPoint(Input.mousePosition);
        machineGun.LookAt(position);
        if (Input.GetMouseButtonDown(1))
        {
            machineGun.StartAttack();
        }
        if (Input.GetMouseButtonUp(1))
        {
            machineGun.StopAttack();
        }
    }
}
