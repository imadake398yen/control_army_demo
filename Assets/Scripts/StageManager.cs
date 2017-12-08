using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StageManager : SingletonMonoBehaviour<StageManager> {

	[SerializeField] private GameObject behindPointPrefab;
	private List<GameObject> behindObj, obstacles;
	private Player player; 

	void Start () {
		player = Player.instance;
		obstacles = GameObject.FindGameObjectsWithTag("Obstacle").ToList();
		behindObj = new List<GameObject>();
		foreach(var o in obstacles) {
			var b = Instantiate(behindPointPrefab);
			behindObj.Add(b);
		}
	}
	
	void Update () {
		int i = 0;
		foreach(var o in obstacles) {
			var pos = o.transform.position 
				+ (o.transform.position - player.transform.position).normalized * 5;
			behindObj[i].transform.position = pos;
			i += 1;
		}
	}

	// 近場の隠れるところを返す関数
	public Vector3 GetNearestPoint (Transform target) {
		var point = behindObj[0].transform.position;
		float nearestDistance = Vector3.Distance(point, target.position);
		for(int i = 1; i < behindObj.Count; i++) {
			var dist = Vector3.Distance(behindObj[i].transform.position, target.position);
			if (dist < nearestDistance) {
				point = behindObj[i].transform.position;
			}
		}
		return point;
	}

}
