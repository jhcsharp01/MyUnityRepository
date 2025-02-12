using System;
using UnityEngine;
//event
//개체에 작업 실행을 알리는 메세지
//이벤트는 이벤트 가입자에게 특정 작업을 알려주는 기능

//Event Handler : 이벤트가 발생할 때 어떤 명령을 실행할지 지정해주는 것

//이벤트는 += 연산자를 통해 이벤트 핸들러를 이벤트에 추가할 수 있으며,
//-= 연산자를 통해 이벤트 핸들러를 삭제하는 것이 가능합니다.

//하나의 이벤트에는 여러 개의 이벤트 핸들러를 추가하는 것이 가능하며,
//추가한 핸들러들은 순차적으로 호출됩니다. 

class SpecialPortalEvent
{
    public event EventHandler Kill;

    int count = 0;

    public void OnKill()
    {
        CountPlus(); //킬 수 증가
        if(count == 5) //카운트가 5가 되면
        {
            count = 0; //리셋
            Kill(this, EventArgs.Empty); //이벤트 핸들러들을 호출합니다.
        }
        else
        {
            //일반적인 경우라면 이벤트 진행에 대한 출력
            Debug.Log($"킬 이벤트 진행 중입니다! [{count} / 5] ");
        }
    }
    public void CountPlus() => count++;

}

public class UnityEventSample : MonoBehaviour
{ 
    //1. 이벤트 정의
    //이벤트명   변수명 = new 이벤트명();
    SpecialPortalEvent specialPortalEvent = new SpecialPortalEvent();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //2. 이벤트 핸들러에 이벤트 연결
        specialPortalEvent.Kill += new EventHandler(MonsterKill);

        for(int i = 0; i <5; i++)
        {
            specialPortalEvent.OnKill(); //3. 이벤트 진행을 위해 기능 진행
        } 

    }

    //4. 이벤트가 발생했을 때 실행될 코드
    private void MonsterKill(object sender, EventArgs e)
    {
        Debug.Log("포탈이 열렸습니다.");
    }
}
