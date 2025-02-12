 using UnityEngine;

public class UsingObserver : MonoBehaviour
{
    //옵저버 사용을 위한 델리게이트 변수 선언
    delegate void NotifyHandler();
    NotifyHandler _notifyHandler;

    private void Start()
    {
        Observer1 observer1 = new Observer1 ();
        Observer2 observer2 = new Observer2 ();

        _notifyHandler += new NotifyHandler(observer1.OnNotify);
        _notifyHandler += observer2.OnNotify;

        _notifyHandler();
    }
}
