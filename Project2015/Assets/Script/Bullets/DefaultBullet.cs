using UnityEngine;
using System.Collections;

public class DefaultBullet : Bullet {

	void Update () {

	}

    protected override void OnCollisionEnter2D(Collision2D collision){

        IHealth healthMgr = collision.transform.GetComponentInParent<IHealth>();
        if (healthMgr != null)
        {
            healthMgr.TakeDamage(10,false);
        }

        Destroy(gameObject);
    }

}
