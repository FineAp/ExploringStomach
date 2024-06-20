using UnityEngine;

public class StomachStroy : MonoBehaviour
{
    public GameObject startStroy;

    void Start()
    {

    }

    public void DestroyTime()
    {
        startStroy.SetActive(false);
    }


}
