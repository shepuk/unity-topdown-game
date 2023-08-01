using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField]
    private DialogueUI dialogueUI;

    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }

    [SerializeField]
    public GameObject dialogueInteractIndicator;

    Rigidbody2D body;

    float horizontal;
    float vertical;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        dialogueInteractIndicator.SetActive(false);
    }

    void Update()
    {
        if (dialogueUI.IsOpen)
            return;

        if (Input.GetKeyDown("e"))
        {
            if (Interactable != null)
            {
                Interactable.Interact(this);
            }
        }

        // transform.localScale = new Vector3(-1, 1, 1);
    }

    public void toggleInteractBubble()
    {
        if (Interactable != null)
        {
            dialogueInteractIndicator.SetActive(true);
        }
        else
        {
            dialogueInteractIndicator.SetActive(false);
        }
    }

    void FixedUpdate() { }
}
