using UnityEngine;

public class SyringeSnap : MonoBehaviour
{
    public Transform snapPoint;
    public BabyController baby;

    private bool snapped = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered feeding zone: " + other.name);

        if (other.CompareTag("Syringe"))
        {
            if (!GlovesManager.glovesOn)
            {
                Debug.Log("Cannot feed without gloves");
                return;
            }

            other.transform.position = snapPoint.position;
            other.transform.rotation = snapPoint.rotation;

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            baby.FeedBaby();
        }
    }
}
