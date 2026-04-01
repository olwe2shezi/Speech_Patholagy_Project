using UnityEngine;

public class ConsolingSystem : MonoBehaviour
{
    public BabyStateController baby;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            baby.ConsoleBaby();
        }
    }
}

