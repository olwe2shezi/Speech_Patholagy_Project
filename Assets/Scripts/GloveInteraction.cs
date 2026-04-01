using UnityEngine;

public class GloveInteraction : MonoBehaviour
{
    public bool glovesOn = false;

    public void WearGloves()
    {
        glovesOn = true;
        Debug.Log("Gloves worn");
    }
}

