using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{


    [SerializeField] float damage;
    [SerializeField] float life;

    private Animator animator;

    public Transform damageArea;
    public float attackRadius;



    [SerializeField] float velocidad;
    void Start()
    {

        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Manejo de animaciones


        Damage();
    }

    public void TakeDamage(float damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Death();
        }

    }

    public void Damage()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(damageArea.position, attackRadius);
        foreach (Collider2D obj in objects)
        {
            if (obj.CompareTag("Player"))
            {
                //obj.transform.GetComponent<Enemy1>().TakeDamage(damage);
                animator.SetTrigger("Attack");

                obj.transform.GetComponent<CombatPvP>().TakeDamage(damage);
            }
        }

    }


    public void Death()
    {


        animator.SetTrigger("Death");

    }

    private void OnDrawGizmos()
    {
        if (damageArea != null)
        {
            Gizmos.color = Color.red;


            Gizmos.DrawWireSphere(damageArea.position, attackRadius);
        }
    }
}
