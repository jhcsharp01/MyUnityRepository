using UnityEngine;
//옵저버 패턴(Observer)
//한 오브젝트의 상태가 변경이되면 그 객체에 의존하고 있는 다른 객체들에게 자동으로 내용이 갱신되는 설계 방식

//abstract class는 인터페이스처럼 메소드에 대한 선언을 진행할 수 있는 클래스입니다.

/// <summary>
/// 옵저버에 대한 관리, 활용을 진행하기 위한 인터페이스
/// </summary>
public interface ISubject
{
    //옵저버 등록
    void Add(UObserver observer);
    //옵저버 제거
    void Remove(UObserver observer);
    //갱신
    void Notify();
}
public abstract class UObserver
{
    public abstract void OnNotify();
}

public class Observer1 : UObserver
{
    public override void OnNotify()
    {
        Debug.Log("UObserver action #1");
    }
}
public class Observer2 : UObserver
{
    public override void OnNotify()
    {
        Debug.Log("UObserver action #2");
    }
}