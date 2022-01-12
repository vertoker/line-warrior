using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PlayerAttackAim : MonoBehaviour
{
    [SerializeField] private float _distanceRaycast = 100f;
    [SerializeField] private float _timeUpdateClosestEntity = 0.5f;
    [SerializeField] private float _speedRotateLook = 3f;
    [SerializeField] private Transform _body;
    private Transform _parent, _player;
    private Coroutine _updateClosestEntity;
    [SerializeField] private Vector3 _angleTarget;

    private static PlayerAttackAim Instance;
    private UnityEvent<float, Vector2> _angleEvent = new UnityEvent<float, Vector2>();

    public static event UnityAction<float, Vector2> AngleAction
    {
        add => Instance._angleEvent.AddListener(value);
        remove => Instance._angleEvent.RemoveListener(value);
    }

    private void Awake()
    {
        Instance = this;
    }
    public void SetParent(Transform parent)
    {
        _parent = parent;
        _player = parent.GetChild(0);
        Gizmos.color = Color.red;
    }
    private void Start()
    {
        _updateClosestEntity = StartCoroutine(ClosestEntity());
    }
    private IEnumerator ClosestEntity()
    {
        int count = _parent.childCount, ID = 0;
        float minDistance = _distanceRaycast;
        for (int i = 1; i < count; i++)
        {
            Vector2 origin = _player.position;
            Vector2 target = _parent.GetChild(i).position;
            float distance = Vector2.Distance(origin, target);
            if (distance < minDistance)
            {
                minDistance = distance;
                ID = i;
            }
        }
        Vector2 targetAngle = _parent.GetChild(ID).position - _body.position;
        float angle = Mathf.Atan2(targetAngle.y, targetAngle.x) * Mathf.Rad2Deg + 90f;
        _angleTarget = new Vector3(0, 0, angle);

        yield return new WaitForSeconds(_timeUpdateClosestEntity);
        _updateClosestEntity = StartCoroutine(ClosestEntity());
    }
    public void Update()
    {
        _body.rotation = Quaternion.RotateTowards(_body.rotation, Quaternion.Euler(_angleTarget), _speedRotateLook);
        float angle = _body.eulerAngles.z - 180f;
        float angleVector = (angle + 90f) * Mathf.Deg2Rad;
        Vector2 targetAngle = new Vector2(Mathf.Cos(angleVector), Mathf.Sin(angleVector));
        _angleEvent.Invoke(angle, targetAngle);
    }
}
