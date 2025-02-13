using System;
using UnityEngine;

public class ItemSample : MonoBehaviour
{
    //아이템 등록
    public Item item;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ItemInfo();
        }
    }

    private void ItemInfo()
    {
        Debug.Log(item.name); //스크립터블 오브젝트를 만들 때 붙여준 이름
        Debug.Log(item.id);   //스크립터블 오브젝트에서 설정한 값들
        Debug.Log(item.description);
        Debug.Log(item.price);
    }
}
