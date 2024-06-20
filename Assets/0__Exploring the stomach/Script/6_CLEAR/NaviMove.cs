using System.Collections.Generic;
using UnityEngine;

public class NaviMove : MonoBehaviour
{
    // 타겟 오브젝트들을 지정할 public 리스트
    public List<GameObject> targets;

    // 네비 오브젝트를 지정할 변수
    public GameObject navi;

    // 이동 속도를 설정할 변수
    public float speed = 0.18f;

    // 현재 타겟 인덱스를 추적할 변수
    private int currentTargetIndex = 0;

    // Update 메서드에서 매 프레임마다 호출됩니다.
    void Update()
    {
        // 타겟 리스트가 비어있거나 모든 타겟을 순회한 경우 함수 종료
        if (targets == null || targets.Count == 0 || currentTargetIndex >= targets.Count)
        {
            return;
        }

        // 현재 타겟 오브젝트를 가져옵니다.
        GameObject currentTarget = targets[currentTargetIndex];

        // 현재 타겟 오브젝트가 null이거나 활성화되지 않은 경우 그 자리에서 멈춤
        if (currentTarget == null || !currentTarget.activeSelf)
        {
            return;
        }

        // 현재 위치와 타겟 위치를 가져옵니다.
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = currentTarget.transform.position;

        // 타겟 방향을 계산합니다.
        Vector3 direction = (targetPosition - currentPosition).normalized;

        // 이동할 거리를 계산합니다.
        float step = speed * Time.deltaTime;

        // 타겟 방향으로 이동합니다.
        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, step);

        // 타겟에 도착했는지 확인합니다.
        if (Vector3.Distance(currentPosition, targetPosition) < 0.1f)
        {
            // 타겟 오브젝트를 비활성화합니다.
            currentTarget.SetActive(false);

            // 다음 타겟으로 이동합니다.
            currentTargetIndex++;

            // 마지막 타겟에 도착했는지 확인합니다.
            if (currentTargetIndex >= targets.Count && navi != null)
            {
                // navi 오브젝트를 비활성화합니다.
                navi.SetActive(false);
            }
        }
    }
}
