using UnityEngine;

public class NpcToTarget : MonoBehaviour
{
    public NpcManager npc;

    //using in Scene _ 1_MOUSE_
    public GameObject Btn_Talk;
    public GameObject largeTimer;
    public float time = 5f;
    public float realTime = 6.5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("npcTalkTime", time);
        Invoke("Time", realTime);
    }


    void Time()
    {
        npc.isMove = true;

    }

    void npcTalkTime()
    {
        Btn_Talk.SetActive(false);
        largeTimer.SetActive(true);
    }
}
