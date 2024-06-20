using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    public GameObject EnemySpawn; // 생성할 게임 오브젝트
    public float spawnRadius = 5f; // 생성할 위치의 반경
    public float minSpawnTime = 1f; // 최소 생성 간격
    public float maxSpawnTime = 3f; // 최대 생성 간격

    void SpawnObject()
    {
        // 랜덤한 위치 생성
        Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;
        randomPosition += transform.position; // 중심 위치에 더함

        // 높이를 0으로 설정 (원하는 경우 다르게 설정 가능)
        randomPosition.y = Random.Range(1, 5);

        // 게임 오브젝트 생성
        GameObject newObject = Instantiate(EnemySpawn, randomPosition, Quaternion.identity);

        // 다음 생성 간격 설정
        float nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke("SpawnObject", nextSpawnTime);
    }

    void Start()
    {
        // 초기 생성
        float initialSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke("SpawnObject", initialSpawnTime);
    }
}
