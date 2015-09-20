using UnityEngine;
using System;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

    static PlayerEngine player;
    public static Vector3 playerPosition {
        get {
            if (player == null) {
                throw new NullReferenceException();
            }
            return player.transform.position;
        }
    }
    public static class Benefit {
        public static int score = 0;
        public static int extraMental = 0;
    }

    void Start () {
        player = (PlayerEngine)FindObjectOfType(typeof(PlayerEngine));
	}
	
	void FixedUpdate () {
	    
	}
}
