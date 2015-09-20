using UnityEngine;
using System.Collections;

public class Riccochet : Bullet {

    void FixedUpdate()
    {
        body.velocity = body.velocity.normalized * speed;
        transform.rotation = Utilities.LookAt(body.velocity);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        IHealth healthMgr = collision.transform.GetComponentInParent<IHealth>();
        if (healthMgr != null)
        {
            healthMgr.TakeDamage(10,false);
        }
    }

}
