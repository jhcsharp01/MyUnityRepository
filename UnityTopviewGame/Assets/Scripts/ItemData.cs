using UnityEngine;

public enum ItemType
{ 
    arrow, key, life
}

public class ItemData : MonoBehaviour
{
    public ItemType type;
    public int count = 1;
    public int arrageId = 0; //식별 값

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //[타입에 따라 처리할 내용]
            switch (type)
            {
                case ItemType.arrow:
                    ArrowShoot shoot = collision.gameObject.GetComponent<ArrowShoot>();
                    ItemKeeper.hasArrows += count;
                    break;
                case ItemType.key:
                    ItemKeeper.hasKeys += count;
                    break;
                case ItemType.life:
                    if(PlayerController.hp < 3)
                    {
                        PlayerController.hp++;
                    }
                    break;
            }
            //[아이템 획득 시의 연출]
            //1. 아이템이 공통적으로 가지고 있는 콜라이더를 비활성화합니다.
            GetComponent<CircleCollider2D>().enabled = false;
            //2. 아이템이 공통적으로 가지고 있는 리지드바디를 통해 위로 튀어오르는 연출을 표현합니다.
            var item_rbody = GetComponent<Rigidbody2D>();
            item_rbody.gravityScale = 2.5f;
            item_rbody.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
            Destroy(gameObject, 0.5f);
        }
    }

}
