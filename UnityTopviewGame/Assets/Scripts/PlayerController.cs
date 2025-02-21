using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    public static int hp = 3;
    public static string state; //플레이 상태
    bool inDamage = false; //데미지를 받는 상태인지 확인

    public float speed = 3.0f;
    public List<string> anime_list = new List<string> 
    { "PlayerDown", "PlayerUp", "PlayerLeft", "PlayerRight", "PlayerDead" };
    string current = "";
    string previous = "";
    float h, v; //가로축과 세로축에 대한 값
    public float z = -90.0f;//회전 각
    Rigidbody2D rbody; //컴포넌트
    bool isMove = false; //움직이는 상태인지 확인
    Animator animator;

    void Start()
    {
        state = "playing";
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        previous = anime_list[0]; //처음 시작은 아래를 보고 있도록
    }

    // Update is called once per frame
    void Update()
    {
        //플레이 상태가 아니거나, 데미지를 받는 상황에는 로직이 처리되지 않도록 설계합니다.
        if(state != "playing" || inDamage)
        {
            return;
        } 

        if(isMove == false)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
        }

        Vector2 from = transform.position;

        Vector2 to = new Vector2(from.x + h, from.y + v);

        z = GetAngle(from, to); //키 입력을 통한 값을 통해 이동 각도를 계산할 함수 GetAngle


       //각도에 따라 방향과 애니메이션 설정
        if (z >= -45 && z < 45)
        {
            //오른쪽
            current = anime_list[3];
        }
        else if (z >= 45 && z <= 135)
        {
            //위쪽
            current = anime_list[1];
        }
        else if(z >= -135 && z <= -45)
        {
            //아래쪽
            current = anime_list[0];
        }
        else
        {
            //왼쪽
            current = anime_list[2];
        }

        if(current != previous)
        {
            previous = current;
            animator.Play(current);
        }
    }

    private void FixedUpdate()
    {
        if (state != "playing" || inDamage)
        {
            return;
        }
        //데미지를 받는 경우
        if (inDamage)
        {
            float value = Mathf.Sin(Time.time * 50);
            if (value > 0)
            {
                //이미지 표시
                GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                //이미지 비활성화
                GetComponent<SpriteRenderer>().enabled = false;
            }
            //데미지 받는 동안은 조작 불가
            return;
        }
        rbody.linearVelocity = new Vector2(h, v) * speed;
    }

    //플레이어에게 물리적인 충돌이 발생할 경우
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GetDamage(collision.gameObject);
        }
    }
    //적으로부터 받는 데미지에 대한 공식
    private void GetDamage(GameObject enemy)
    {
        if(state == "playing")
        {
            hp--;
            if(hp > 0)
            {
                //이동 정지
                rbody.linearVelocity = new Vector2(0, 0);

                Vector3 to = (transform.position - enemy.transform.position).normalized;

                //현 좌표에서 약 4칸정도 멀어지도록
                rbody.AddForce(new Vector2(to.x * 4, to.y * 4), ForceMode2D.Impulse);

                inDamage = true;

                //데미지 판정 후 호출할 함수 처리
                Invoke("OnDamageExit", 0.25f);
            }
            else
            {
                //체력이 0이 되면 게임 오버
                GameOver();
            }
        }
    }
    private void OnDamageExit()
    {
        inDamage = false;//데미지 안받는 상태로 전환
        GetComponent<SpriteRenderer>().enabled = true; //이미지 다시 키기
    }


    private void GameOver()
    {
        state = "gameover";
        GetComponent<CircleCollider2D>().enabled = false;
        rbody.linearVelocity = new Vector2(0, 0);
        rbody.gravityScale = 1;
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        GetComponent<Animator>().Play(anime_list[4]);
        Destroy(gameObject, 1.0f);
    }


    /// <summary>
    /// from에서 to 까지의 각도를 계산하는 함수
    /// </summary>
    /// <param name="from">시작 위치(A 지점)</param>
    /// <param name="to">마무리 위치(B 지점)</param>
    private float GetAngle(Vector2 from, Vector2 to)
    {
        float angle;

        if(h != 0 || v != 0)
        {
            //from과 to의 차이를 계산합니다.
            float dx = to.x - from.x;
            float dy = to.y - from.y;

            float radian = Mathf.Atan2(dy, dx);
            //Atan 같은 경우는 x좌표가 0일 경우 계산이 안됩니다.
            angle = radian * Mathf.Rad2Deg;
        }
        else
        {
            angle = z;
        }
        return angle;
    }
}
