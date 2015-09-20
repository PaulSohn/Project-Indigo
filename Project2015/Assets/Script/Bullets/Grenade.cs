using UnityEngine;
using System.Collections;
using System;

public class Grenade : Bullet
{
    public GameObject explosion;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
