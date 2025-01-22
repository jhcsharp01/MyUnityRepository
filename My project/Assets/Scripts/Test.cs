using UnityEngine;
// using은 다음에 적힌 것을 코드에서 사용하는 중입니다라는 뜻입니다.
// 유니티에서 유니티를 활용해 작업하는 스크립트라면
// 위의 코드를 반드시 추가해주세요.(자동으로 추가되어 있습니다.)

//네임스페이스는 특정 기능을 하는 클래스의 대표적인 이름으로써 사용합니다.
namespace UnityTutorial2
{
    // UnityTutorial 영역에서 만들어진 SampleA 클래스
    public class SampleA
    {

    }
}

public class SampleA 
{
    
}

/// <summary>
/// 처음으로 만들어본 유니티의 스크립트
/// </summary>
public class Test : MonoBehaviour
    //MonoBehaviour는 클래스에 연결했을 경우
    //유니티 씬에 존재하는 오브젝트에 스크립트를 연결할 수 있게 해줍니다.
    //추가적으로 유니티에서 제공해주는 기능을 사용할 때 사용합니다.
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("오늘은 C# 스크립트를 배우는 날입니다.");
    }

    int count = 0;

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{count} 좌우 반복 뛰기");
        count++; //카운트가 1 증가한다.
    }
}
