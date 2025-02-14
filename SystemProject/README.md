# 유니티 시스템 프로그래밍

## 목차
[1. 스크립터블 오브젝트(Scriptable Object)](#스크립터블-오브젝트(Scriptable-Object))

[2. 스크립터블 오브젝트 만드는 방법](#스크립터블-오브젝트-만드는-방법)

[3. 에셋 메뉴 설정](#CreateAssetMenu의-설정)

[4. 큐(Queue)](#Queue)

[5. 도전 과제](#과제)
<hr/>

## 스크립터블 오브젝트(Scriptable Object)
유니티에서 제공해주는 데이터 저장 객체로 게임 데이터를 관리하고, 여러 인스턴스에서 공유할 수 있도록 도와줍니다.

[장점]
1. 동일한 적(오브젝트)의 정보등을 여러 오브젝트에서 공유해도 메모리는 한번만 차지합니다.<br>
2. 데이터와 로직을 분리해서 사용할 수 있습니다.<br>
**ex) 캐릭터의 능력치 등을 SO로 관리할 경우 스탯에 대한 수정을 쉽게 진행할 수 있습니다.**<br>
4. 런타임 중에 데이터의 수정이 가능합니다.

[단점]
1. 복잡한 데이터 구조 등에서는 직렬화가 되지 않는 경우가 있어 데이터 손실 발생 위험이 있습니다.<br>
2. 멀티 쓰레드 환경에서는 데이터 처리 시 충돌 문제가 우려될 수 있습니다.<br>
   (이런 경우라면 데이터베이스 활용이 더 좋을 수 있습니다.)

**사용하기 좋은 예시**
1. 게임에 대한 기본 설정 값(게임 난이도, 게임 사운드 설정, 컨트롤 설정) <br>
2. 행동 패턴이나 능력치 등에 대한 설정
3. 별도의 데이터베이스를 따로 구현하지 않는다는 전제로 아이템 데이터베이스를 만들기 좋습니다.

<hr/>

## 스크립터블 오브젝트 만드는 방법

```cs
using UnityEngine;

[CreateAssetMenu]
public class 클래스명 : ScriptableObject
{
    필드
    메소드
    프로퍼티
}
```

![image](https://github.com/user-attachments/assets/453b7843-1c95-47db-902e-ae54125ec661)
<br> Create를 통해 만든 클래스명으로 등록이 되는 것을 볼 수 있습니다.

![image](https://github.com/user-attachments/assets/573e1226-4b7c-43f3-b420-ff2d39507e36)
<br> Create를 통해 만든 파일 예시

![image](https://github.com/user-attachments/assets/a996d3d2-e92a-4ccf-b401-c96eb91e29a7)
<br> 인스펙터를 통해 데이터를 확인해볼 수 있습니다.


![image](https://github.com/user-attachments/assets/b1aff16c-a352-4044-8f17-141ba144aace)
<br> 게임 오브젝트에 직접적으로 연결할 수 없습니다. 내부 데이터로만 활용합니다.


```cs
using UnityEngine;

[CreateAssetMenu(fileName ="파일명", menuName = "경로/메뉴", order = 숫자)]
public class 클래스명 : ScriptableObject
{
    
}
```
## CreateAssetMenu의 설정
|이름|내용|
|------|--------|
|fileName|생성되는 에셋의 이름|
|menuName|Create를 통해 만들어지는 메뉴의 이름을 설정합니다. /를 넣을 경우 경로가 추가됩니다.|
|order|메뉴 중에서 몇번째 위치에 존재할 지 표시할 때 설정하는 값, 값이 클수록 마지막에 표기됩니다.|


## 스크립터블 오브젝트 사용 예시

>> 해당 예제는 몬스터에게 드랍 테이블에 대한 정보를 줘 몬스터가 죽었을 때, 아이템이 드랍되는 연출을 위한 예제입니다.

```cs
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DropTable", menuName = "DropTable/drop table", order = 0)]
public class DropTable : ScriptableObject
{
    public List<GameObject> drop_table;
}

```


```cs
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public DropTable DropTable;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Dead();
        }
    }
    private void Dead()
    {
        GameObject dropItemPrefab = DropTable.drop_table[Random.Range(0,DropTable.drop_table.Count)];
        Instantiate(dropItemPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

```
![image](https://github.com/user-attachments/assets/5ba45f31-3e6c-4703-8013-5b8cf6f1cc4a)
<br> 드랍 아이템 테이블 SO 생성 후 값 배치

![image](https://github.com/user-attachments/assets/fdcae685-ac28-448d-9116-6e0be4aaaab3)
<br> 저장된 아이템(프리팹)

![image](https://github.com/user-attachments/assets/51b5d071-5f94-45b5-8290-ae35d17a77ec)
<br> 적 스크립트에 연결

![image](https://github.com/user-attachments/assets/ba2ea65e-43d4-4938-8a14-c76f2ee95a8c)
<br> 실행 결과(랜덤 생성 후 몬스터 제거)


<div align="right">
 
[목차로](#목차)

</div>
<hr>

## Queue
C# 자료구조 컬렉션 중 하나이며, 선입선출(First in First Out) 구조를 구현할 때 효과적입니다.

|이름|내용|형태|
|------|--------|--------|
|큐 생성|접근제한자 Queue<T> 큐 이름 = new Queue<T>();|-|
|큐에 데이터 추가|큐 이름.Enqueue(값)|-|
|첫번째 데이터 조회|큐 이름.Peek|return|
|큐 데이터 제거|큐 이름.Dequeue()|return|


## 과제
```
큐를 이용해서 만들기 괜찮은 시스템

조건 Assets/Scripts/Dialog 폴더 위치에서 작업할 것

1. 대화 시스템
IEnumerator, StartCoroutine, Queue, List 등을 활용해
구현할 수 있습니다.

만드는 방법
대화에 대한 데이터의 묶음을 따로 가지고 있습니다.
(클래스 or 스크립터블 오브젝트)

대화를 시작할 경우
큐에 해당 데이터들을 순서대로 Enqueue 합니다.

버튼이나 키를 눌러 다음 대화로 이동하는 기능을 추가합니다.
>> 전달받은 큐를 Dequeue합니다.

화면 상에 UI의 텍스트에 전달받은 값을 적용한다면
대화 기능처럼 보이게 될 것입니다.

추가적으로 텍스트가 타이핑되는 효과(코루틴 설계)와 함께한다면
더 실감나는 기능을 구현해볼 수 있습니다.


타이핑 텍스트?
화면상에서 텍스트를 타이핑하듯이 출력하는 것을 의미합니다.

만드는 방법
문장 길이만큼 반복해서 ui 텍스트에 단어 하나하나를 +=로 추가합니다.
1초나 0.1초 마다 한번씩 딜레이를 부여합니다.(코루틴)
```

```
퀘스트 시스템 만들기

퀘스트란?
게임 내에서 특정 상황에 맞춰서 시작하게 하는
조건 또는 요구 사항 등을 의미합니다.

퀘스트를 구현할 때 필요한 최소한의 것들

1.  퀘스트 진행 조건
  ex) 플레이어의 레벨
       특정 아이템을 가지고 있을 것
       다른 특정 퀘스트를 진행했을 경우 진행 가능

2.  퀘스트를 진행하는 방식
    ex) 특정 NPC와 대화를 진행한다.
        특정 아이템을 획득한다.(ex) 보석 10개를 수집합니다.)

3. 퀘스트의 보상
    ex) 돈, 아이템...
```

<div align="right">
 
[목차로](#목차)

</div>
<hr>





















