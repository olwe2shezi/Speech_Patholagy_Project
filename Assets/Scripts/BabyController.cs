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

    private bool isCrying = false;
    private bool canBeSoothed = false;
    private bool isInCrisis = false;
    private bool hasBeenFed = false;

    void Update()
    {
        // SpO2 only drops during active crying
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
        if (isInCrisis) return; // prevent restart while already active

        StartCoroutine(FeedingSequence());

        if (hasBeenFed) return;

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

        // Cough (no spo2 drop yet)
        audioSource.clip = coughSound;
        audioSource.loop = true;
        audioSource.Play();
        yield return new WaitForSeconds(10f);

        audioSource.Stop();

        StartCrying();
    }

    // =========================
    // CRYING PHASE
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
    // SOOTHING
    // =========================


    public void StopCrying()
    {
        if (!isCrying) return;

        if (!canBeSoothed)
        {
            Debug.Log("Too early to soothe");
            return;
        }

        Debug.Log("Baby soothed");

        isCrying = false;
        canBeSoothed = false;

        audioSource.Stop();

        StartCoroutine(RecoverSpo2());
    }

    IEnumerator RecoverSpo2()
    {
        while (spo2 < 95f)
        {
            spo2 += recoverRate * Time.deltaTime;
            yield return null;
        }
    }
}

