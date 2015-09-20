using UnityEngine;
using System.Collections;

public class Circle : Enemy {
    //Circle is a simple enemy that follows player.
    public float speed;
    
    void Update() {
        body.velocity = speed * (PlayerInfo.playerPosition - transform.position).normalized;
    }

}
