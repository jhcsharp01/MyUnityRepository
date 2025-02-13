using UnityEngine;
using UnityEngine.UI;


public class BasicCode : MonoBehaviour
{
    //����Ƽ���� ���� Ŭ����
    //1. MonoBehavior�� ����Ǿ��ִ� Ŭ���� : ����Ƽ ���� ���� ������ �� �ִ� Ŭ����
    //2. �Ϲ� Ŭ���� : ����Ƽ ������ Ư�� �����͸� ������ �� ����մϴ�.
    //3. ScriptableObject�� ����Ǿ��ִ� Ŭ���� : ����Ƽ Assets ���� ���ο� ��ũ��Ʈ�� �ּ����� ������ �� �ִ� Ŭ����

    //1. ���� ������(Access modifier)
    //���α׷����� ���ٿ� ���õ� ������ ������ �� �ִ� Ű����
    // public  : ����Ƽ �ν����Ϳ��� Ȯ���� �����մϴ�.
    // private : ����Ƽ �ν����Ϳ��� Ȯ���� �� �����ϴ�.

    //[SerializeField] �Ӽ��� ���� �ʵ�(����)�� ��쿡�� �ν����Ϳ��� �����˴ϴ�.
    //[Serialiable] �Ӽ��� ���� Ŭ������ ������ ����� ��� �ν����Ϳ��� �����˴ϴ�.

    public int number;
    private int count;
    [SerializeField] private bool able;

    public Text text;
    public GameObject cube;
    public SampleCode s;

    //���� ������ �� 1�� ����Ǵ� �ڵ带 �ۼ��ϴ� ��ġ
    //�ַ� ���� ���� ������ ������ �� �ش� ��ġ���� �۾��� �����մϴ�.
    void Start()
    {
        cube = new GameObject();

        s = GameObject.Find("GameObject (1)").GetComponent<SampleCode>();

        //�Լ� ����(�Լ� ȣ��)
        //�Լ���(���ڰ�);

        //�Ű�����(parameter) : �Լ� ���� �� ȣ���ϴ� �ʿ��� �޾��� �����Ϳ� ���� ǥ��
        //�Լ��� () �κп� �ۼ��մϴ�. ex) Attack(int value)

        //����(Argment) : �Լ��� ȣ���� �� �־��ִ� ��

        NumberFive();
        Debug.Log(number);
        SetNumber(10);
        Debug.Log(number);
        TextHello();
    }

    //�޼ҵ� : Ŭ���� ���ο��� ��������� �Լ�  
    //�Լ�(Function) ?
    //>> ��ɹ� ����ü (Ư�� �ϳ��� ����� �����ϱ� ����)

    //�Լ� ����� ���
    //���������� ��ȯŸ�� �Լ���(�Ű�����) {  ������ ��ɹ�;  }

    //1. void ������ �Լ�
    // ==> ������ ��ɸ� ������ݴϴ�.
    public void NumberFive()
    {
        number = 5;
    }
    public void SetNumber(int value)
    {
        number = value;
    }
    //2. void �̿��� �Լ�
    // ==> ������ ������ �������� ���� ����ؼ� �����մϴ�.


    public void TextHello()
    {
        text.text = "Hello";
    }

}
