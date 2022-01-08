using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIRandomCircleSetter : VersionedMonoBehaviour
{
	[SerializeField] private float _distance;
	private IAstarAI ai;

	void OnEnable()
	{
		ai = GetComponent<IAstarAI>();
		float angle = Random.Range(-Mathf.PI, Mathf.PI);
		Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
		ai.destination = direction * _distance;
	}
}
