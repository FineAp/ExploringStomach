using UnityEngine;

public class ControlEvent : MonoBehaviour
{
    public bool isRed = false;
    public bool isOran = false;
    public bool isYel = false;
    public bool isGreen = false;
    public bool isBlue = false;

    private bool canNext = false;

    public GameObject Btn_Talk;
    public GameObject npcToTarget;


    void Update()
    {
        if(isRed && isOran && isYel && isGreen && isBlue && !canNext)
        {
            Btn_Talk.SetActive(true);
            npcToTarget.SetActive(true);
            canNext = true;
        }
    }

}

