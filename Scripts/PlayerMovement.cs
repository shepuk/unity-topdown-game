using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float moveSpeed;
    public Vector2 forceToApply;
    public Vector2 PlayerInput;
    public float forceDamping;
    public bool canMove = true;

    [SerializeField]
    public PlayerAttack playerAttack;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;

        if (
            Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.x) > .5
            || Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) > .5
        )
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        if (this.GetComponent<Rigidbody2D>().velocity.x < 0 && !playerAttack.IsAttacking)
        {
            gameObject.transform.localScale = new Vector3(-6.5f, 6.5f, 0);
        }
        ;
        if (this.GetComponent<Rigidbody2D>().velocity.x > 0 && !playerAttack.IsAttacking)
        {
            gameObject.transform.localScale = new Vector3(6.5f, 6.5f, 0);
        }
        ;
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            Vector2 moveForce = PlayerInput * moveSpeed;
            moveForce += forceToApply;
            forceToApply /= forceDamping;
            if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
            {
                forceToApply = Vector2.zero;
            }

            rb.velocity = moveForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            // forceToApply += new Vector2(-20, 0);
            // Destroy(collision.gameObject);
        }
    }
}
