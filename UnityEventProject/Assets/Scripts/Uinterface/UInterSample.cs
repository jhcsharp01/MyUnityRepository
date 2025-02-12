using UnityEngine;
using UnityEngine.EventSystems;

//유니티에서 제공해주는 Event , IPointer

//IPointer Interface
//Unity의 EventSystems에서 기본적으로 제공되는 인터페이스입니다.
//사용하기 위해서는 다음과 같은 조건이 필요합니다.

//클릭, 터치, 드래그 등의 이벤트를 구현할 때 사용합니다.

//1. UI 오브젝트에는 Graphic Raycaster 컴포넌트가 추가되어있어야 합니다.
//   추가적으로 Raycast Target이 체크가 된 상태여야 합니다.

//2. Scene에는 Event System 컴포넌트가 존재해야 합니다.

//3. 오브젝트에 대한 작업 시에는 Collider 컴포넌트가 추가되어있어야 합니다.

//4. Main Camera에 Physics Raycaster 컴포넌트가 추가되어 있어야 합니다.


public class UInterSample : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("클릭을 진행했습니다!");
    }
    //사용 방법
    //1. 이 기능을 사용할 오브젝트에 연결합니다.
    //2. 씬에 Event System 오브젝트를 배치합니다.
    //   만약에 씬에 캔버스 생성을 진행했다면, 자동으로 배치가 되며
    //   아닌 경우라면 따로 만들어서 연결합니다.
    //3. 오브젝트에 콜라이더를 연결합니다.
    //4. 카메라에 Physics Raycaster 컴포넌트를 연결합니다.

    //IPointerClickHandler
    //해당 I를 추가하면 마우스를 클릭 또는 터치할 때 한번 호출되는 이벤트
    //누르고 뗏을 경우 호출됩니다.

    //IPointerDownHandler
    //누르는 순간에 호출되는 마우스 클릭/터치 이벤트입니다.

    //IPointerUpHandler
    //뗀 상황에 호출되는 마우스 클릭/터치 이벤트입니다.

    //IBeginDragHandler
    //드래그 진입 시 호출되는 이벤트

    //IEndDragHandler
    //드래그 끝날 때 호출되는 이벤트

    //IDragHandler
    //드래그 진행 동안 호출되는 이벤트
}
