using UnityEngine;

public class GlovesPickup : MonoBehaviour
{
    public GlovesManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            manager.PutOnGloves();
            Destroy(gameObject);
        }
    }
}
