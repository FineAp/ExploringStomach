using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public GameObject capsul;

    private Vector3 initialPos;

    void Start()
    {
        if(capsul != null)
        {
            initialPos = capsul.transform.position;
        }
        else
        {
            print("Null");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Capsul"))
        {
            capsul.transform.position = initialPos;
        }
    }

}
