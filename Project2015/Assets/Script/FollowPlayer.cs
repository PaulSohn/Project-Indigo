using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public Vector3 displacement;

	private Transform player;
	
	void Awake () {
		displacement=new Vector3(0,0,0);
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void FixedUpdate () {
		transform.position=player.position+displacement;


	}
}
