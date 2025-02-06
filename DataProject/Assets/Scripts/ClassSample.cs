using UnityEngine;
//기본적인 유니티 class 데이터 사용법
class Unit
{
    //클래스에는 해당 클래스로 만들 객체의 정보를 작성합니다.
    public string unit_name;

    //클래스는 해당 클래스로 만들 객체의 동작, 기능을 작성할 수 있습니다.(메소드)
    public static void UnitAction()
    {
        Debug.Log("유닛이 동작합니다.");
    }

    public void Cry()
    {
        Debug.Log("유닛이 울부짖었습니다.");
    }
}


public class ClassSample : MonoBehaviour
{
    
    Unit unit; //Unit 클래스 선언으로 만든 unit 객체(object) 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        unit.unit_name = "MiniGun";    
        //클래스변수명.필드를 통해 클래스가 가지고 있는 필드(변수)를 사용할 수 있습니다.

        unit.Cry();
        //인스턴스명.메소드()를 통해 클래스가 가지고 있는 메소드(함수)를 사용할 수 있습니다.

        //클래스 결과물에 대한 명칭
        //객체 : 실제 데이터, 클래스는 이 객체를 만들기 위한 템플릿 개념(선언만 해도 객체)
        //ex) Animal cat; (객체)
        //    Animal cat = new Animal(); (객체)

        //레퍼런스 : 객체의 메모리 상에서의 위치를 가리키는 것
        //클래스나 배열, 인터페이스 등에 해당합니다.

        //인스턴스 : 객체를 소프트웨어에서 실체화한 것(new를 통해서 만들어졌으면 인스턴스)
        //ex) Animal cat = new Animal();


        Unit.UnitAction(); 
        //static이 붙은 변수나 함수는 객체를 생성하지 않고 클래스에서 바로 그 기능을 가져와 사용합니다.

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
