using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _maxEntities = 30;
    [SerializeField] private EnemySpawnerSettingsPreset _settingsStart;
    [SerializeField] private EnemySpawnerSettingsPreset _settingsEnd;
    [SerializeField] private EnemySpawnerSettings _settingsActive = new EnemySpawnerSettings();
    private Coroutine _settingsCoroutine, _spawnCoroutine;
    private AIRandomCircleSetter _setter;
    private EnemySpawnField _fieldPosition;
    private EnemyScheduler _scheduler;

    private static Death _enemyDeath;
    public static Death EnemyDeath { get { return _enemyDeath; } }

    private void Awake()
    {
        _scheduler = GetComponent<EnemyScheduler>();
        _fieldPosition = GetComponent<EnemySpawnField>();
        _enemyDeath = Death;
    }
    private void OnEnable()
    {
        _setter = EntityScheduler.Player.GetComponent<AIRandomCircleSetter>();
        SetSettings();
        _settingsCoroutine = StartCoroutine(UpdateDifficulty());
        _spawnCoroutine = StartCoroutine(MainLoopSpawn());
    }
    private void OnDisable()
    {
        StopCoroutine(_settingsCoroutine);
        StopCoroutine(_spawnCoroutine);
    }

    private IEnumerator UpdateDifficulty()
    {
        yield return new WaitForSeconds(10f);
        SetSettings();
        _settingsCoroutine = StartCoroutine(UpdateDifficulty());
    }
    private IEnumerator MainLoopSpawn()
    {
        yield return new WaitForSeconds(_settingsActive.DurationSpawn);
        if (EntityScheduler.CountEntities < _maxEntities)
        {
            EnemyType type = _settingsActive.Get();
            Entity enemy = _scheduler.InstantiateEnemy(type, _fieldPosition.GetPositionSpawn());
            EntityScheduler.EnableEntity(enemy);
            AnimationExecutor.Add(enemy.Animation);
        }
        _spawnCoroutine = StartCoroutine(MainLoopSpawn());
    }
    private void SetSettings()
    {
        float progress = _setter.ProgressPlayer();
        _settingsActive.Set(progress, _settingsStart, _settingsEnd);
    }
    private void Death(Entity entity)
    {
        //Debug.Log("Death");
        EntityScheduler.DisableEntity(entity);
        AnimationExecutor.Remove(entity.Animation);
        Destroy(entity.Obj);
    }
}
