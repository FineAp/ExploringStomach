using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private SceneMN scene;
    public GameObject latterManager;

    void Start()
    {
        scene = FindObjectOfType<SceneMN>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Target"))
        {
            scene.ReturnToMouse();
        }

        else if(other.CompareTag("Arrive"))
        {
            latterManager.SetActive(true);
        }
    }


}
