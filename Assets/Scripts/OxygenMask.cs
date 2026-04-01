using UnityEngine;

public class OxygenMask : MonoBehaviour
{
    public BabyController baby;
    public ScenarioManager scenario;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "MouthTrigger")
        {
            baby.spo2 += 10f;
            scenario.AddScore(30);
        }
    }
}

