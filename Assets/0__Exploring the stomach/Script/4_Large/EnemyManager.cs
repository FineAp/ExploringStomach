using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Transform targetPos;
    private GameManager gameManager;
    private AudioSource audio;
    public float enemySpeed;


    void Start()
    {
        targetPos = GameObject.Find("CapSulTarget").transform;
        gameManager = FindObjectOfType<GameManager>();
        audio = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float step = enemySpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, targetPos.position, step);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CapsulTarget"))
        {
            Destroy(this.gameObject);
            gameManager.hp = gameManager.hp - 1;
        }

        else if(other.CompareTag("Bullet"))
        {
            audio.Play();
        }
    }

 
}
