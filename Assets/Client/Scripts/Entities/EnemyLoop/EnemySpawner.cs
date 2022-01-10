using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemySpawnerSettingsPreset _settingsStart;
    [SerializeField] private EnemySpawnerSettingsPreset _settingsEnd;
    [SerializeField] private EnemySpawnerSettings _settingsActive = new EnemySpawnerSettings();
    private EntityObjectRegistrator _playerRegistrator;
    private EnemySpawnField _fieldPosition;
    private EnemyScheduler _scheduler;

    private void Awake()
    {
        _scheduler = GetComponent<EnemyScheduler>();
        _fieldPosition = GetComponent<EnemySpawnField>();
    }
    private void OnEnable()
    {
        StartCoroutine(UpdateDifficulty());
        StartCoroutine(MainLoopSpawn());
    }

    private IEnumerator UpdateDifficulty()
    {
        float progress = _playerRegistrator.ProgressPlayer();
        _settingsActive.Set(progress, _settingsStart, _settingsEnd);
        yield return new WaitForSeconds(10f);
    }

    private IEnumerator MainLoopSpawn()
    {
        yield return new WaitForSeconds(_settingsActive.DurationSpawn);
        EnemyType type = _settingsActive.Get();
        Entity enemy = _scheduler.InstantiateEnemy(type, _fieldPosition.GetPositionSpawn());
    }
}
