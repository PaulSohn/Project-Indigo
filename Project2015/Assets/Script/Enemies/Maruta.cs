using UnityEngine;
using System.Collections;

public class Maruta : Enemy {

    Animator animator;

	void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (health <= 0)
        {
            animator.SetTrigger("Dead");
        }
    }
}
