using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBob : MonoBehaviour
{
    // Use this for initialization
    private float speed = 5;
    private float maxRotAngleZ = 7;
    private float minRotAngleZ = -7;
    private bool isMoving = false;

    public Rigidbody2D rb;

    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude >= 0.01f)
        {
            isMoving = true;
            float rZ = Mathf.SmoothStep(
                minRotAngleZ,
                maxRotAngleZ,
                Mathf.PingPong(Time.time * speed, 1)
            );
            transform.rotation = Quaternion.Euler(0, 0, rZ);
        }
        else
        {
            isMoving = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
