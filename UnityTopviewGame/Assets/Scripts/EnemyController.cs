using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hp = 3;
    public float speed = 0.5f;
    public float pattern_distance = 4.0f;  //반응을 보일 거리
    public List<string> anime_list = new List<string>
    { "EnemyIdle","EnemyDown", "EnemyUp", "EnemyLeft", "EnemyRight", "EnemyDead" };

    string current = "";
    string previous = "";
    float h, v;
    Rigidbody2D rbody;
    bool isActive = false;
    public int arrangeId = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        //1. 플레이어를 씬에서 찾습니다.
        var player = GameObject.FindGameObjectWithTag("Player");
        //플레이어가 존재한다면
        if(player != null)
        {
            //몬스터가 활성화 상태일 때
            if (isActive)
            {
                float dx = player.transform.position.x - transform.position.x;
                float dy = player.transform.position.y - transform.position.y;
                float radian = Mathf.Atan2(dy, dx);
                float degree = radian * Mathf.Rad2Deg;

                if (degree > -45.0f && degree <= 45.0f)
                {
                    current = anime_list[4]; //right
                }
                else if (degree > 45.0f && degree <= 135.0f)
                {
                    current = anime_list[2]; //up
                }
                else if (degree > 135.0f && degree <= -45.0f)
                {
                    current = anime_list[1]; //up
                }
                else
                {
                    current = anime_list[3]; //left
                }

                h = Mathf.Cos(radian) * speed;
                v = Mathf.Sin(radian) * speed;
            }
            else//패턴이 진행되지 않은 상태일 때
            {
                //플레이어와의 거리를 측정
                float distance = Vector2.Distance(transform.position, player.transform.position);

                //패턴 범위 내에 들어올 경우 활성화 처리
                if (distance <= pattern_distance)
                {
                    isActive = true;
                }
            }
        }
        else if(isActive)
        {
            isActive = false;
            rbody.linearVelocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        //활성화 상태이면서 체력이 남아있을 경우
        if(isActive && hp > 0)
        {
            //계산한 좌표로 설정
            rbody.linearVelocity = new Vector2(h, v);

            //애니메이션이 달라지면, 변경후 플레이 진행합니다.
            if(current != previous)
            {
                previous = current;
                var animator = GetComponent<Animator>();
                animator.Play(current);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Arrow")
        {
            hp--;

            if(hp <= 0)
            {
                //더이상의 충돌이 발생하지 않습니다.
                GetComponent<CircleCollider2D>().enabled = false;
                //속력은 0이 됩니다.
                rbody.linearVelocity = new Vector2(0, 0);

                //죽음에 대한 애니메이션을 처리합니다.
                var animator = GetComponent<Animator>();
                animator.Play(anime_list[5]);

                //오브젝트를 파괴합니다.
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
