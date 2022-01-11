using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EntityScheduler : MonoBehaviour
{
    [SerializeField] private GameObject playerOrigin;
    [SerializeField] private Transform projectiles;
    [SerializeField] private Animation playerAnimation;
    private static EntityExecutor _executor;
    private Transform _parent;

    [SerializeField] private Transform _player;
    private PlayerAttackAim _playerAttackAim;
    public static GameObject Player { get; private set; }

    private static List<Entity> _entities = new List<Entity>();
    public static int CountEntities { get { return _entities.Count; } }

    private void Awake()
    {
        _parent = transform;
        _executor = GetComponent<EntityExecutor>();
    }
    private void OnEnable()
    {
        Player = Instantiate(playerOrigin, _parent);
        _playerAttackAim = Player.GetComponent<PlayerAttackAim>();
        _playerAttackAim.SetParent(_parent);
        IMovement movementPlayer = new MovementToPoint(Player.transform);
        IAnimation animationPlayer = new PlayerAnimation(Player.transform, playerAnimation);
        IAttack attackPlayer = new PlayerAttack(Player.transform, Player.transform.GetChild(2), projectiles);
        Death deathPlayer = GameLoop.DeathPlayer;
        HealthTransfer transfer = Player.GetComponent<HealthTransfer>();
        Entity playerEntity = new Entity(1000, movementPlayer, animationPlayer, attackPlayer, deathPlayer, transfer, Player);
        EnableEntity(playerEntity);
        AnimationExecutor.Add(animationPlayer);
    }
    private void OnDisable()
    {
        DisableAll();
        AnimationExecutor.RemoveAll();
    }

    public static void EnableEntity(Entity entity)
    {
        _executor.MoveUpdate += entity.Movement.Move;
        _entities.Add(entity);
    }
    public static void DisableEntity(Entity entity)
    {
        _executor.MoveUpdate -= entity.Movement.Move;
        _entities.Remove(entity);
    }
    public static void DisableAll()
    {
        int count = _entities.Count;
        for (int i = 0; i < count; i++)
        {
            _executor.MoveUpdate -= _entities[0].Movement.Move;
            _entities.RemoveAt(0);
        }
    }
}
