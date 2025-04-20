using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    [SerializeField] float damage;

    private Animator animator;

    private Vector3 lastPosition;


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

        lastPosition = transform.position;
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

    
    public void Damage()
    {

    }
    void Flip()
    {
        Vector3 directionMovement = transform.position - lastPosition;

        if (directionMovement.x > 0.01f)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z); // Mira a la derecha
        }
        else if (directionMovement.x < -0.01f)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z); // Mira a la izquierda
        }
    }



}
