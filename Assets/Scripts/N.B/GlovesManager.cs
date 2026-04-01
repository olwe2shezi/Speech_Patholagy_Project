using UnityEngine;

public class GlovesManager : MonoBehaviour
{
    public static bool glovesOn = false;

    public void PutOnGloves()
    {
        glovesOn = true;
        Debug.Log("Gloves equipped");
    }
}