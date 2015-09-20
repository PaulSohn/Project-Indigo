using UnityEngine;
using System.Collections;
using System;

public class Missile : Bullet {

    public float searchStartTime = 0.5f;
    public GameObject sight;

    GameObject sightMgr;

    protected override void Start()
    {
        base.Start();
        Invoke("SearchStart", searchStartTime);
    }

    void SearchStart()
    {
        sightMgr = Instantiate(sight, transform.position, transform.rotation) as GameObject;
        sightMgr.transform.parent = transform;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        IHealth healthMgr = collision.transform.GetComponentInParent<IHealth>();
        if (healthMgr != null)
        {
            healthMgr.TakeDamage(10,false);
        }
        Destroy(sightMgr);
        Destroy(gameObject);
    }
	
	void FixedUpdate () {
        //body.velocity = transform.up * body.velocity.magnitude;
	}
}
