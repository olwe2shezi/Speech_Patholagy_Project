using UnityEngine;

public class FeedingSystem : MonoBehaviour
{
    public BabyStateController baby;

    private void OnTriggerEnter(Collider other)
    {
        SyringeController syringe = other.GetComponent<SyringeController>();

        if (syringe != null && syringe.HasMilk())
        {
            baby.FeedBaby();
            syringe.UseMilk();

            Debug.Log("Mouth Triggered");

        }
    }
}
