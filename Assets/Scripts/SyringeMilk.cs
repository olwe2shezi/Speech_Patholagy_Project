using UnityEngine;

public class SyringeMilk : MonoBehaviour
{
    public bool hasMilk = true;

    public void UseMilk()
    {
        hasMilk = false;
        Debug.Log("Milk Used");
    }
}

