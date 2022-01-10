using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScheduler : MonoBehaviour
{
    [SerializeField] private StandardZombiesCreator _standardZombies;
    [SerializeField] private BigZombiesCreator _bigZombies;
    [SerializeField] private SmallBossZombiesCreator _smallBossZombies;
    [SerializeField] private BigBossZombiesCreator _bigBossZombies;
    private Dictionary<EnemyType, IEnemyCreator> _converterPresets;

    private void Awake()
    {
        _converterPresets = new Dictionary<EnemyType, IEnemyCreator>()
        {
            { EnemyType.None, null },
            { EnemyType.Tier1_Female1, _standardZombies },
            { EnemyType.Tier1_Female2, _standardZombies },
            { EnemyType.Tier1_Male1, _standardZombies },
            { EnemyType.Tier1_Male2, _standardZombies },
            { EnemyType.Tier2_Army, _standardZombies },
            { EnemyType.Tier2_Cop, _standardZombies },
            { EnemyType.Tier3_BigHands, _bigZombies },
            { EnemyType.Tier3_BigHead, _bigZombies },
            { EnemyType.Tier4_Boss1, _smallBossZombies },
            { EnemyType.Tier4_Boss2, _smallBossZombies },
            { EnemyType.Tier5_MainBoss, _bigBossZombies }
        };
    }

    public Entity InstantiateEnemy(EnemyType type, Vector3 position)
    {
        return _converterPresets[type].CreateEntity(type, position);
    }
}

public enum EnemyType
{
    None = -1, 
    Tier1_Female1 = 0, Tier1_Female2 = 1, Tier1_Male1 = 2, Tier1_Male2 = 3,
    Tier2_Army = 4, Tier2_Cop = 5,
    Tier3_BigHands = 6, Tier3_BigHead = 7,
    Tier4_Boss1 = 8, Tier4_Boss2 = 9,
    Tier5_MainBoss = 10
}
public interface IEnemyCreator
{
    public Entity CreateEntity(EnemyType type, Vector3 position);
}

/// <summary>
/// For 1-2 tier zombies
/// </summary>
[System.Serializable]
public class StandardZombiesCreator : IEnemyCreator
{
    [SerializeField] private Animation tier1_Female1, tier1_Female2;
    [SerializeField] private Animation tier1_Male1, tier1_Male2;
    [SerializeField] private Animation tier2_Army, tier2_Cop;

    public Entity CreateEntity(EnemyType type, Vector3 position)
    {

    }
}
/// <summary>
/// For 3 tier zombies
/// </summary>
[System.Serializable]
public class BigZombiesCreator : IEnemyCreator
{
    [SerializeField] private Animation tier3_BigHands, tier3_BigHead;

    public Entity CreateEntity(EnemyType type, Vector3 position)
    {

    }
}
/// <summary>
/// For 4 tier zombies
/// </summary>
[System.Serializable]
public class SmallBossZombiesCreator : IEnemyCreator
{
    [SerializeField] private Animation tier4_Boss1, tier4_Boss2;

    public Entity CreateEntity(EnemyType type, Vector3 position)
    {

    }
}
/// <summary>
/// For 5 tier BOSS
/// </summary>
[System.Serializable]
public class BigBossZombiesCreator : IEnemyCreator
{
    [SerializeField] private Animation tier5_MainBoss;

    public Entity CreateEntity(EnemyType type, Vector3 position)
    {

    }
}
