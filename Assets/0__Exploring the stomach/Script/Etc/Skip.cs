using UnityEngine;

public class Skip : MonoBehaviour
{
    public GameObject off;
    public GameObject on;

    public void Skips()
    {
        off.SetActive(false);
        on.SetActive(true);
    }
}
