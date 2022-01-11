using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErasingOptimizator : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthTransfer entity))
        {
            entity.Erase();
        }
    }
}
