using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;

    public Transform targetPos;
    public GameObject sound;


    void Start()
    {
        Invoke("Change", 6f);
    }

    void Change()
    {
        player.transform.position = targetPos.position;
        sound.SetActive(true);
    }
}
