using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

[RequireComponent(typeof(PlayerEngine))]
public class PlayerController : MonoBehaviour, IHealth {

    public Animator animator;
    public Slider slider;

    enum Status {
        Idle,
        Damaged,
        Dead
    };
    Status status;

    public int maxMentalGuage = 200;
    int mentalGuage = 200;

    public bool methodAlter = false;
	PlayerEngine engine;

    public float immuneDelay = 1.0f;
    private float lastDamagedTime;
    private bool immune {
        get {
            return Time.time < immuneDelay + lastDamagedTime;
        }
    }

    public void TakeDamage(int damageAmount, bool ignoreImmune)
    {
        if (!ignoreImmune) {
            if (immune) return;
            lastDamagedTime = Time.time;
        }

        mentalGuage -= damageAmount;
        if (mentalGuage < 0) mentalGuage = 0;
    }

    public void TakeDamage(Bullet bullet)
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(Explosion explosion)
    {
        throw new NotImplementedException();
    }

    public int getHealth()
    {
        return mentalGuage;
    }

    void Awake () {
        mentalGuage = maxMentalGuage;
		engine = GetComponent<PlayerEngine>();
        animator = GetComponent<Animator>();

        lastDamagedTime = Time.time - immuneDelay - 1.0f;
	}

	void Update () {
        mentalGuage = Mathf.Min(maxMentalGuage, mentalGuage + PlayerInfo.Benefit.extraMental);
        PlayerInfo.Benefit.extraMental = 0;

        slider.value = (float)mentalGuage / maxMentalGuage;

        if (Input.GetButtonDown("InputSwitch")) {
            methodAlter = !methodAlter;
        }

        if (!methodAlter)
        {
            engine.EngineTranslate(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
            engine.EngineRotateTo(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        else
        {
            engine.EngineMoveForward(Input.GetAxis("Vertical"));
            engine.EngineRotate(Input.GetAxis("Horizontal"));
        }

        if(mentalGuage==0){
            animator.SetInteger("Status", (int)Status.Dead);
        }
        else{
            animator.SetInteger("Status", immune ? (int)Status.Damaged : (int)Status.Idle);
        }
	}
}
