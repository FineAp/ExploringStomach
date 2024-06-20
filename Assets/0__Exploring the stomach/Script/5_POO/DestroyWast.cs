using UnityEngine;

public class DestroyWast : MonoBehaviour
{
    public float time = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, time);
    }


}
