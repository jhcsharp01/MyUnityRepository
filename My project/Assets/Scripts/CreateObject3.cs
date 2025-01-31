using UnityEngine;

public class CreateObject3 : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private int dummy;
    //직렬화
    //데이터나 오브젝트를 컴퓨터 환경에 저장하고 재구성할 수 있는 형태(포맷)로 변환하는 과정
    //유니티에서는 간단하게 private 형태의 데이터를 인스펙터에서 읽을 수 있게 설정해준다라고 이해해봅시다.
    [SerializeField] GameObject sample;

    void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Table_Body");
    }


    void Update()
    {
        //입력받은 키가 스페이스일 경우
        //GetKeyDown (키 1번 입력)
        //GetKeyUp(입력 후 뗏을 경우)
        //GetKey(누르고 있는 동안)
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            //Resources.Load<T>("폴더위치/애셋명");

            //T는 데이터의 형태를 적어주는 위치입니다.

           //Sprite sprite = Resouces.Load<Sprite>("Sprites/sprite01");

            sample = Instantiate(prefab);
            sample.AddComponent<VectorSample>();
            //gameObject.AddComponent<T>
            //오브젝트에 컴포넌트 기능을 추가하는 기능입니다.
            //GetComponent<T>
            //오브젝트가 가지고 있는 컴포넌트의 기능을 얻어오는 기능
            //스크립트에서 해당 컴포넌트의 기능을 가져와서 사용하고 싶을 경우 사용합니다.
        }
    }



}
