using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public Transform firingLine;
    public float firingDistance;
    public bool shoot;
    public LayerMask playerMask;

    public GameObject bullet;
    public float acrossShoot;
    public float lastShoot;
    public float timeShoot;

    public Animator animator;

    private void Update()
    {
        shoot = Physics2D.Raycast(firingLine.position, transform.right, firingDistance, playerMask);

        if (shoot)
        {
            if (Time.time > acrossShoot + lastShoot) 
            {
                lastShoot = Time.time;
                animator.SetTrigger("Shoot");
                Invoke(nameof(Shoot), timeShoot);
            }

        }
    }


    private void Shoot()
    {
        Instantiate(bullet, firingLine.position, firingLine.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(firingLine.position, firingLine.position + transform.right * firingDistance);


    }
}
