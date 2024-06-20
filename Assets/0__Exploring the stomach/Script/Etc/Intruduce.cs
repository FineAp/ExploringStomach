using UnityEngine;

public class Intruduce : MonoBehaviour
{
    public Controller control;

    void Update()
    {
        if (control.isForward)
        {
            gameObject.SetActive(false);
        }

        else if(control.isUp)
        {
            gameObject.SetActive(false);
        }
        
    }
}
