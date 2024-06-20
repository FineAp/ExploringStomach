using UnityEngine;

public class ForSkip : MonoBehaviour
{
    public GameObject talk;

    void Start()
    {
        Invoke("Time", 3.5f);
    }

    void Time()
    {
        talk.SetActive(false);
    }
}
