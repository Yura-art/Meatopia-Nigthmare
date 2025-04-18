using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    public float bulletDamage;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        transform.Translate(Time.deltaTime * bulletSpeed * Vector2.right);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out CombatPvP playerLife))
        {
            playerLife.TakeDamage(bulletDamage);

            animator.SetTrigger("Shatter");
            Destroy(gameObject);
        }
    }

}
