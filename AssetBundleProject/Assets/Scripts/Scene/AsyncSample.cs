using System.Threading.Tasks;
using UnityEngine;

//����(synchronous)
//Task(�۾�)�� ���������� �����ϴ� ���
//�ϳ��� �۾��� �Ϸ�� ������ ���� �۾��� ��� ���·� �����˴ϴ�.

//�񵿱�(Asynchornous)
//���� ���� �۾�(Task)�� ���ÿ� ó���ϴ� ����Դϴ�.

public class AsyncSample : MonoBehaviour
{
    void Start()
    {
        Debug.Log("�۾��� �����մϴ�.");
        Sample1();
        Debug.Log("Process A");
    }

    //async Ű����� �񵿱� �޼ҵ带 ������ �� ����ϴ� Ű�����Դϴ�.
    //�޼ҵ��� ���� ������� �񵿱������� �����մϴ�.

    //�ش� Ű����� �޼ҵ�, ���ٽ� � ���� �� �ֽ��ϴ�.
    //�ش� Ű���尡 ���� �޼ҵ�� Task, Task<T> �Ǵ� void�� return�ϰ� �˴ϴ�.

    //Task�� �񵿱� �۾��� ��Ÿ���� Ŭ�����Դϴ�.
    //System.Threading.Tasks ������ �����մϴ�.
 
    //await�� �񵿱� �޼ҵ� ������ ���Ǵ� Ű�����Դϴ�.
    //�ش� Ű����� Task�� Task<T>�� return�ϴ� �޼ҵ峪 ǥ���� �տ� ����� �� �ֽ��ϴ�.

    //�ش� �񵿱� �۾��� �Ϸ�� ������ ������ �޼ҵ带 ������ŵ�ϴ�.
    //�۾��� �Ϸ�Ǹ� �ٽ� �ش� �޼ҵ带 ��� �����ŵ�ϴ�.

    private async void Sample1()
    {
        Debug.Log("Process B");
        await Task.Delay(10000);
        Debug.Log("Process C");
    }
}
