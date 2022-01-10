using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New settings", menuName = "Data/SpawnerSettings")]
public class EnemySpawnerSettings
{
    private float _durationSpawn;
    private EnumRandom<EnemyType> enumRandom;

    public float DurationSpawn { get { return _durationSpawn; } }
    public EnemyType Get()
    {
        return enumRandom.Get();
    }

    public void Set(float progress, EnemySpawnerSettingsPreset start, EnemySpawnerSettingsPreset end)
    {
        _durationSpawn = start.DurationSpawn + (end.DurationSpawn - start.DurationSpawn) * progress;
        int count = start.VariantsCount;

        float[] chancesStart = start.Chances;
        float[] chancesEnd = end.Chances;
        float[] chancesNew = new float[count];

        for (int i = 0; i < count; i++)
        {
            chancesNew[i] = chancesStart[i] + (chancesEnd[i] - chancesStart[i]) * progress;
        }
        enumRandom = new EnumRandom<EnemyType>(start.FullChance, chancesNew, start.Results);
    }
}
