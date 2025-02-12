using UnityEngine;

public class DelegateSample : MonoBehaviour
{
    //델리게이트(delegate)
    //함수를 대입할 수 있는 변수, 일반적으로 대리자라고 부릅니다.
    //해당 변수에는 함수가 대입되어 있으므로, 해당 변수를 실행하면
    //대입한 함수가 실행되는 방식을 가지고 있습니다.

    //선언 방법
    //접근제한자 delegate 타입 델리게이트명(매개변수)

    delegate void DelegateTest();
    delegate string DelegateText(float x);
    delegate int DelegateInt(int x, int y);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //델리게이트 사용
        //델리게이트명 변수명 = new 델리게이트명(함수명);
        DelegateTest dt = new DelegateTest(Attack);
        
        //함수처럼 호출합니다.
        dt();

        //내용 변경
        //변수명 = 함수명;
        dt = Guard;

        dt();

        //일반적인 함수 호출이 아닌 delegate 변수를 만들어서 객체 할당하는 이유?
        //1. delegate는 함수가 아닌 타입이기 때문
        //   매개변수로도 활용이 가능하고, return 타입으로 잡아주는 것도 가능

        //2. 델리게이트 체인(delegate Chain)
        //delegate는 +=을 통해 대리할 함수를 더 추가할 수 있고, -=를 통해
        //대리한 함수를 제거하는 것도 가능합니다.
        dt += Attack;
        dt += Attack;
        dt += Attack;
        dt();
    }
 

    void UseDelegate(DelegateTest dt)
    {
        dt();
    }

    DelegateTest Selection(int value)
    {
        if (value == 1)
            return Attack;
        else if (value == 2)
            return Guard;
        else
            return MoveLeft;
    }

    void Attack() => Debug.Log("공격!");
    void Guard() => Debug.Log("방어!");
    void MoveLeft() => Debug.Log("왼쪽 이동!");


}
