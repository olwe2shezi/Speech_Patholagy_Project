using UnityEngine;
using TMPro;

public class VitalsMonitorController : MonoBehaviour
{
    public BabyStateController baby;

    public TextMeshProUGUI spo2Text;
    public TextMeshProUGUI heartRateText;
    public TextMeshProUGUI respRateText;

    void Update()
    {
        if (baby != null)
        {
            spo2Text.text = "SpO2: " + Mathf.RoundToInt(baby.spo2) + "%";
            heartRateText.text = "HR: " + Mathf.RoundToInt(baby.heartRate);
            respRateText.text = "RR: " + Mathf.RoundToInt(baby.respiratoryRate);
        }
    }
}
