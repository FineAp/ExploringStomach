using UnityEngine;

public class NpcSounds : MonoBehaviour
{
    public GameObject sound;
    public float time;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hands"))
        {
            sound.SetActive(true);
            Invoke("SoundOff", time);


        }
    }


    void SoundOff()
    {
        sound.SetActive(false);
    }
}
