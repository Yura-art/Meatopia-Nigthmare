using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    public float bulletDamage;


    private void Start()
    {
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

            Destroy(gameObject);
        }
    }

}
