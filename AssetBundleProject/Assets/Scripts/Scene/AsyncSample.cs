using System.Threading.Tasks;
using UnityEngine;

//동기(synchronous)
//Task(작업)을 순차적으로 실행하는 방식
//하나의 작업이 완료될 때까지 다음 작업은 대기 상태로 유지됩니다.

//비동기(Asynchornous)
//여러 개의 작업(Task)를 동시에 처리하는 방식입니다.

public class AsyncSample : MonoBehaviour
{
    void Start()
    {
        Debug.Log("작업을 시작합니다.");
        Sample1();
        Debug.Log("Process A");
    }

    //async 키워드는 비동기 메소드를 선언할 떄 사용하는 키워드입니다.
    //메소드의 실행 방식으로 비동기적으로 설정합니다.

    //해당 키워드는 메소드, 람다식 등에 사용될 수 있습니다.
    //해당 키워드가 붙은 메소드는 Task, Task<T> 또는 void를 return하게 됩니다.

    //Task는 비동기 작업을 나타내는 클래스입니다.
    //System.Threading.Tasks 영역에 존재합니다.
 
    //await는 비동기 메소드 내에서 사용되는 키워드입니다.
    //해당 키워드는 Task나 Task<T>를 return하는 메소드나 표현식 앞에 사용할 수 있습니다.

    //해당 비동기 작업이 완료될 때까지 현재의 메소드를 중지시킵니다.
    //작업이 완료되면 다시 해당 메소드를 계속 진행시킵니다.

    private async void Sample1()
    {
        Debug.Log("Process B");
        await Task.Delay(10000);
        Debug.Log("Process C");
    }
}
