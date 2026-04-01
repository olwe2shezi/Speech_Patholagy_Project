using UnityEngine;

public class FeedingDetector : MonoBehaviour
{
    public BabyController baby;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Syringe"))
        {
            Debug.Log("Baby fed with syringe");
            baby.FeedBaby();
        }
    }
}




