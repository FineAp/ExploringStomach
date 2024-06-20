using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNPC : MonoBehaviour
{
    public GameObject[] npc;

    void Start()
    {
        Invoke("ChangeNpc", 2f);
    }

    void ChangeNpc()
    {
        npc[0].SetActive(false);
        npc[1].SetActive(true);
    }
}
