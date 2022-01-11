using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIRandomCircleSetter : VersionedMonoBehaviour
{
	[SerializeField] private float _distance;
	private Transform _tr;
	private IAstarAI ai;

	public float Distance { get { return _distance; } }
    protected override void Awake()
	{
		_tr = transform;
	}

	void OnEnable()
	{
		ai = GetComponent<IAstarAI>();
		float angle = Random.Range(-Mathf.PI, Mathf.PI);
		Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
		ai.destination = direction * _distance;
	}

	public float ProgressPlayer()
	{
		return _tr.position.sqrMagnitude / _distance;
	}
}
