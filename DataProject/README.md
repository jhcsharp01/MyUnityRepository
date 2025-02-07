# Unity BootCamp 2025 02 - 07 Sound and Video

<hr/>

## contents

+ Unity Sound
  
+ [Unity AudioSource](#unity-audiosource)
   
  + Unity AudioClip
  + Unity AudioMixer
    + [Exercise] Unity Audio Board Visualizer



<hr/>

# Unity AudioSource
> 씬에서 오디오 클립(AudioClip)을 재생하는 도구
재생을 하기 위해서는 오디오 리스너(Audio Listener)
나 오디오 믹서(Audio Mixer)를 통해서 재생이 가능합니다.
믹서의 경우는 따로 만들어야 하며,
오디오 리스너의 경우에는 메인 카메라에 붙어있습니다.

## AudioSource Property
|Property|Explain|
|--------|----------------------------|
|Audio Resource|재생을 진행할 사운드 클립에 대한 등록|
|Output|기본적으로는 오디오 리스너에 직접 출력됩니다.(None) <br> 만든 오디오 믹서가 있다면 그 믹서를 통해 출력합니다.|
|Mute|체크 시 음소거 처리|
|Bypass Effects|오디오 소스에 적용되어있는 필터 효과를 분리
|Bypass Listener Effect|리스너 효과를 키거나 끄는 기능|
|Bypass Reverb Zones|리버브 존을 키거나 끄는 효과 <br> ※리버브 존 : 오디오 리스너의 위치에 따라 잔향 효과를 설정하는 도구 |
|Play On Awake|해당 옵션을 체크했을 경우 씬이 실행되는 시점에 사운드 재생이 처리가 됩니다.<br>해당 기능 비활성화 시 스크립트를 통해 Play() 명령을 진행해 사운드를 재생합니다.|
|Loop |옵션 활성화 시 재생이 끝날 때 오디오 클립을 루프합니다.|
|Priority|오디오 소스의 우선 순위<br> 0 = 최우선<br> 128 = 기본<br> 256 = 최하위|             
|Volume|리스너 기준으로 거리 기준 소리에 대한 수치<br> 컴퓨터 내의 소리를 재생하는 여러 가지 요소 중 하나를 제어	|         
|Pitch|재생 속도가 빨라지거나 느려질 때의 피치 변화량<br>1은 일반 속도<br>최대 수치 3|
|Stereo Pan|소리 재생 시 좌우 스피커 간의 소리 분포를 조절 기능<br>-1 : 왼쪽 스피커<br>0 : 양쪽 균등<br>1 : 오른쪽 스피커|
|Spatial Blend|0 : 사운드가 거리와 상관없이 일정하게 들어갑니다. <br> 1 : 사운드가 사운드 트는 도구의 거리에 따라 변화 |    
|Reverb Zone mix|리버브 존에 대한 출력 신호 양을 조절합니다.<br>0 :  영향을 받지 않겠습니다.<br>1 : 오디오 소스와 리버브 존 사이의 신호를 최대치<br>1.1 : 10db 증폭|     
                     
<hr/>

[Unity AudioSource](#unity-audiosource)
