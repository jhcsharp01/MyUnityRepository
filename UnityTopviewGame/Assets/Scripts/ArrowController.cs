using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float remove = 2.0f; //제거되는 시간

    void Start()
    {
        Destroy(gameObject, remove);   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //충돌체의 트랜스폼이 화살의 부모 트랜스폼이 될겁니다.
        transform.SetParent(collision.transform);
        //접촉 이후에는 충돌 판정을 제거합니다.
        GetComponent<CircleCollider2D>().enabled = false;
        //물리 시뮬레이션도 비활성
        GetComponent<Rigidbody2D>().simulated = false;
    }
}
