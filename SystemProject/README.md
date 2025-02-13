# 유니티 시스템 프로그래밍

## 목차
[1. 스크립터블 오브젝트(Scriptable Object)](#스크립터블-오브젝트(Scriptable-Object))

[2. 스크립터블 오브젝트 만드는 방법](#스크립터블-오브젝트-만드는-방법)

[3. 에셋 메뉴 설정](#CreateAssetMenu의-설정)
<hr/>

## 스크립터블 오브젝트(Scriptable Object)
>> 유니티에서 제공해주는 데이터 저장 객체로 게임 데이터를 관리하고, 여러 인스턴스에서 공유할 수 있도록 도와줍니다.

[장점]
>> 1. 동일한 적(오브젝트)의 정보등을 여러 오브젝트에서 공유해도 메모리는 한번만 차지합니다.
>> 2. 데이터와 로직을 분리해서 사용할 수 있습니다.<br>
>> **ex) 캐릭터의 능력치 등을 SO로 관리할 경우 스탯에 대한 수정을 쉽게 진행할 수 있습니다.**
>> 4. 런타임 중에 데이터의 수정이 가능합니다.

[단점]
>> 1. 복잡한 데이터 구조 등에서는 직렬화가 되지 않는 경우가 있어 데이터 손실 발생 위험이 있습니다.
>> 2. 멀티 쓰레드 환경에서는 데이터 처리 시 충돌 문제가 우려될 수 있습니다.<br>
>>    (이런 경우라면 데이터베이스 활용이 더 좋을 수 있습니다.)

**사용하기 좋은 예시**
>> 1. 게임에 대한 기본 설정 값<br>
  **(게임 난이도, 게임 사운드 설정, 컨트롤 설정)**
>> 2. 행동 패턴이나 능력치 등에 대한 설정
>> 3. 별도의 데이터베이스를 따로 구현하지 않는다는 전제로 아이템 데이터베이스를 만들기 좋습니다.

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


                                              [목차로](#목차)




























