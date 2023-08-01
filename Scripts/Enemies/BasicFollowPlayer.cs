using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFollowPlayer : MonoBehaviour
{
    public float speed = 3.5f;

    public GameObject player;

    private bool activated = false;

    void Start()
    {
        transform.Rotate(0, 0, 0);
    }

    void Update()
    {
        if (activated)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.transform.position,
                speed * Time.deltaTime
            );
        }
    }

    void OnBecameVisible()
    {
        activated = true;
    }
}
