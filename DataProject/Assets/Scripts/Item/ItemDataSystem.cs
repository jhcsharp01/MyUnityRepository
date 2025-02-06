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
        //�� ������� ����� ����� ����Ƽ �ν����Ϳ��� ������ �ʽ��ϴ�.
      
        loadButton.interactable = interactable;
        //��ư�� interactable�� ����ڿ��� ��ȣ�ۿ� ���θ� ������ �� ����ϴ� ���Դϴ�.
    }
    //1. public���� ���� �Լ��� ����Ƽ �ν����Ϳ��� ���� �����ϰڽ��ϴ�.
    //2. public�� �ƴ� �Լ��� ��ũ��Ʈ �ڵ带 ���� ����� �������ְڽ��ϴ�.


    public void Sample()
    {
        Debug.Log("INPUT FIELD'S ON VALUE CHANGED");
    }


    /// <summary>
    /// �۾��� �������Ǿ��� �� �ش� ������ �Է������� �˷��ִ� �Լ�
    /// </summary>
    /// <param name="text">����</param>
    void ValueChanged(string text)
    {
        Debug.Log($"{text} �Է� �߽��ϴ�.");
    }
    
}
