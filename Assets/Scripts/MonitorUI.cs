using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonitorUI : MonoBehaviour
{
    public BabyController baby;
    public TextMeshProUGUI spo2Text;
    public Image background;

    void Update()
    {
        spo2Text.text = "SpO2: " + Mathf.RoundToInt(baby.spo2) + "%";

        if (baby.spo2 < 90)
        {
            float pulse = Mathf.Abs(Mathf.Sin(Time.time * 5f));
            background.color = Color.Lerp(Color.white, Color.red, pulse);
        }
        else
        {
            background.color = Color.white;
        }
    }
}

