using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    [SerializeField] float damage;
    [SerializeField] float life;

    private Animator animator;



    [SerializeField] float velocidad;
    int punto1 = 0;
    [SerializeField] List<GameObject> Points = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if (Points.Count == 0)
        {
            transform.position = Points[0].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Points.Count == 0)
        {
            transform.position = Points[1].transform.position;
        }

        if (Points.Count >= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, Points[punto1].transform.position, velocidad * Time.deltaTime);

            if (transform.position == Points[punto1].transform.position)
            {
                punto1 = (punto1 + 1) % Points.Count;
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
    
    
    public void Damage()
    {

    }
    
    
    public void Death()
    {
        
        
            GameObject.Destroy(gameObject);
        
    }
}
