using UnityEngine;
/// <summary>
/// 큐브를 회전시키는 클래스(컴포넌트)
/// </summary>
public class CubeRotate : MonoBehaviour
{
    #region  필기 내용
    //자료형(type)
    //프로그램이 데이터를 판단하는 기준

    //자주 사용되는 자료형
    //int : 정수(Integer) : 소수점 없는 숫자
    //float : 실수(Float) : 소수점이 포함된 숫자
    //bool : 논리(Boolean) : 맞는지 틀린지를 판단(True, False)
    //string : 문자열(string) : 문자의 집합을 표현합니다.(묶음)

    //변수(variable)
    //어떤 특정 값 하나를 저장하기 위해 이름을 붙인 저장 공간

    //만드는 방법
    //자료형 변수명;

    //변수의 값 설정(초기화)
    //변수에 값을 적용시키는 작업을 의미합니다.
    //변수명 = 값;

    #endregion

    #region 변수
    public float x; //유니티 에디터에서 공개되는 변수
    public float z;
    private int sample; //유니티 에디터에서 공개가 안되는 변수
    #endregion
    #region 함수
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sample = 10; //변수가 비공개일 경우 코드 내부에서 설정되는 경우가 많다.
        Debug.Log(sample);
        //""없이 변수만 적으면 그 값이 들어가는 방식
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(x ,0,z));
        //FPS(Frame Per Second) : 초 당 프레임
        //deltaTime : 전 프레임이 완료되기까지 걸리는 시간
    }
    #endregion
}
