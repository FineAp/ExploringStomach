using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUpdate : MonoBehaviour
{
    public GameObject canvas_Moniter;
    public GameObject canvas_KeyBored;

    public GameObject canvas_Start;

    public void KeyChange()
    {
        canvas_KeyBored.SetActive(false);
        canvas_Moniter.SetActive(true);   
    }

    public void KeySetActiveTrue()
    {
        canvas_Start.SetActive(false);
        canvas_KeyBored.SetActive(true);
    }
}
