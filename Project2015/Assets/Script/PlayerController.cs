using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(PlayerEngine))]
public class PlayerController : MonoBehaviour, IHealth {

    public int mentalGuage = 100;
    public bool enableMouse = false;
	PlayerEngine engine;

    public void TakeDamage(int damageAmount)
    {
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
		engine = GetComponent<PlayerEngine>();
	}

	void Update () {
        if (enableMouse)
        {
            engine.EngineTranslate(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
            engine.EngineRotateTo(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        else
        {
            engine.EngineMoveForward(Input.GetAxis("Transformational"));
            engine.EngineRotate(Input.GetAxis("Rotational"));
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        
    }
}
