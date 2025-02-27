# 유니티 슈팅 게임
 for study Unity 6

## 개요
>> 해당 프로젝트는 '인생 유니티 교과서'의 슈팅 게임을 유니티 6 환경에서 재구현한 프로젝트입니다.
   프로토 타입부터 마지막 빌드 단계까지의 단계적인 구성을 목표로 하고 있습니다.

## 목차
0. [완성 결과물 예시](#완성-결과물-예시)
1. [프로토 타입 구현](#프로토-타입-구현)

   1-1. [플레이어 만들기](#플레이어-배치)

   1-2. [총알 만들기](#총알-배치)

   1-3. [적 만들기](#적-배치)


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

3. 카메라의 Projection을 Orthographic으로 설정합니다.

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
