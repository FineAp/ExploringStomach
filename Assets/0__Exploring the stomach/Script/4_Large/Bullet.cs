using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameManager gameManager;
    public float speed = 50f;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(speed * Time.deltaTime,0f, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject, 0.5f);
            gameManager.score = gameManager.score + 10;
        }

    }


}

