using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackAim : MonoBehaviour
{
    [SerializeField] private float _distanceRaycast = 50f;
    private Transform _parent, _player;
    private Vector2 _target;
    private ContactFilter2D filter;

    public void SetParent(Transform parent)
    {
        _parent = parent;
        _player = parent.GetChild(0);
        Gizmos.color = Color.red;
    }
    private void Update()
    {
        int count = _parent.childCount;
        for (int i = 1; i < count; i++)
        {
            Vector2 origin = _player.position;
            Vector2 target = _parent.GetChild(i).position;
            RaycastHit2D raycast = Physics2D.Raycast(origin, target, _distanceRaycast, 7);
            //Gizmos.DrawLine(origin, raycast.point);
        }
    }
}
