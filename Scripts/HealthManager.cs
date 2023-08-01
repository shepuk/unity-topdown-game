using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    public Player player;

    [SerializeField]
    public HealthBar healthBar;

    public float totalHealth = 5;
    public float remainingHealth = 3;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            remainingHealth--;
            healthBar.UpdateHealth();
        }
    }
}
