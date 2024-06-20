using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public List<GameObject> breakpieace;
    private BossPoo poo;

    public float timeToBreak = 1.5f;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        poo = GameObject.Find("Poo").GetComponent<BossPoo>();

        foreach(var item in breakpieace)
        {
            item.SetActive(false);
        }
    }

    public void Break()
    {
        timer += Time.deltaTime;

        if(timer > timeToBreak)
        {
            foreach(var item in breakpieace)
            {
                item.SetActive(true);
                item.transform.parent = null;
            }

            poo.isCure = true;
            this.gameObject.SetActive(false);

        }
        

    }
}
