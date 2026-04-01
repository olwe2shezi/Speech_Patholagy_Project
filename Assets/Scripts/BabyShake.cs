using UnityEngine;

public class BabyShake : MonoBehaviour
{
    public float shakeAmount = 0.01f;
    public float shakeSpeed = 20f;

    private Vector3 originalPosition;
    private bool isShaking = false;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (isShaking)
        {
            float x = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
            float y = Mathf.Cos(Time.time * shakeSpeed) * shakeAmount;

            transform.localPosition = originalPosition + new Vector3(x, y, 0);
        }
        else
        {
            transform.localPosition = originalPosition;
        }
    }

    public void StartShaking()
    {
        isShaking = true;
    }

    public void StopShaking()
    {
        isShaking = false;
    }
}

