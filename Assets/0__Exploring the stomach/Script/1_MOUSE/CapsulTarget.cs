using UnityEngine;

public class CapsulTarget : MonoBehaviour
{
    public SceneMN scen;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Target"))
        {
            scen.ToStomach();
        }

        else if(other.CompareTag("ToLarge"))
        {
            scen.ToLarge();
        }
    }
}
