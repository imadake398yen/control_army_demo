using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	public BoxCollider boxCollider;

	private NavMeshAgent navMeshAgent;
	private Vector3 targetPoint;

	IEnumerator Start () {
		boxCollider = GetComponent<BoxCollider>();
		navMeshAgent = GetComponent<NavMeshAgent>();
		while (true) {
			yield return new WaitForSeconds(0.1f);
			targetPoint = StageManager.instance.GetNearestPoint(transform);
		}
	}

	void Update () {
		navMeshAgent.SetDestination(targetPoint);

		if (Input.GetKeyDown(KeyCode.Space)) {
			boxCollider.enabled = !boxCollider.enabled;
		}
	}
	
}
