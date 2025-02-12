using System;
using UnityEngine;
using UnityEngine.UI;

//delegate를 이용하면 이벤트를 더 쉽게 짤 수 있습니다.

class MeetEvent
{
    public delegate void MeetEventHandler(string message);
    public event MeetEventHandler meethandler;

    public void Meet()
    {
        meethandler("만난 것도 인연인데 어디가서 차라도 한잔...");
    }
}


public class UnityDelegateEventSample : MonoBehaviour
{
    public Text messageUI;
    MeetEvent meetEvent = new MeetEvent();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        meetEvent.meethandler += EventMessage;
    }

    private void EventMessage(string message)
    {
        //Debug.Log(message);
        messageUI.text = message;
    }

    public void OnMeetButtonEnter()
    {
        meetEvent.Meet();
    }


}
