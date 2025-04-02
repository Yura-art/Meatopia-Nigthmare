using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontalValue;
    [SerializeField] SpriteRenderer sprt;
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb;
    private bool isGrounded;
    private bool isJumping;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundRadius = 0.2f;

    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    //Variables de dash
    private float originalSpeed;
    private bool isDashing = false;
    private float dashTime;

    //Parametros del dash
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprt = GetComponent<SpriteRenderer>();

        originalSpeed = speed;

    }

    void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalValue * speed, rb.velocity.y);

        // Manejo de animaciones
        anim.SetFloat("Speed", Mathf.Abs(horizontalValue));
        anim.SetFloat("YVelocity", rb.velocity.y);
        anim.SetBool("IsFalling", !isGrounded && rb.velocity.y < 0);
        anim.SetBool("IsDashing", isDashing);

        if (horizontalValue != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontalValue), 1, 1);
        }

        Jump();
        Attack();
        //Flip();
        Dash();
    }
    private void FixedUpdate()
    {
        // Detectar Suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        anim.SetBool("IsGrounded", isGrounded);

        if (isDashing)
        {
            if (Time.time >= dashTime)
            {
                StopDash();
            }
        }
    }
    public void Jump()
    {

        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        //anim.SetBool("IsGrounded", isGrounded);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("Jump");
        }

    }

    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && horizontalValue != 0 && !isDashing)
        {
            StartDash();
        }
    }


    void StartDash()
    {
        isDashing = true;
        dashTime = Time.time + dashDuration;
        speed = dashSpeed;
    }

    void StopDash()
    {
        isDashing = false;
        speed = originalSpeed;
    } 


    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("Attack");

            //reflejar sprite
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        }
    }
    //public void Flip()
    //{
    //    if (horizontalValue > 0 && sprt.flipX == true || horizontalValue < 0 && sprt.flipX == false)
    //    {
    //        sprt.flipX = !sprt.flipX;
    //    }
        
    //}
    private void OnDrawGizmos()
    {
        // Verifica si groundCheck no es nulo
        if (groundCheck != null)
        {
            // Establece el color del Gizmo (puedes cambiarlo si quieres)
            Gizmos.color = Color.red;

            // Dibuja un círculo (WireSphere) en la posición de groundCheck con el radio de detección
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }
    }

}
