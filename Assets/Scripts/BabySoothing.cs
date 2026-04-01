using UnityEngine;

public class BabySoothing : MonoBehaviour
{
    public BabyController baby;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Debug.Log("Hand touching baby");

            baby.StopCrying();
        }
    }
}