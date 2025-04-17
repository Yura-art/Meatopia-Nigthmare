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

    public Rigidbody2D rb;

    //Variables de tiempo de ataque
    [SerializeField] private float timeAcross;
    [SerializeField] private float timeNextAtttack;

    //variables de seguimiento
    [SerializeField] float velocidad;
    public float maxDistance;
    public Vector3 initialPoint;

    public float searchArea;
    public LayerMask player;
    public Transform playerTransform;

    public bool lookRight;

    //Maquina de estados basica e improvisada

    public MovementStates actualState;

    public enum MovementStates
    {
        Wait,
        Follow,
        Back,
    }

    void Start()
    {

        animator = GetComponent<Animator>();
        initialPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        switch (actualState)
        {
            case MovementStates.Wait:
                WaitState();
                break;

            case MovementStates.Follow:
                FollowState();
                break;

            case MovementStates.Back:
                BackState();
                break;
        }




        //Manejo de ataque y animaciones
        if (timeNextAtttack > 0)
        {
            timeNextAtttack -= Time.deltaTime;
        }

        if (timeNextAtttack <= 0)
        {
            Hit();
            timeNextAtttack = timeAcross;
        }
    }


    private void WaitState()
    {

        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, searchArea, player);

        if (playerCollider)
        {
            playerTransform = playerCollider.transform;

            actualState = MovementStates.Follow;
        }
    }

    private void FollowState()
    {
        animator.SetBool("IsRunning", true);

        if (playerTransform == null)
        {
            actualState = MovementStates.Back;
            return;
        }

        if (transform.position.x < playerTransform.position.x)
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
        }

        FlipToTarget(playerTransform.position);

        if (Vector2.Distance(transform.position, initialPoint) > maxDistance || Vector2.Distance(transform.position, playerTransform.position) > maxDistance)
        {
            actualState = MovementStates.Back;
            playerTransform = null;
        }
    }

    private void BackState()
    {
        if (transform.position.x < initialPoint.x)
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
        }

        FlipToTarget(initialPoint);

        if (Vector2.Distance(transform.position, initialPoint) < 0.1f)
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("IsRunning", false);
            actualState = MovementStates.Wait;
        }
    }

    public void Hit()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(damageArea.position, attackRadius);
        foreach (Collider2D obj in objects)
        {
            if (obj.CompareTag("Player"))
            {
                CombatPvP player = obj.transform.GetComponent<CombatPvP>();
                if (player != null)
                {
                    rb.velocity = Vector2.zero;

                    animator.SetTrigger("Attack");
                    player.TakeDamage(damage);
                }
            }
        }

    }


    private void FlipToTarget(Vector3 target)
    {
        if (target.x > transform.position.x && !lookRight)
        {
            Flip();
        }
        else if (target.x < transform.position.x && lookRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        lookRight = !lookRight;

        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + 180, 0f);
    }

    private void OnDrawGizmos()
    {
        if (damageArea != null)
        {
            Gizmos.color = Color.red;


            Gizmos.DrawWireSphere(damageArea.position, attackRadius);
        }


        Gizmos.color = Color.red;


        Gizmos.DrawWireSphere(transform.position, searchArea);
        Gizmos.DrawWireSphere(initialPoint, maxDistance);

    }
}
