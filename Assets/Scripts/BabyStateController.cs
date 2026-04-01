using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class BabyStateController : MonoBehaviour
{
    public Animator animator;

    [Header("Vitals")]
    public float spo2 = 97f;
    public float heartRate = 120f;
    public float respiratoryRate = 35f;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip coughSound;
    public AudioClip crySound;

    public XRBaseController leftController;
    public XRBaseController rightController;

    private bool isCrying = false;
    private bool isRecovering = false;

    void Start()
    {
        spo2 = 97f;
        heartRate = 120f;
        respiratoryRate = 35f;
    }

    public void FeedBaby()
    {
        if (!isCrying)
        {
            animator.SetTrigger("Swallow");
            StartCoroutine(CoughSequence());
        }
    }

    IEnumerator CoughSequence()
    {
        yield return new WaitForSeconds(1f);

        animator.SetTrigger("Cough");

        if (audioSource != null && coughSound != null)
        {
            audioSource.PlayOneShot(coughSound);

            if (leftController != null)
                leftController.SendHapticImpulse(0.7f, 0.2f);

            if (rightController != null)
                rightController.SendHapticImpulse(0.7f, 0.2f);

        }

        spo2 = 85f;
        isCrying = true;

        yield return new WaitForSeconds(2f);

        animator.SetTrigger("Cry");

        if (audioSource != null && crySound != null)
        {
            audioSource.PlayOneShot(crySound);
        }
    }


    public void ConsoleBaby()
    {
        if (isCrying && !isRecovering)
        {
            StartCoroutine(RecoverOxygen());
        }
    }

    IEnumerator RecoverOxygen()
    {
        isRecovering = true;

        while (spo2 < 92f)
        {
            spo2 += Time.deltaTime * 2f;
            yield return null;
        }

        animator.SetTrigger("Idle");
        isCrying = false;
        isRecovering = false;
    }
}
