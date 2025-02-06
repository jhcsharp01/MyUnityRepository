using UnityEngine;

public class DataSample : MonoBehaviour
{
    //1. 유니티 데이터의 저장
    //게임의 서비스 제공에서 가장 핵심이 되는 부분(데이터)

    //일반적인 작업 시, 플레이 하는 경우에만 점수 등이 설정되고
    //다시 플레이하면 기존의 기록들이 제거됨.

    //게임 여부에 따라 플레이할 때 기존의 정보를 가지고 진행하는 게임도 존재

    //PlayerPrefs는 주로 플레이어에 대한 환경 설정을 저장할 때 사용되는 클래스입니다.
    //해당 클래스는 문자열, 실수, 정수를 사용자의 플랫폼 레지스트리에 저장할 수 있습니다.

    //PlayerPrefs는 Key와 Value로 구성되어 있는 데이터입니다.(C#의 Dictionary)

    //Key는 Value에 접근하기 위한 데이터(실제 데이터의 위치)
    //Value는 Key를 통해 접근할 수 있는 실질적인 값

    //ex) userID : current147으로 저장되어있다면, userID가 Key, current147이 Value에 해당한다고 생각합니다.

    public UserData userData;
    //1. 유니티 에디터에서 따로 userData에 대한 정보를 다 작성하겠습니다.
    //2. 레지스트리에 있는 키 값을 검색해보겠습니다.
    //3. 키 전체 삭제

    private void Start()
    {
       /* PlayerPrefs.SetString("ID", userData.UserID);
         PlayerPrefs.SetString("UserName", userData.UserName);
         PlayerPrefs.SetString("Password", userData.UserPassword);
         PlayerPrefs.SetString("E-mail", userData.UserEmail);*/

        //Debug.Log("데이터가 저장되었습니다.");


        //Debug.Log(PlayerPrefs.GetString("ID"));

        //PlayerPrefs.DeleteAll(); //전체 삭제
        Debug.Log("데이터를 전부 삭제했습니다.");
    }

}
