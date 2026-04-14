using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BabySoothing : MonoBehaviour
{
    public BabyController baby;

    public void OnSoothing()
    {
        if (baby != null)
        {
            baby.SootheBaby();
        }
    }
}