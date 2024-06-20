using UnityEngine;
using UnityEngine.SceneManagement;

public class Npc_ToTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ToInsting", 8f);
    }

    public void ToInsting()
    {
        SceneManager.LoadScene("3___INTESTING___");

    }
}
