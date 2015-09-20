using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float force = 100.0f;
	public float torque = 0.01f;
	public float limitVelocity = 10.0f;
	public float limitAngularVelocity = 60.0f;

	private Rigidbody2D body;
	private CircleCollider2D ccollider;

	void Awake () {
		body = GetComponent<Rigidbody2D> ();
		ccollider = GetComponent<CircleCollider2D> ();
	}

	void Update () {
	
	}

	void FixedUpdate () {
		/*
		BodyMovement ();
		/*/
		TransformMovement ();
		//*/

	}


	#region Moving
	void BodyMovement(){
		body.AddForce (transform.up*Input.GetAxis ("Transformational"));
		body.AddTorque (-torque*Input.GetAxis ("Rotational"));
		
		//clamping
		if(Mathf.Abs (body.angularVelocity)>limitAngularVelocity){
			body.angularVelocity=Mathf.Sign (body.angularVelocity)*limitAngularVelocity;
		}
		if(body.velocity.magnitude>limitVelocity){
			body.velocity=Vector2.ClampMagnitude (body.velocity,limitVelocity);
		}
	}

	void TransformMovement(){

		body.velocity=transform.up*Input.GetAxis ("Transformational")*limitVelocity;
		//transform.Translate (Vector3.up*Input.GetAxis ("Transformational")*limitVelocity*Time.fixedDeltaTime);
		transform.Rotate (0,0,-Input.GetAxis ("Rotational")*limitAngularVelocity*Time.fixedDeltaTime);
	}

	void TransformMovement2(){
		Vector3 direction = new Vector3(Input.GetAxis ("Horizontal"),Input.GetAxis ("Vertical"),0);

		if(direction.magnitude>0){
			body.velocity=Vector3.ClampMagnitude (direction,limitVelocity);
			//transform.Translate (Vector3.ClampMagnitude (direction,limitVelocity*Time.fixedDeltaTime),Space.World);
			transform.rotation=Quaternion.Euler (0,0,-Mathf.Rad2Deg*Mathf.Atan (direction.x/direction.y)+(direction.y<0?180:0));
			Debug.DrawRay (Vector3.zero,direction,Color.red);
		}
	}

	#endregion

	public Vector3 getVelocity(){
		return body.velocity;
	}
}
