using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectShooter : MonoBehaviour
{
    //발사 기능을 제공해주는 클래스
    //충돌 시 오브젝트를 고정시켜주는 역할도 진행합니다.
    GameObject objectGenerator;
    ObjectGenerator obj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectGenerator = GameObject.Find("ObjectGenerator");
        // == 오브젝트 탐색 기능 ==
        //씬에서 해당 이름을 가진 게임오브젝트를 찾아 그 값을 얻어오는 GameObject.Find() 기능
        //objectGenerator = GameObject.FindWithTag("Generator"); //Generator 태그를 가진 오브젝트를 탐색
        //obj = FindObjectOfType<ObjectGenerator>(); <> 안에 넣어준 타입에 맞는 오브젝트를 탐색

        //가장 쉬운 건 Find()
        //하지만 검색 범위가 너무 많아지면 불필요하게 성능 저하가 발생할 수 있음.
        //따라서 그때부터 Tag나 Type 등으로 검색범위를 제한해서 찾는 방식을 사용

        //씬에 해당 값이 없으면 null
    }
    /// <summary>
    /// 물체를 발사하는 기능을 가진 함수(메소드)
    /// </summary>
    /// <param name="direction">물체의 발사 방향</param>
    public void Shoot(Vector3 direction)
    {
        
        GetComponent<Rigidbody>().AddForce(direction);
        Debug.Log("맞았습니다!");
    }



    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponentInChildren<ParticleSystem>().Play();

        if(collision.gameObject.tag == "terrain")
        {
            Destroy(gameObject, 1.0f);
        }
        else //과녁인 경우
        {
            objectGenerator.GetComponent<ObjectGenerator>().ScorePlus(10);
        }

    }



}
