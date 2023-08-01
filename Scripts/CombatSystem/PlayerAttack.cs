using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    public GameObject Weapon;

    [SerializeField]
    public GameObject AimIndicator;

    public PlayerMovement playerMovement;

    public Animator animator;

    public bool CanAttack = true;
    public bool IsAttacking;

    //float yVelocity = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Weapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q") && CanAttack)
        {
            Weapon.SetActive(true);

            IsAttacking = true;
            //animator.SetBool("IsAttacking", true);

            StartCoroutine(AttackWithWeapon());
        }

        if (Input.GetKeyUp("q"))
        {
            IsAttacking = false;
        }

        // if (IsAttacking)
        // {
        //     float Angle = Mathf.SmoothDampAngle(
        //         Weapon.transform.eulerAngles.z,
        //         -70,
        //         ref yVelocity,
        //         0.09f
        //     );
        //     Weapon.transform.rotation = Quaternion.Euler(0, 0, Angle);
        // }
    }

    private IEnumerator AttackWithWeapon()
    {
        CanAttack = false;
        playerMovement.moveSpeed = 1.5f;

        yield return new WaitForSeconds(0.2F);
        playerMovement.moveSpeed = 7.0f;

        Weapon.SetActive(false);

        yield return new WaitForSeconds(0.3F);

        playerMovement.moveSpeed = 7.0f;
        CanAttack = true;
        //IsAttacking = false;
        //animator.SetBool("IsAttacking", false);

        //Weapon.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
