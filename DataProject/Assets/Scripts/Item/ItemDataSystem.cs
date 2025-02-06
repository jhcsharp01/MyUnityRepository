using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemDataSystem : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public Button loadButton;
    public bool interactable; //true or false
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nameInputField.onEndEdit.AddListener(ValueChanged);
        //이 방식으로 등록한 기능은 유니티 인스펙터에서 보이지 않습니다.
      
        loadButton.interactable = interactable;
        //버튼의 interactable은 사용자와의 상호작용 여부를 제어할 때 사용하는 값입니다.
    }
    //1. public으로 만든 함수는 유니티 인스펙터에서 직접 연결하겠습니다.
    //2. public이 아닌 함수는 스크립트 코드를 통해 기능을 연결해주겠습니다.


    public void Sample()
    {
        Debug.Log("INPUT FIELD'S ON VALUE CHANGED");
    }


    /// <summary>
    /// 작업이 마무리되었을 때 해당 문구를 입력했음을 알려주는 함수
    /// </summary>
    /// <param name="text">문구</param>
    void ValueChanged(string text)
    {
        Debug.Log($"{text} 입력 했습니다.");
    }
    
}
