using UnityEngine;

public class SyringeController : MonoBehaviour
{
    public float milkAmount = 0f;
    public float maxMilk = 2f;

    public void FillMilk()
    {
        milkAmount = maxMilk;
    }

    public void UseMilk()
    {
        milkAmount = 0f;
    }

    public bool HasMilk()
    {
        return milkAmount > 0f;
    }
}

