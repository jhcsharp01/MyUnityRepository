using System;
using UnityEngine;

//유니티에서 제공해주는 델리게이트
//1. using System; 필요

public class UnityDelegateSample : MonoBehaviour
{
    //1) Action delegate
    //반환 타입이 따로 없는 형태(void)의 대리자
    //Action delegate명;
    Action action;

    //2. 매개변수가 있는 경우
    //Action<T> delegate명;
    Action<int> action2;
    Action<string, int> action3;

    //2) Func delegate
    //반환 타입을 가지는 형태의 대리자
    Func<int> func01;

    Func<int, int, int> func02;
    //반환 타입은 int, 매개변수는 (int, int)

    Func<int, int, string> func03;
    //Func<매개변수 , 반환 타입> 형태로 작성합니다.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        action = Sample;
        action();
        action2 = Sample;
        action3 = Sample;

        //대리자의 경우 바로 기능을 구현해서 사용하는 것도 가능합니다.
        func01 = () => 10;
        func01 = Test;

        //만드는 방법
        //Funt<T> 이름 = (매개변수 작성 위치) => 값;
        Func<int> test = () => 25;

        //매개변수가 존재하는 경우
        func02 = (a, b) => a + b;

        //식을 여러개 적어야 하는 경우
        func02 = (a, b) =>
        {
            if (a > b)
            {
                a = b;
            }
            return a + b;
        };

        func03 = (a, b) => "a + b";
    }


    int Test()
    {
        return 10;
    }

    
    //오버로딩(Overloading) 개념
    //일반적으로 함수명은 고유하게 존재합니다.
    //하지만 다음 조건을 지킬 경우 같은 이름의 메소드를 사용할 수 있습니다.

    //매개변수의 개수 , 타입, 순서가 다르다면 같은 이름으로 메소드 정의가 가능합니다.

    //오버로딩 사용을 통해 약간의 상황에 따라 매번 메소드의 이름을 만들어줄 필요 없이
    //특정 기능을 진행하는 같은 이름의 메소드를 만들어 이름을 절약할 수 있습니다.


    //오버라이딩(Overriding)
    //부모 클래스로부터 상속받은 메소드를 자식 클래스에서 재정의하는 행의
    //인터페이스, abstract class 등에서 선언(정의)만 되어있는 메소드를 전달받은 경우라면
    //강제적으로 구현해야 합니다.

    //하위 클래스에서 원하는 기능에 대한 구현
    //인터페이스, abstract class 등에서 제공받은 틀에 맞춰 정돈된 코드 설계 가능
    //하나의 객체로 여러 형태를 표현하는 다형성 구현에도 효과적

    public void Sample() { }
    public void Sample(int b) {  }
    
    public void Sample(int a, string s) { }
    public void Sample(string s, int a) { }
    

    public int Sample3() { return 0; }

}
