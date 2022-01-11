using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnField : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _target;
    [SerializeField] private Vector2 _borderCorner;
    [SerializeField] private float _playerDistanceSpawn = 2f;
    
    public Vector3 GetPositionSpawn()
    {
        float x = Random.Range(-_borderCorner.x, _borderCorner.x);
        float y = Random.Range(-_borderCorner.y, _borderCorner.y);
        Vector3 offset = new Vector3(x, y, 0);
        if (x * x + y * y < _playerDistanceSpawn)//2
            offset = offset.normalized * Random.Range(_playerDistanceSpawn, _playerDistanceSpawn * 2);
        return _target.position + offset;
    }
}
