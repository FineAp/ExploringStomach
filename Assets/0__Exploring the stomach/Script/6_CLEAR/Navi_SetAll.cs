using System.Collections.Generic;
using UnityEngine;

public class Navi_SetAll : MonoBehaviour
{
    public GameObject[] targets;

    // Start is called before the first frame update
    void Start()
    {
        if (targets == null || targets.Length == 0)
        {
            Debug.LogWarning("No targets assigned.");
            return;
        }

        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != null)
            {
                targets[i].SetActive(true);
            }
        }
    }
}
