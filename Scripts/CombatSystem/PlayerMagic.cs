using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : MonoBehaviour
{
    [SerializeField]
    public float PlayerMagicMax = 10.0f;
    public float PlayerMagicRemaining = 10.0f;
    public float castDelay = 0.5f;
    public float castSpeed = 30f;

    public bool currentlyCasting = false;

    public Animator animator;

    public PlayerMovement playerMovement;

    [SerializeField]
    public GameObject Spell1;

    [SerializeField]
    public GameObject DialogueIndicator;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && currentlyCasting == false && !DialogueIndicator.activeSelf)
        {
            playerMovement.moveSpeed = 2.5f;
            currentlyCasting = true;
            animator.SetBool("IsCasting", true);
            StartCoroutine(Cast());
        }
        if (Input.GetKeyUp("space"))
        {
            playerMovement.moveSpeed = 7.0f;
            animator.SetBool("IsCasting", false);
            StopCoroutine(Cast());
            currentlyCasting = false;
        }

        if (currentlyCasting) { }
    }

    IEnumerator Cast()
    {
        yield return new WaitForSeconds(0.3f);

        while (currentlyCasting)
        {
            //...setting shoot direction
            Vector3 shootDirection;
            shootDirection = Input.mousePosition;
            //shootDirection.z = 0.0f;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection = shootDirection - transform.position;
            shootDirection = shootDirection.normalized;
            //...instantiating the spell
            GameObject spell = Instantiate(
                Spell1,
                transform.position,
                Quaternion.Euler(new Vector3(0, 0, 0))
            );
            spell.GetComponent<Rigidbody2D>().velocity =
                new Vector2(shootDirection.x, shootDirection.y).normalized * castSpeed;

            yield return new WaitForSeconds(castDelay);

            if (!currentlyCasting)
            {
                break;
            }
        }

        currentlyCasting = false;
        yield return new WaitForSeconds(castDelay);
        yield return null;
    }
}
