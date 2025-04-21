using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{


    [SerializeField] float life;
    private Animator animator;
    private Collider2D collider2d;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        collider2d = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Death();
        }

    }

    public void Death()
    {

        collider2d.isTrigger = true;
        animator.SetTrigger("Death");

    }
}
