using UnityEngine;
using System.Collections;

public class SearcherSight : MonoBehaviour {

    public float searchAreaIncrement = 1.0f;

    Missile missile;
    CircleCollider2D sightArea;
    Transform target;

	void Start () {
        missile = GetComponentInParent<Missile>();
        sightArea = GetComponent<CircleCollider2D>();
        sightArea.radius = 0.001f;
	}
	
	void FixedUpdate () {
        
        if (target != null)
        {
            Vector2 displacement = target.transform.position - missile.transform.position;
            float zRotation = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg - 90f;
            missile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));

            /*
            missile.body.velocity = missile.speed * displacement.normalized;
            /*/
            Vector3 newVelocity = missile.body.velocity;
            Vector3.SmoothDamp(missile.transform.position, target.transform.position, ref newVelocity, 0.3f, Mathf.Infinity, Time.fixedDeltaTime);
            //missile.body.velocity = newVelocity;
            missile.body.velocity = missile.speed * newVelocity.normalized;
            //*/

            //missile.transform.LookAt(target, missile.transform.up);
        }
        sightArea.radius += searchAreaIncrement * Time.fixedDeltaTime;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (target == null)
        {
            Debug.Log("Target Found!");
            target = col.transform;
        }
    }
}
