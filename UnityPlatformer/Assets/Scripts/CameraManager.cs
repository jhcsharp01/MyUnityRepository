using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //카메라의 스크롤 제한 값
    public float left_limit = 0.0f;
    public float right_limit = 0.0f;
    public float top_limit = 0.0f;
    public float bottom_limit = 0.0f;

    //서브 스크린
    public GameObject sub_screen;

    //== 강제 스크롤 기능 처리 ===
    public bool isForceScrollX = false;    //X 조건
    public bool isForceScrollY = false;    //Y 조건
    public float forceScrollSpeedX = 0.5f; //1초 간 움직일 X 방향의 거리
    public float forceScrollSpeedY = 0.5f; //1초 간 움직일 Y 방향의 거리
    //==========================


    void Update()
    {
        //플레이어 탐색
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        float x = player.transform.position.x; //플레이어 좌표 기준
        float y = player.transform.position.y; //플레이어 좌표 기준
        float z = transform.position.z; //카메라 좌표 기준

        //가로 강제 스크롤
        if(isForceScrollX)
        {
            x = transform.position.x + (forceScrollSpeedX * Time.deltaTime);
        }

        //가로 방향에 대한 동기화
        if (x < left_limit)
        {
            x = left_limit;
        }
        else if (x > right_limit)
        {
            x = right_limit;
        }

        //세로 강제 스크롤
        if (isForceScrollY)
        {
            y = transform.position.y + (forceScrollSpeedY * Time.deltaTime);
        }


        //세로 방향에 대한 동기화
        if (y < bottom_limit)
        {
            y = bottom_limit;
        }
        else if(y > top_limit)
        {
            y = top_limit;
        }
        
        //현재의 카메라 위치를 Vector3로 표현
        Vector3 vector3 = new Vector3(x, y, z);
        
        //카메라의 위치를 설정한 값으로 적용
        transform.position = vector3;

        //서브 스크린 작동
        if(sub_screen != null)
        {
            y = sub_screen.transform.position.y;
            z = sub_screen.transform.position.z;
            Vector3 v = new Vector3(x * 0.5f, y, z);
            sub_screen.transform.position = v;
        }


    }
} 
