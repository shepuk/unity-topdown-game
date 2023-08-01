using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField]
    float startDashTime = 1f;

    [SerializeField]
    float dashSpeed = 1f;

    [SerializeField]
    public PlayerMovement playerMovement;

    [SerializeField]
    private TrailRenderer tr;

    Rigidbody2D rb;

    float currentDashTime;

    public float dashDelay = 0.5f;

    public bool canDash = true;
    bool playerCollision = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canDash && Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.x) < .5 
            && Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) < .5) { 
                return;}

            StartCoroutine(Dash(rb.velocity));
        }
    }

    IEnumerator Dash(Vector2 direction)
    {
        canDash = false;
        playerCollision = false;
        currentDashTime = startDashTime; // Reset the dash timer.
        playerMovement.canMove = false;
        tr.emitting = true;

        while (currentDashTime > 0f)
        {
            currentDashTime -= Time.deltaTime; // Lower the dash timer each frame.

            rb.velocity = direction * dashSpeed; // Dash in the direction that was held down.
            // No need to multiply by Time.DeltaTime here, physics are already consistent across different FPS.

            yield return null; // Returns out of the coroutine this frame so we don't hit an infinite loop.
        }

        rb.velocity = new Vector2(0f, 0f); // Stop dashing.

tr.emitting = false;
        playerMovement.canMove = true;

        yield return new WaitForSeconds(dashDelay);

        canDash = true;
        playerCollision = true;
    }
}
