using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GloveSystem : MonoBehaviour
{
    public static bool glovesOn = false;
    public PopupManager popup;

    void Start()
    {
        glovesOn = false;   // important reset

        GetComponent<XRGrabInteractable>()
            .selectEntered.AddListener(OnGrab);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        glovesOn = true;

        popup.Show("Gloves successfully on!");

        gameObject.SetActive(false);
    }
}



