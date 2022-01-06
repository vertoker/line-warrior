using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityScheduler : MonoBehaviour
{
    private IMovement _movementPlayer;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject playerOrigin;
    private EntityExecutor _executor;
    private Transform _parent;

    public GameObject Player { get; private set; }

    private List<Entity> _entities = new List<Entity>();

    private void Awake()
    {
        _parent = transform;
        _executor = GetComponent<EntityExecutor>();

        Player = Instantiate(playerOrigin, _parent);
        _movementPlayer = new MovementToPoint(Player.transform, target);
        Entity playerEntity = new Entity(_movementPlayer);
        EnableEntity(playerEntity);
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
