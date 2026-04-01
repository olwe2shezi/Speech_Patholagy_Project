using UnityEngine;
using TMPro;
using System.Collections;

public class PopupManager : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI messageText;

    public void Show(string message)
    {
        StartCoroutine(ShowRoutine(message));
    }

    IEnumerator ShowRoutine(string message)
    {
        messageText.text = message;
        panel.SetActive(true);

        yield return new WaitForSeconds(20f);

        panel.SetActive(false);
    }
}

