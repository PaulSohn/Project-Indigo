using UnityEngine;
using System.Collections;


public class Explosion : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        IHealth healthMgr = col.GetComponentInParent<IHealth>();
        if (healthMgr != null)
        {
            healthMgr.TakeDamage(4);
        }
    }

    void ExplosionEnd()
    {
        Destroy(gameObject);
    }
}