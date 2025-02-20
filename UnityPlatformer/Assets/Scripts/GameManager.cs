using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject main_image;
    public Sprite game_over_sprite;
    public Sprite game_clear_sprite;
    public GameObject panel;
    public GameObject restartButton;
    public GameObject nextButton;

    Image image;

    //--- Time Controller ---
    public GameObject time_bar;
    public GameObject timeText;
    TimeController timeController;

    void Start()
    {
        //타임 컨트롤러 연결 및 설정
        timeController = GetComponent<TimeController>();

        if (timeController != null)
        {
            if(timeController.game_time == 0.0f)
            {
                time_bar.SetActive(false); //시간 제한이 없다면 숨기겟습니다.
            }
        }
        //내용 텍스트와 패널에 대한 설정

        //1초 뒤에 해당 함수를 호출합니다.
        Invoke("InactiveImage", 1.0f);
        //패널 비활성화
        panel.SetActive(false);
    }

    void InactiveImage()
    {
        main_image.SetActive(false);
    }

    void Update()
    {
        if(PlayerController.state == "gameclear")
        {
            //이미지 활성화
            main_image.SetActive(true);
            //패널 활성화
            panel.SetActive(true);
            //다시 시작 버튼에 대한 비활성화(게임을 클리어했으니까)
            restartButton.GetComponent<Button>().interactable = false;
            //메인 이미지를 게임 클리어 이미지로 변경합니다.
            main_image.GetComponent<Image>().sprite = game_clear_sprite;
            //플레이어 컨트롤러의 상태를 end로 변경합니다.
            PlayerController.state = "end";

            if(timeController != null)
            {
                timeController.is_timeover = true;
            }
        }
        else if(PlayerController.state == "gameover")
        {
            //이미지 활성화
            main_image.SetActive(true);
            //패널 활성화
            panel.SetActive(true);
            //다음 버튼에 대한 비활성화(게임을 클리어하지 못했기 때문)
            nextButton.GetComponent<Button>().interactable = false;
            //메인 이미지를 게임 클리어 이미지로 변경합니다.
            main_image.GetComponent<Image>().sprite = game_over_sprite;
            //플레이어 컨트롤러의 상태를 end로 변경합니다.
            PlayerController.state = "end";

            if (timeController != null)
            {
                timeController.is_timeover = true;
            }
        }
        else if (PlayerController.state == "playing")
        {
            //게임 진행 시에 대한 추가 처리를 구현하는 자리

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            PlayerController playerController = player.GetComponent<PlayerController>();

            if (timeController != null)
            { 
                if(timeController.game_time > 0.0f)
                {
                    //표기상 정수로 보이게 설정(소수점 버립니다.)
                    int time = (int)timeController.display_time;
                    //시간 갱신(UI)
                    timeText.GetComponent<Text>().text = time.ToString();

                    if(time == 0)
                    {
                        playerController.GameOver();
                    }
                }
            }
        }
    }
}
