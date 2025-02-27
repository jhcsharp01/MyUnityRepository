using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //현재의 시간
    float currentTime;

    //일정 시간
    public float createTime = 1.0f;
    
    //생성할 적
    public GameObject enemyFactory;

    float min = 1, max = 5;


    //오브젝트 풀 설정
    public int poolSize = 10;
    GameObject[] enemyObjectPool;

    //생성 위치(배열)
    public Transform[] spawnPoints;

    private void Start()
    {
        createTime = Random.Range(min, max);

        enemyObjectPool = new GameObject[poolSize];

        for(int i =0; i < poolSize; i++)
        {
            var enemy = Instantiate(enemyFactory);
            enemyObjectPool[i] = enemy;
            enemy.SetActive(false);
        }

    }


    private void Update()
    {
        //1. 시간이 흐른다.
        currentTime += Time.deltaTime;
        //2. 현재 시간이 일정 시간에 도달한다면
        //    적을 생성합니다.
        if(currentTime >= createTime)
        {

            for (int i = 0; i < poolSize; i++)
            {
                var enemy = enemyObjectPool[i];
                if (enemy.activeSelf == false)
                {
                    //랜덤 스폰
                    int index = Random.Range(0, spawnPoints.Length); 
                    enemy.transform.position = spawnPoints[index].position;
                    enemy.SetActive(true);
                    break;
                }
            }

            //3. 소환 후 시간을 0으로 리셋합니다.
            currentTime = 0;
            createTime = Random.Range(min, max);
        }
    }
}
