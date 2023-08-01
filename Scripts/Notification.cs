using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notification : MonoBehaviour
{
    [SerializeField]
    RectTransform notificationBox;

    [SerializeField]
    TMP_Text notificationMessage;

    public void sendNotification(string message)
    {
        StartCoroutine(displayNotification(message));
    }

    public IEnumerator displayNotification(string message)
    {
        // TODO: animate notification box
        // TODO: stack multiple notification boxes

        notificationMessage.text = string.Empty;
        notificationBox.gameObject.SetActive(true);
        notificationMessage.text = message;

        yield return new WaitForSeconds(2);

        notificationMessage.text = string.Empty;
        notificationBox.gameObject.SetActive(false);
    }
}
