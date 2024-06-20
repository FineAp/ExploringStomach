using UnityEngine;
using UnityEngine.SceneManagement;

public class Loding : MonoBehaviour
{
    public GameObject sounds;

    void Start()
    {
        Invoke("SoTime", 8f);
        Invoke("Sceness", 23f);
    }



    void SoTime()
    {
        sounds.SetActive(true);
    }

    void Sceness()
    {
        SceneManager.LoadScene("0___MAIN___");
    }
}
