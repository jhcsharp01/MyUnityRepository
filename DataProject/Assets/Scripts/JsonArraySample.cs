using System;
using System.Collections.Generic;
using UnityEngine;
//1. 배열 / List 형태로 저장되어있는 json 파일을 사용하는 예제
//2. Resources 폴더를 이용한 데이터 로드 방법을 사용합니다.

//      "item_name": "바나나",
//"item_count": 5

//묶음 안에 잇는 데이터 하나에 대한 표현
[Serializable]
public class Item
{
    public string item_name; //json 파일에서 사용하고 있는 이름을 그대로 사용합니다.
    public int item_count;
}
//묶음에 대한 표현
[Serializable]
public class Inventory
{
    public List<Item> inventory; //json 파일에서 사용하고 있는 이름을 그대로 사용합니다.
    //public Item[] inventory; 유니티에서는 배열과 리스트는 같은 취급
}

public class JsonArraySample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("item_inventory");

        Inventory inventory = JsonUtility.FromJson<Inventory>(textAsset.text);

        int total = 0; //아이템 최종 개수

        //foreach(타입 변수 in 배열/리스트)
        //배열이나 리스트가 가지고 있는 데이터 개수만큼 반복을 진행하는 전용 문법
        foreach(Item item in inventory.inventory)
        {
            total += item.item_count;
        }

        Debug.Log(total);

        //배열식 계산
  /*      for(int i = 0; i < inventory.inventory.Count; i++)
        {
            total += inventory.inventory[i].item_count;
        }*/


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
