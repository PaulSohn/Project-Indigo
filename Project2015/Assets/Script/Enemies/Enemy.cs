using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour, IHealth {

    public int health = 80;

    public int getHealth()
    {
        return health;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0) health = 0;
    }

    void PreishStart()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    void Perish()
    {
        Destroy(gameObject);
    }
}
