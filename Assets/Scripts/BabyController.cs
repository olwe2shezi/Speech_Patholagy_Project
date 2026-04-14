using UnityEngine;
using System.Collections;

public class BabyController : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip swallowSound;
    public AudioClip coughSound;
    public AudioClip crySound;

    public float spo2 = 97f;
    public float dropRate = 4f;
    public float recoverRate = 6f;
    public float normalSpo2 = 98f;

    private bool isCrying = false;
    private bool canBeSoothed = false;
    private bool isInCrisis = false;
    private bool hasBeenFed = false;

    void Update()
    {
        // SpO2 drops ONLY during crying
        if (isCrying && spo2 > 70f)
        {
            spo2 -= dropRate * Time.deltaTime;
        }
    }

    // =========================
    // FEEDING
    // =========================
    public void FeedBaby()
    {
        if (isInCrisis || hasBeenFed) return;

        hasBeenFed = true;
        StartCoroutine(FeedingSequence());
    }

    IEnumerator FeedingSequence()
    {
        isInCrisis = true;

        // Swallow
        audioSource.loop = false;
        audioSource.clip = swallowSound;
        audioSource.Play();
        yield return new WaitForSeconds(swallowSound.length);

        // Cough
        audioSource.clip = coughSound;
        audioSource.loop = true;
        audioSource.Play();
        yield return new WaitForSeconds(10f);

        audioSource.Stop();

        StartCrying();
    }

    // =========================
    // CRYING
    // =========================
    void StartCrying()
    {
        isCrying = true;
        canBeSoothed = false;

        audioSource.clip = crySound;
        audioSource.loop = true;
        audioSource.Play();

        StartCoroutine(EnableSoothing());
    }

    IEnumerator EnableSoothing()
    {
        yield return new WaitForSeconds(10f);
        canBeSoothed = true;
    }

    // =========================
    // SOOTHING (VR CLICK)
    // =========================
    public void SootheBaby()
    {
        if (!isCrying)
        {
            Debug.Log("Baby is not crying");
            return;
        }

        if (!canBeSoothed)
        {
            Debug.Log("Too early to soothe");
            return;
        }

        Debug.Log("Baby soothed successfully");

        isCrying = false;
        canBeSoothed = false;

        audioSource.Stop();

        StartCoroutine(RecoverSpo2());
    }

    IEnumerator RecoverSpo2()
    {
        while (spo2 < normalSpo2)
        {
            spo2 += recoverRate * Time.deltaTime;
            yield return null;
        }

        spo2 = normalSpo2;
    }
}

