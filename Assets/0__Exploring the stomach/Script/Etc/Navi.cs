using UnityEngine;

public class Navi : MonoBehaviour
{
    public float speed = 0.05f;
    private Controller control;
    public GameObject point;

    void Start()
    {
        control = FindObjectOfType<Controller>();
    }

    void FixedUpdate()
    {
        Chack();
    }

    void Chack()
    {
        if(control.isForward == true)
        {
            point.transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }
        if(control.isUp == true)
        {
            point.transform.Translate(0f ,speed * Time.deltaTime, 0f);
        }
    }



    
}
