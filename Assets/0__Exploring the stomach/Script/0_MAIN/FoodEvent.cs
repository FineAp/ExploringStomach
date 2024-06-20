using UnityEngine;

public class FoodEvent : MonoBehaviour
{
    public GameObject foodZone;

    private ControlEvent conEvent;


    void Start()
    {

        GameObject conOBJ = GameObject.Find("ControlEvent");
        conEvent = conOBJ.GetComponent<ControlEvent>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == foodZone && this.gameObject.name == "R_Bread")
        {
            conEvent.isRed = true;

        }

        else if(other.gameObject == foodZone && this.gameObject.name == "O_Meat")
        {
            conEvent.isOran = true;

        }

        else if(other.gameObject == foodZone && this.gameObject.name == "Y_Choco")
        {
            conEvent.isYel = true;

        }

        else if(other.gameObject == foodZone && this.gameObject.name == "G_Bitamin")
        {
            conEvent.isGreen = true;

        }

        else if(other.gameObject == foodZone && this.gameObject.name == "B_Cheese")
        {
            conEvent.isBlue = true;

        }

    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == foodZone && this.gameObject.name == "R_Bread")
        {
            conEvent.isRed = false;

        }

        else if(other.gameObject == foodZone && this.gameObject.name == "O_Meat")
        {
            conEvent.isOran = false;

        }

        else if(other.gameObject == foodZone && this.gameObject.name == "Y_Choco")
        {
            conEvent.isYel = false;

        }

        else if(other.gameObject == foodZone && this.gameObject.name == "G_Bitamin")
        {
            conEvent.isGreen = false;

        }

        else if(other.gameObject == foodZone && this.gameObject.name == "B_Cheese")
        {
            conEvent.isBlue = false;

        }

    }
}
