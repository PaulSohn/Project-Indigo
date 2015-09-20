using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour, IHealth {

    public enum Orientation {
        Rotate,
        LookAtPlayer
    };

    protected Animator animator;
    protected Rigidbody2D body;
    public float angularSpeed = 0;
    public Orientation orientation;

    public int health = 80;
    public int contactDamage = 8;

    public int profit = 20;
    public int score = 100;

    void Start() {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        if (orientation == Orientation.Rotate) {
            body.angularVelocity = angularSpeed;
        }
    }

    protected virtual void FixedUpdate() {
        if (health <= 0) {
            animator.SetTrigger("Dead");
            body.velocity = Vector2.zero;
            body.angularVelocity = 0;
            return;
        }
        if (orientation == Orientation.LookAtPlayer) {
            transform.rotation = Utilities.LookAt(PlayerInfo.playerPosition - transform.position);
        }
    }

    public int getHealth()
    {
        return health;
    }

    public void TakeDamage(int damageAmount, bool ignoreImmune)
    {
        //ignoreImmune은 아직 필요없는것같다.
        health -= damageAmount;
        if (health < 0) health = 0;
    }

    protected virtual void PerishStart()
    {
        PlayerInfo.Benefit.score += score;
        PlayerInfo.Benefit.extraMental += profit;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    void Perish()
    {
        Destroy(gameObject);
    }
}
