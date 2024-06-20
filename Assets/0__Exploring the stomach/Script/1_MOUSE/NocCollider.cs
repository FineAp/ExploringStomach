using UnityEngine;

public class NocCollider : MonoBehaviour
{
    public GameObject[] dacong;


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NPC"))
        {
            Invoke("Time", 2f);
        }
    }

    void Time()
    {
        dacong[0].SetActive(false);
        dacong[1].SetActive(true);
        Destroy(gameObject);
    }
}
