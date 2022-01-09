using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EntityScheduler : MonoBehaviour
{
    [SerializeField] private GameObject playerOrigin;
    [SerializeField] private Transform projectiles;
    [SerializeField] private Animation playerAnimation;
    private EntityExecutor _executor;
    private Transform _parent;

    [SerializeField] private Transform _player;
    public GameObject Player { get; private set; }

    private List<Entity> _entities = new List<Entity>();

    private void Awake()
    {
        _parent = transform;
        _executor = GetComponent<EntityExecutor>();
    }
    private void OnEnable()
    {
        Player = Instantiate(playerOrigin, _parent);
        IMovement _movementPlayer = new MovementToPoint(Player.transform);
        IAnimation _animationPlayer = new PlayerAnimation(Player.transform, playerAnimation);
        IAttack _attackPlayer = new PlayerAttack(Player.transform, Player.transform.GetChild(1), projectiles);
        IDeath _deathPlayer = GameLoop.Instance;
        Entity playerEntity = new Entity(1000, _movementPlayer, _animationPlayer, _attackPlayer, _deathPlayer);
        EnableEntity(playerEntity);
        AnimationExecutor.Add(_animationPlayer);
    }
    private void OnDisable()
    {
        DisableAll();
        AnimationExecutor.RemoveAll();
    }

    public void EnableEntity(Entity entity)
    {
        _executor.MoveUpdate += entity.Movement.Move;
        _entities.Add(entity);
    }
    public void DisableEntity(Entity entity)
    {
        _executor.MoveUpdate -= entity.Movement.Move;
        _entities.Remove(entity);
    }
    public void DisableAll()
    {
        int count = _entities.Count;
        for (int i = 0; i < count; i++)
        {
            _executor.MoveUpdate -= _entities[0].Movement.Move;
            _entities.RemoveAt(0);
        }
    }
}