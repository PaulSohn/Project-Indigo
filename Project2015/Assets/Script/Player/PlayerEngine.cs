using UnityEngine;
using System.Collections;

public class PlayerEngine : MonoBehaviour {
	
	public float limitVelocity = 10.0f;
	public float limitAngularVelocity = 60.0f;

	private Rigidbody2D body;
	public CircleCollider2D col{ get; private set; }

	void Awake () {
		body = GetComponent<Rigidbody2D> ();
		col = GetComponentInChildren<CircleCollider2D> ();
	}

    public void EngineMoveForward(float val)
    {
        //transform.Translate(transform.up * val * limitVelocity * Time.deltaTime);
        body.velocity = transform.up * val * limitVelocity;
    }

    public void EngineTranslate(Vector2 dir)
    {
        body.velocity = 0.707f * dir * limitVelocity;
    }

    public void EngineRotate(float val)
    {
        transform.Rotate(0, 0, -val * limitAngularVelocity * Time.deltaTime);
    }

    public void EngineRotateTo(Vector3 position)
    {
        Vector3 displacement = position - transform.position;
        float zRotation = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));
    }
	
	public Vector3 getVelocity(){
		return body.velocity;
	}
}
