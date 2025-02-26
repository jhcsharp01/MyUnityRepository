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

    private void Start()
    {
        createTime = Random.Range(min, max);
    }


    private void Update()
    {
        //1. 시간이 흐른다.
        currentTime += Time.deltaTime;
        //2. 현재 시간이 일정 시간에 도달한다면
        //    적을 생성합니다.
        if(currentTime >= createTime)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;
            //3. 소환 후 시간을 0으로 리셋합니다.
            currentTime = 0;
            createTime = Random.Range(min, max);
        }
    }
}
