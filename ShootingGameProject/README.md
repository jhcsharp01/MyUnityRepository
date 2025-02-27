# 유니티 슈팅 게임
 for study Unity 6

## 개요
>> 해당 프로젝트는 '인생 유니티 교과서'의 슈팅 게임을 유니티 6 환경에서 재구현한 프로젝트입니다.
>> <br>프로토 타입부터 마지막 빌드 단계까지의 단계적인 구성을 목표로 하고 있습니다.
>> <br> 각 명칭의 뜻은 다음과 같습니다.
>> <br> 프로토 타입 : 기본적인 게임의 흐름, 기능 구현
>> <br> 알파 타입 : 에셋 등을 착용해 이미지적인 부분의 완성
>> <br> 베타 타입 : 기능 최적화 및 정식 빌드
>> <br>※ 알파 타입 구현에서 매니저 코드의 경우 책 프로젝트와 다르게 바로 매니저 코드로 구현을 진행합니다.
  

## 목차
0. [완성 결과물 예시](#완성-결과물-예시)
1. [프로토 타입 구현](#프로토-타입-구현)

   1-1. [플레이어 만들기](#플레이어-배치)

   1-2. [총알 만들기](#총알-배치)

   1-3. [적 만들기](#적-배치)

   1-4. [적 생성 위치 배치](#적-생성-위치-배치)

   1-5. [데드라인 배치](#데드라인-배치)
2. [알파 타입 구현](#알파-타입-구현)

   2-1. [에셋 추가](#에셋-추가)

   2-2. [배경 추가](#배경-추가)

   2-3. [폭발 이펙트 추가](#폭발-이펙트-추가) 

   2-4. [사운드 추가](#사운드-추가)
   
   

2. [베타 타입 구현](#베타-타입-구현)

   3-1. [싱글톤 패턴](#싱글톤-패턴)

   3-2. [오브젝트 풀](#오브젝트-풀)
   
   3-2. [빌드](#빌드)

## 완성 결과물 예시
![image](https://github.com/user-attachments/assets/40c6d799-b95b-47c1-84c7-d56ea7bb10d8)
![image](https://github.com/user-attachments/assets/dbce268b-14fc-46da-8c5a-529adf840d3c)


# 프로토 타입 구현
### 해상도 및 조명 설정
1. 조명 비활성화 합니다.(3D 환경에서 만드는 2D 프로젝트이기에 2D에서 안쓰는 조명 기능 제거)
2. **Window -> Rendering -> Lighting**을 통해 창으로 이동합니다.

   창 이동 후 Environment 설정의 Environment Lighting Source를 Color로 설정합니다.

   Ambient Color를 흰색으로 설정합니다.

   Sun Source는 Directional Light를 등록합니다.

   빛 없이 물체의 색을 그대로 표현할 수 있습니다.

   
![image](https://github.com/user-attachments/assets/a9d4e3ae-6951-4436-8e9d-8201aa77577c)
![image](https://github.com/user-attachments/assets/e5f214e9-3df1-4714-87e2-149eeffdfae2)

4. 카메라의 Projection을 Orthographic으로 설정합니다.

   Environment의 Background Type은 Solid Color로 설정합니다.

   ![image](https://github.com/user-attachments/assets/396cf185-2006-48f4-9982-0645b0065d4b)

### 플레이어 배치
**Create -> 3D Object -> Cube**
(이미지는 알파 단계에서 적용합니다.)


![image](https://github.com/user-attachments/assets/356c53a1-ecdf-42a6-aa4e-8686d3f17e1b)

플레이어에 FirePosition 객체를 만들어 연결해줍니다.

![image](https://github.com/user-attachments/assets/89575b60-66d0-4be6-8b5f-d88b473b1a72)





PlayerMove.cs 파일을 연결합니다.
```cs
public class PlayerMove : MonoBehaviour
{
 public float speed = 5.0f;

// Update is called once per frame
void Update()
{
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    Vector3 dir = new Vector3(h, v, 0);
    transform.position += dir * speed * Time.deltaTime;
}

```

|이름|물체의 이동 공식|해석|
|-------|---------------|--------|
|등속 운동|![CodeCogsEqn](https://github.com/user-attachments/assets/9179ad4d-f76b-45e3-8963-3064b1963cf0)|미래의 위치 = 현재의 위치 + 속도 × 시간|
|등가속도 운동|![CodeCogsEqn (1)](https://github.com/user-attachments/assets/a3e2dd4d-1b64-4870-b72b-057765167aa0)|미래의 속도 = 현재의 속도 + 가속도 × 시간|
|가속도|![CodeCogsEqn (2)](https://github.com/user-attachments/assets/5b0baf76-f38e-42ff-b858-96c7ae6274e2)|힘 = 질량 × 가속도|


PlayerFire.cs 파일을 연결합니다.
```cs
public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;//총알 프리팹
    public GameObject firePosition; //총 발사 위치

     void Update()
    {
        if (Input.GetButtonDown("Fire1")) //Left Ctrl
        {
            for (int i = 0; i < poolSize; i++)
            {
               GameObject bullet = Instantiate(bulletFactory);
               bullet.transform.position = firePosition.transform.position;
            }          
        }
    }

}
```

### 총알 배치
**Create -> 3D Object -> Capsule**

(이미지 추가, 오디오 소스 추가, 파티클 추가는 알파 단계에서 진행합니다.)

![image](https://github.com/user-attachments/assets/7811c6a9-ef01-40ac-8c86-b146194a7d96)

Bullet.cs 파일을 연결합니다.

```cs
public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}

```

### 적 배치
**Create -> 3D Object -> Cube**

(이미지와 리지드 바디, 폭발 팩토리 등은 알파 단계에서 추가합니다.)

![image](https://github.com/user-attachments/assets/2fffd5d2-38db-41ac-b283-cf16a1386a05)

Enemy.cs 파일을 연결합니다.

```cs
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;
    private void Start()
    {
        int rand = Random.Range(0, 10);
        if(rand < 3)
        {
            var target = GameObject.FindGameObjectWithTag("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
            Destroy(collision.gameObject);
            Destroy(gameObject);
    }
}

```

### 적 생성 위치 배치

**Create -> Create Empty**

![image](https://github.com/user-attachments/assets/a724441c-1353-44d3-b467-f28085769a3b)

아이콘 배치

![image](https://github.com/user-attachments/assets/082824bc-2ba5-494a-987f-d67baa695b44)

EnemyManager.cs 연결

```cs 

public class EnemyManager : MonoBehaviour
{
    
    float currentTime;
    public float createTime = 1.0f;
    public GameObject enemyFactory;

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= createTime)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transfrom.position;
            currentTime = 0;
        }
    }
}

```

### 데드라인 배치

**Create -> 3D Object -> Cube**

![image](https://github.com/user-attachments/assets/8e078787-17e3-4c8b-8ece-f109d977bbb6)
![image](https://github.com/user-attachments/assets/62064804-12ba-460e-b3b3-b0248241c4ae)
![image](https://github.com/user-attachments/assets/a8bb2b82-24f3-4745-a993-e9bf24ac8d55)
![image](https://github.com/user-attachments/assets/2f2cbaef-7cb5-4afb-bde8-6091483bd14e)

계층 창 배치

![image](https://github.com/user-attachments/assets/fa91d898-a5aa-41a6-8b83-94d709a3e686)

씬 뷰 확인

![image](https://github.com/user-attachments/assets/cd4efd26-fccd-45b5-9e37-ab0a6caeba59)

레이어 처리, 적합한 오브젝트에 등록합니다.

![image](https://github.com/user-attachments/assets/d3c14e88-3988-4649-968c-eea7f46697ec)

**Edit -> Project Settings -> Physics 2D**

![image](https://github.com/user-attachments/assets/fd6c1f7c-f87d-4f7e-9a6b-761f66ecba16)

DestroyZone.cs 연결

```CS
public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {        
      Destroy(other.gameObject);
    }
}

```



# 알파 타입 구현

## 에셋 추가
|유형|링크|
|-----|---------------------------------|
|Player & Enemy|https://assetstore.unity.com/packages/3d/vehicles/air/awesome-cartoon-airplanes-56715|
|Bullet|https://assetstore.unity.com/packages/3d/props/weapons/rockets-missiles-bombs-cartoon-low-poly-pack-73141|
|VFX|https://assetstore.unity.com/packages/vfx/particles/cartoon-fx-remaster-free-109565|
|Background|[https://assetstore.unity.com/packages/audio/sound-fx/grenade-sound-fx-147490](https://assetstore.unity.com/packages/2d/textures-materials/space-star-field-backgrounds-109689)|
|SFX|https://assetstore.unity.com/packages/audio/sound-fx/grenade-sound-fx-147490|
|BGM|https://assetstore.unity.com/packages/audio/sound-fx/grenade-sound-fx-147490|


※ 배경 import 시 설정


![image](https://github.com/user-attachments/assets/ece122b9-7e61-42fc-889d-f9ae9c989712)


## 배경 추가

**Create -> 3D Object -> Quad**

**Create -> Material -> BaseMap에 이미지 추가 (URP/Lit) 기준**

![image](https://github.com/user-attachments/assets/228d3180-a370-4d67-b90c-eb20d6098f19)


위치 배치(플레이어보다 뒤에 배치해서 충돌하지 않도록)

![image](https://github.com/user-attachments/assets/8f5fce86-c9d6-4e48-8d88-693816e8cb1f)

background 객체에 Background.cs 추가

```cs
public class Background : MonoBehaviour
{
    public Material backgroundMaterial;
    public float scrollSpeed = 0.2f;
   
    // Update is called once per frame
    void Update()
    {
        backgroundMaterial.mainTextureOffset += Vector2.up * scrollSpeed * Time.deltaTime;
    }
}

```

## 폭발 이펙트 추가

Enemy.cs에 다음 코드를 추가합니다.

```cs

public GameObject explosionFactory;

private void OnCollisionEnter(Collision collision)
{
 GameObject explosion = Instantiate(explosionFactory);
 explosion.transform.position = transform.position;
 Destroy(collision.gameObject);
 Destroy(gameObject);
}
```

인스펙터 적용
![image](https://github.com/user-attachments/assets/94e45e88-fbb5-4222-ad87-294e4d8a2c7c)



## 사운드 추가

총알 오브젝트에 Audio Source 추가 후 리소스 적용

![image](https://github.com/user-attachments/assets/2d35a882-1dfc-474a-ad71-51b7f221f356)

폭발 오브젝트에도 동일하게 적용합니다.

# 베타 타입 구현

## 싱글톤 패턴

>> 싱글톤 패턴이란 단 하나의 유일한 객체를 만들기 위한 디자인 패턴을 의미한다.
>> 똑같은 데이터를 여러 개 만들면 무의미하기에 한번만 선언하고 가져와서 사용하는 것이 목적입니다.
>> 해당 객체가 리소스를 많이 차지하는 역할의 무거운 클래스일 경우 효과적입니다.
>> 어플리케이션 기준 유일하며, 유일한 것이 좋은 객체를 대상으로 만들어줍니다.

## 구현 원리(기본)
```cs
public class Singleton : MonoBehaviour
{
    public static Singleton Instance = null;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public int value;
    public void Method() {}
    public int Value { get; set; }
}
```
1. 자기 자신의 형태의 static 변수를 null로 설정한다.
2. 시작 단계에서 인스턴스가 null이라면, 자기 자신으로 설정한다.
3. Singleton.Instance.필드/메소드/프로퍼티 등으로 직접적인 연결없이 사용이 가능하다.



**인스펙터 배치**
![image](https://github.com/user-attachments/assets/37ab0e20-be12-4ca1-81c2-9c3e9ff0fb86)

**캔버스 배치**

![image](https://github.com/user-attachments/assets/23d27780-e2d6-4899-ae73-5386f5fc5c46)

**씬 뷰 배치**

![image](https://github.com/user-attachments/assets/4189550a-1db6-4c9a-9a94-72113e931ecf)

ScoreManager 객체 생성

ScoreManager.cs 연결

```cs
using UnityEngine;
using UnityEngine.UI;

//점수를 관리하는 유일한 매니저
public class ScoreManager : MonoBehaviour
{
    #region Singleton
    public static ScoreManager Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score");
        currentScoreUI.text = $"현재 점수 : {currenetScore}";
        bestScoreUI.text = $"최고 점수 : {bestScore}";
    }


    //Inspector
    public Text currentScoreUI;
    public Text bestScoreUI;

    //Inner
    private int currenetScore;
    private int bestScore;

    public int Score
    {
        get
        {
            return currenetScore;
        }

        set
        {
            currenetScore = value;
            currentScoreUI.text = $"현재 점수 : {currenetScore}";

            if(currenetScore > bestScore)
            { 
                bestScore = currenetScore;
                bestScoreUI.text = $"최고 점수 : {bestScore}";
                PlayerPrefs.SetInt("Best Score", bestScore); 
            }
        }
    }
}

```

## 오브젝트 풀

>> 오브젝트의 풀(Pool)을 만들어, 미리 오브젝트를 생성해두고, 비활성화해둡니다.
>> <br>필요한 상황에만 활성화를 진행해 사용하고, 사용이 마무리되면 다시 비활성화합니다.
>> <br>해당 개념은 매번 생성과 파괴가 반복됬을 경우 내부의 가비지 컬렉터(GC)가 발생하면서 메모리의 할당, 해제가 발생해 CPU에 무리를 주는 상황에 대한 해결책으로 나왔습니다.
>> <br>단 이 방식은 미리 오브젝트에 할당을 주고 시작하는 행위로, 자원이 넉넉한 상황이 아니면 사용할 수 없습니다.

**총알 생성 오브젝트 풀**

```cs
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;//총알 프리팹
    public GameObject firePosition; //총 발사 위치

    private int poolSize = 10;

    GameObject[] bulletObjectPool;

    private void Start()
    {
        //1. 설정된 크기만큼 풀에 오브젝트 생성
        bulletObjectPool = new GameObject[poolSize];

        //2. 수만큼 반복해 총알 생성

        for (int i = 0; i < poolSize; i++)
        {
            //총알 생성
            var bullet = Instantiate(bulletFactory);
            //풀에 등록
            bulletObjectPool[i] = bullet;
            //비활성화(필요할 때 활성화합니다.)
            bullet.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //Left Ctrl
        {
            for (int i = 0; i < poolSize; i++)
            {
                var bullet = bulletObjectPool[i];
        
                if(bullet.activeSelf == false)
                {
                    bullet.SetActive(true);
                    bullet.transform.position = firePosition.transform.position;
                    break;
                }
            }          
        }
    }
}

```

***적 생성 오브젝트 풀***

인스펙터 배치

![image](https://github.com/user-attachments/assets/4b7c26e0-ff74-4243-bcf9-b8da379cc4ce)


```cs
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    //현재의 시간
    float currentTime;

    //일정 시간
    public float createTime = 1.0f;
    
    //생성할 적
    public GameObject enemyFactory;

    float min = 1, max = 5;


    //오브젝트 풀 설정
    public int poolSize = 10;
    GameObject[] enemyObjectPool;

    //생성 위치(배열)
    public Transform[] spawnPoints;

    private void Start()
    {
        createTime = Random.Range(min, max);

        enemyObjectPool = new GameObject[poolSize];

        for(int i =0; i < poolSize; i++)
        {
            var enemy = Instantiate(enemyFactory);
            enemyObjectPool[i] = enemy;
            enemy.SetActive(false);
        }

    }


    private void Update()
    {
        //1. 시간이 흐른다.
        currentTime += Time.deltaTime;
        //2. 현재 시간이 일정 시간에 도달한다면
        //    적을 생성합니다.
        if(currentTime >= createTime)
        {

            for (int i = 0; i < poolSize; i++)
            {
                var enemy = enemyObjectPool[i];
                if (enemy.activeSelf == false)
                {
                    //랜덤 스폰
                    int index = Random.Range(0, spawnPoints.Length); 
                    enemy.transform.position = spawnPoints[index].position;
                    enemy.SetActive(true);
                    break;
                }
            }

            //3. 소환 후 시간을 0으로 리셋합니다.
            currentTime = 0;
            //createTime = Random.Range(min, max);
        }
    }
}

```

** 제거 관련 스크립트 수정 **

```cs
      private void OnEnable()...
      //Start -> OnEnable로 변경

    private void OnCollisionEnter(Collision collision)
    {
        ScoreManager.Instance.Score++;

        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        //부딪힌 물체의 이름이 Bullet이 포함된다면?
        //오브젝트 풀로 만들어질 이름은 Bullet(Clone)
        if(collision.gameObject.name.Contains("Bullet"))
        {
            //해당 충돌체를 비활성화 처리합니다.
            collision.gameObject.SetActive(false);
        }
        else
        {
            Destroy(collision.gameObject);
        }
        gameObject.SetActive(false); //적도 비활성화
    }
```

```cs
    private void OnTriggerEnter(Collider other)
    {        
        if(other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false);
        }
    }
```

# 빌드

**File -> Build Profiles -> Player Settings**

![image](https://github.com/user-attachments/assets/3e6e6278-8343-4799-920e-0a8bf583c90d)


**설정**

![image](https://github.com/user-attachments/assets/e5f571b3-11de-46a5-a52b-d79897141b53)


1. 컴퍼니명 설정

레지스트리로 확인해보는 컴퍼니 변경점
![image](https://github.com/user-attachments/assets/f5b8c5af-4922-4015-898f-1460b159b8bf)


2. 아이콘 변경
   
   기본 이미지를 사용하면 된다.
   
![image](https://github.com/user-attachments/assets/6bcc9dac-322f-4c79-a311-9a28b5876ffc)


4. 커서 변경

 이미지의 타입을 Cursor 형태로 설정해야 한다.

 ![image](https://github.com/user-attachments/assets/8b223664-cc97-4b37-bd8b-559e6ffea9fb)
 

5. 해상도 설정
   
   Resolution and Presentation 기능을 선택한다.

   ![image](https://github.com/user-attachments/assets/7d6d5024-232b-4371-a0d8-87643c823c86)

7. 스플래시 로고 설정'

   게임 시작 시의 로고에 대한 설정을 할 수 있다.
   
   유니티 6부터는 로고 제거 기능이 추가되었다.(기존에는 Pro, License)
   
   Preview 버튼을 누르면 에디터 내의 게임 씬에서 실행된다.
   
   Blur 처리 해제를 하면 배경이 정확히 보인다.
   
   Animation 모드를 설정할 수 있다. (static ,dolly, custom)
   
   ![image](https://github.com/user-attachments/assets/f3c2aca6-51e8-46ba-8e01-a3dd5cf18298)

   로고 이미지 설정

   스프라이트 모드가 Single이어야하며, 메쉬 타입은 Full Rect로 설정한다.

   ![image](https://github.com/user-attachments/assets/ecf05fbe-05cb-4694-a067-f523da329463)

   실행 예시
   
   ![image](https://github.com/user-attachments/assets/8ef1c0d3-2c6e-4589-a09a-cb36d797818e)


8. 빌드 진행

   설정이 다 끝났으면 Build를 통해 빌드를 진행한다. 이때 프로젝트 내부에 빌드하지 말고 별도의 폴더를 만들어서 따로 빌드한다.

   빌드 예시

   ![image](https://github.com/user-attachments/assets/f309916d-4627-4d6f-b049-5a957e2c6ccc)




