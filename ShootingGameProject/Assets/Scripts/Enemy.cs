using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    
    Vector3 dir;

    public GameObject explosionFactory;

    private void Start()
    {
        //적의 방향 설정

        int rand = Random.Range(0, 10); // 0 ~ 9 사이 랜덤 값 하나 가져옴

        // 10개 중에서 3개이므로 약 30% 확률이라고 볼 수 있음.
        if(rand < 3)
        {
            var target = GameObject.FindGameObjectWithTag("Player");

            dir = target.transform.position - transform.position;

            dir.Normalize(); //방향의 크기를 1로 설정합니다.
            //방향 벡터(Vector3.up, Vector3.down, Vector3.left ... )
        }
        else
        {
            dir = Vector3.down;
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
