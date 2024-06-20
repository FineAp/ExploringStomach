using UnityEngine;

public class NpcManager : MonoBehaviour
{

    public SceneMN scenes;
    public GameObject targetObject;
    private Quaternion initialRotation; // 초기 회전값 저장
    public Animator anim;


    public float moveSpeed = 5f;
    public bool isMove = false;

    public GameObject door;


    void Start()
    {
        initialRotation = transform.rotation;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (isMove)
        {
            anim.SetTrigger("ToWalk");
            // 대상 오브젝트 방향으로 이동
            Vector3 targetDirection = targetObject.transform.position - transform.position;
            transform.Translate(targetDirection.normalized * Time.deltaTime * moveSpeed, Space.World);

            // 대상 오브젝트를 바라보도록 회전 (초기 회전값과 함께)
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.Euler(initialRotation.eulerAngles.x, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {

        Animator anim;
        anim = door.GetComponent<Animator>();
        // 충돌한 오브젝트가 타겟인지 확인
        if (other.gameObject.CompareTag("Target"))
        {
            // 이동 중지
            isMove = false;
            gameObject.SetActive(false);
            anim.SetTrigger("ToOpen");

        }

        else if(other.gameObject.CompareTag("Clear"))
        {
            Invoke("Clear", 4f);
        }
    }

    void Clear()
    {
        scenes.QuitGame();
    }
}
