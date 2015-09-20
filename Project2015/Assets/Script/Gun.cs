using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public float FireSpeed=10f;
	public float FireDelay=0.5f;
	public bool setRelativeVelocity=false;

    public GameObject[] Ammo;
    int CurrentIndex = 0;

    float ignoreCollisionThreshold = 0.1f;

    private PlayerController controller;
	private PlayerEngine engine;
	private float nextFireTime;

	void Start () {
        controller = transform.parent.GetComponent<PlayerController>();
		engine=transform.parent.GetComponent<PlayerEngine>();
		nextFireTime=Time.time;
	}

	void Update () {
		if((controller.enableMouse?Input.GetMouseButtonDown(0): Time.time > nextFireTime)){
            StartCoroutine("Shoot");
		}
        if (Input.GetButtonDown("WeaponSwitch"))
        {
            ++CurrentIndex;
            if (CurrentIndex == Ammo.Length) CurrentIndex = 0;

            Debug.Log("Now Using : " + Ammo[CurrentIndex].name);
        }
	}

    IEnumerator Shoot()
    {
        if (controller.getHealth() <= 0) yield break;
        controller.TakeDamage(1);

        GameObject bulletInstance = Instantiate(Ammo[CurrentIndex], transform.parent.position, transform.parent.rotation) as GameObject;
        bulletInstance.GetComponent<Rigidbody2D>().velocity = (setRelativeVelocity ? engine.getVelocity() : Vector3.zero) + transform.parent.up * FireSpeed;
        nextFireTime = Time.time + FireDelay;

        Physics2D.IgnoreCollision(engine.col, bulletInstance.GetComponent<Collider2D>());
        yield return new WaitForSeconds(ignoreCollisionThreshold);
        if (bulletInstance != null)
        {
            Physics2D.IgnoreCollision(engine.col, bulletInstance.GetComponent<Collider2D>(), false);
        }
        yield return null;
    }

}
