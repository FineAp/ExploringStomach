using UnityEngine;

public class NPCUP : MonoBehaviour
{
    public GameObject talkBGM;
    public GameObject soket;

    public GameObject[] dacong;

    public NpcManager npcMN;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NPC"))
        {
            talkBGM.SetActive(true);
            soket.SetActive(true);

            npcMN.isMove = false;

            dacong[0].SetActive(false);
            dacong[1].SetActive(true);

            Invoke("Time", 2f);


        }
    }

    void Time()
    {
        talkBGM.SetActive(false);
        gameObject.SetActive(false);
    }

}
