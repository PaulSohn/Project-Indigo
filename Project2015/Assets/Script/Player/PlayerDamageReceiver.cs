using UnityEngine;
using System.Collections;

public class PlayerDamageReceiver : MonoBehaviour {

    IHealth healthMgr;

    void Awake() {
        healthMgr = GetComponentInParent<IHealth>();
    }

    void React(Collider2D col) {
        Enemy enemy = col.GetComponentInParent<Enemy>();
        if (enemy != null) {
            healthMgr.TakeDamage(enemy.contactDamage, false);
        }
    }

	void OnTriggerEnter2D(Collider2D col) {
        React(col);
    }

    void OnTriggerStay2D(Collider2D col) {
        React(col);
    }
}
