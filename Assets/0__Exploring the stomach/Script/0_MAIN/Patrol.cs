using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public float patrolRadius = 10f; // 적이 이동할 반경
    public float patrolTime = 5f; // 이동 후 대기 시간

    private NavMeshAgent agent;
    private Animator anim;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.updateRotation = false; // NavMeshAgent의 자동 회전 비활성화
        timer = patrolTime;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= patrolTime)
        {
            Vector3 newPos = RandomNavSphere(transform.position, patrolRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }

        UpdateAnimation();
        RotateTowardsMovementDirection();
    }

    void UpdateAnimation()
    {
        if (agent.velocity.sqrMagnitude > 0.1f)
        {
            anim.SetTrigger("ToWalk");
        }
        else
        {
            anim.SetTrigger("ToIdle");
        }
    }

    void RotateTowardsMovementDirection()
    {
        Vector3 direction = agent.velocity;
        if (direction.sqrMagnitude > 0.1f) // 이동 중인지 확인
        {
            // 회전할 방향을 계산
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            // 현재 회전에서 목표 회전으로 부드럽게 회전
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * agent.angularSpeed / 100);
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }
}
