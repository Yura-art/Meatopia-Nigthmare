using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CombatPvP : MonoBehaviour
{


    [SerializeField] float damage = 5;
    [SerializeField] float dashdamage;
    [SerializeField] float life;


    public Transform damageArea;
    public float attackRadius;

    public Transform dashDamageArea;
    public Vector2  dashAttackSize;
    


    void Start()
    {
        dashdamage = damage * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Damage();
        }
    }

    public void Damage()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(damageArea.position,attackRadius);
        foreach (Collider2D obj in objects)
        {
            if (obj.CompareTag("Enemy"))
            {
                //obj.transform.GetComponent<Enemy1>().TakeDamage(damage);
                obj.transform.GetComponent<EnemyCombat>().TakeDamage(damage);
            }
        }
    }
    
    public void DashDamage()
    {

        Collider2D[] objects = Physics2D.OverlapBoxAll(dashDamageArea.position, dashAttackSize, 0f);
        foreach (Collider2D obj in objects)
        {
            if (obj.CompareTag("Enemy"))
            {
                obj.transform.GetComponent<EnemyCombat>().TakeDamage(damage);

            }
        }
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

        GameObject.Destroy(gameObject);

    }
    private void OnDrawGizmos()
    {
        if (damageArea != null)
        {
            Gizmos.color = Color.red;


            Gizmos.DrawWireSphere(damageArea.position, attackRadius);
        }

        if (dashDamageArea != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(dashDamageArea.position, dashAttackSize);
        }
    }
}
