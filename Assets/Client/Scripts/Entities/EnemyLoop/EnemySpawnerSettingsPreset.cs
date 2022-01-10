using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New settings", menuName = "Data/SpawnerSettings")]
public class EnemySpawnerSettingsPreset : ScriptableObject
{
    [SerializeField] private float _durationSpawn = 0.1f;
    [SerializeField] private float[] _changes;
    [SerializeField] private EnemyType[] _results;
    [SerializeField] private float _fullChance;

    public float DurationSpawn { get { return _durationSpawn; } }
    public int VariantsCount { get { return _changes.Length; } }
    public float[] Chances { get { return _changes; } }
    public EnemyType[] Results { get { return _results; } }
    public float FullChance { get { return _fullChance; } }
}
