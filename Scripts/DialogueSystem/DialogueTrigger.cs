using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter2D()
    {
        //Debug.Log("heya");
    }

    void OnTriggerStay2D()
    {
        //Debug.Log("hi");
        // if (Input.GetKeyDown("space")) {
        //     DialogueDisplayer.DisplayDialogue(DialogueLine dialogueLine);
        // }
    }

    void OnTriggerExit2D() { }
}
