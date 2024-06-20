using UnityEngine;

public class MapRotate : MonoBehaviour
{
    public float rotSpeed;
    
    void Update()
    {
        transform.Rotate(0f,rotSpeed, 0f);
        
    }
}
