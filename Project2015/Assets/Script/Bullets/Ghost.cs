using UnityEngine;
using System.Collections;

public class Ghost : Bullet {

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        //This does nothing
    }

    protected void OnTriggerEnter2D(Collider2D col)
    {
        IHealth healthMgr = col.GetComponentInParent<IHealth>();
        if (healthMgr != null)
        {
            healthMgr.TakeDamage(10,false);
        }
    }

}
