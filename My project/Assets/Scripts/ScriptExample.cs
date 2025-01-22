using UnityEngine;

/// <summary>
/// 유니티 애트리뷰트(Unity Attribute)
/// 유니티에서는 에디터에 맞게 스크립트를 커스텀하는 것이 가능합니다.
/// </summary>

[AddComponentMenu("CusomUtility/ScriptExample")]
public class ScriptExample : MonoBehaviour
{
    [Range(1, 99)]
    public int level;

    [Range(0, 100)]
    public int volume;

    [Header("플레이어의 이름")]
    public string player_name;

    [TextArea]
    public string talk01;
    [TextArea(1,3)]
    public string talk02;
    [TextArea(5,7)]
    public string talk03;

    [Tooltip("체크되면 죽은 상태임을 의미합니다.")]
    public bool isDead = true;

    //함수(Function)
    //C#에서는 클래스 내부에서 설계되는 함수를
    //메소드(method)라고 부릅니다.

    //함수는 특정 하나의 기능을 수행하기 위해 작성된 명령문 집합체
    //코드 내에서 설계된 함수는 원하는 작업 위치에서 호출을 통해
    //사용할 수 있습니다.

    //함수의 설계 방법

    //자료형  함수이름(매개변수)
    //{
    // 함수를 호출했을 때, 실행할 명령문을 작성하는 자리;
    //}

    //함수 호출 방법
    //함수이름(인자);

    //매개변수 : 함수를 호출할 때, 전달받을 데이터에 대한 표현

    //인자 : 함수를 호출할 때 전달할 값


    [ContextMenu("HelloEveryone")]
    void HelloEveryone()
    {
        Debug.Log("여러분들 모두 안녕하세요!!");
    }

    void HelloSomeone(string who)
    {
        Debug.Log($"{who}님 안녕하세요!");
    }


}
