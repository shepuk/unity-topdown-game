using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public float Health;

    [SerializeField]
    public float MaxHealth;

    [SerializeField]
    public Slider statusBar;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            Health--;
            UpdateHealth();
            //Debug.Log("attack");
        }
        if (other.CompareTag("PlayerWeapon"))
        {
            Health--;
            UpdateHealth();
            //Debug.Log("attack");
        }
    }

    public void UpdateHealth()
    {
        if (statusBar != null)
        {
            statusBar.value = Health / MaxHealth;
        }
    }
}
