using UnityEngine;
using System.Collections;

public abstract class Bullet : MonoBehaviour {

    public float AutoDestroyTime = 5.0f;
    public int damage = 1;

    public float speed = 20.0f;

    public Rigidbody2D body { get; private set; }

    protected abstract void OnCollisionEnter2D(Collision2D collision);

    protected void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        Destroy(gameObject, AutoDestroyTime);
    }

}
