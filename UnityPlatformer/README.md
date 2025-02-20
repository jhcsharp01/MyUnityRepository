# 유니티 플랫포머 프로젝트

누구나 할 수 있는 유니티 2D 제작의 샘플을 기반으로 구성한 프로젝트
플랫포머의 기본 설정을 확인할 수 있고, <br>프로젝트 진행자는 추가적인 코드 작업을 통해
본인만의 색감있는 프로젝트로 확장하기를 기원합니다.

# 목차

- [사용 에셋](#사용-에셋)
- [태그 레이어 설정](#태그-레이어-설정)
- [캐릭터 구현](#캐릭터-구현)
- [맵](#맵)
- [타이틀 씬](#타이틀-씬)
- [UI 설계](#UI-설계)

# 사용 에셋
>> 디스코드 링크를 통해 다운 받아볼 수 있습니다.

![image](https://github.com/user-attachments/assets/8e988f32-e081-4bdf-be22-238038083545)

![image](https://github.com/user-attachments/assets/764065b1-eb21-49e3-99e1-301064ffeb36)


# 태그 레이어 설정
![image](https://github.com/user-attachments/assets/d97e4805-075e-41ad-ae77-f76cd3a9974a)



# 캐릭터 구현

## 1. 피봇(pivot 설정)

 ![image](https://github.com/user-attachments/assets/c4861a21-17bd-4445-be6d-736d14ec1451)
 
화면처럼 오브젝트의 중앙 지점이 bottom에 위치하도록 배치합니다.

![image](https://github.com/user-attachments/assets/9c7006bf-794f-4e8f-837d-a311c48fd35b)

인스펙터를 활용해 이미지의 Pivot을 Bottom으로 설정합니다.

## 2. 캐릭터 애니메이션 설정
   
![image](https://github.com/user-attachments/assets/53030ced-bf4e-4a55-a8b3-da0a83bb1089)

1개의 컨트롤러와 5개의 애니메이션 클립을 제작합니다.

![image](https://github.com/user-attachments/assets/92c38329-3a3c-4869-8f01-db0b9bf2b4a1)

애니메이터에 애니메이션 클립을 추가하고, 스크립트 코드를 통해 해당 애니메이션 클립을 불러오도록 설계합니다.

## 애니메이션 제작 방법

![image](https://github.com/user-attachments/assets/652fd2f8-e973-4703-a4f1-ce7967e3db25)

연속된 이미지를 드래그 해 씬에 배치하면 애니메이션 컨트롤러와 클립이 생성됩니다.


## 애니메이션 설정 방법

![image](https://github.com/user-attachments/assets/f8ad8ff3-53d1-478c-a777-7104bdd41e7f)

1. Animation을 실행합니다.(단축키 Ctrl + 6)
2. Animator 컴포넌트를 연결하고 있는 오브젝트를 씬에서 선택합니다.
3. Show Sample rate를 눌러 Samples를 추가합니다.

![image](https://github.com/user-attachments/assets/c96ddbb9-78d6-40ea-8b40-b751ff7c7a9c)

추가 전

![image](https://github.com/user-attachments/assets/115c9219-8208-407a-a387-d61f534a7e46)


추가 후

![image](https://github.com/user-attachments/assets/22896b9f-81ba-469a-8b3f-fd565d52c550)


## 작업할 애니메이션

|제목|설명|
|-----|----------------------------|
|PlayerClear|![image](https://github.com/user-attachments/assets/bfaaf856-44b3-4e87-9d0d-d7f204ed00db)|
|PlayerGameOver|![image](https://github.com/user-attachments/assets/5100fc81-168c-4ce8-9ef1-d4b8245cb4ad)|
|PlayerIDLE|![image](https://github.com/user-attachments/assets/6120054f-20b4-40e8-ad41-108983f1fcdf)|
|PlayerJump|![image](https://github.com/user-attachments/assets/1ab5771a-9f0f-49aa-be5a-f8cf42a05c93)|
|PlayerRun|![image](https://github.com/user-attachments/assets/5528d82c-0179-42ee-b1fe-53ab7e7baebd)|


## 스크립트 구현
![image](https://github.com/user-attachments/assets/1136ba72-f717-499a-bfac-81a500aae53a)

Ground Layer를 Ground로 설정


# 맵




# 타이틀 씬



# UI 설계























