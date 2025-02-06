using UnityEngine;

public class UserDataSystem : MonoBehaviour
{
    public UserData data01;
    public UserData data02;


    //PlayerPrefs 기능
    //1. DeleteAll() 삭제 기능
    //2. DeleteKey(키 이름) : 해당 키와 해당하는 값을 삭제합니다.
    //3. GetFloat/Int/String(키 이름) : 키에 해당하는 값을 return 합니다.
    //                                 데이터 타입에 맞춰서 사용합니다.
    //4. SetFloat/Int/String(키 이름, 값) : 해당 키 - 값을 생성합니다.
    //                                  기존에 같은 키가 있다면,
    //                                  값만 변경됩니다.
    //5. HasKey(키 이름) : 해당 키가 존재하는지를 확인합니다. 


    private void Start()
    {
        data01 = new UserData();
        //클래스 생성 방법
        //클래스변수(레퍼런스)명 = new 생성자();

        data02 = new UserData("sample0206", "choi", "asd123", "choi0210@naver.com");
        
        //data02의 데이터를 아이디,이름,비밀번호,이메일 순으로 빼옴.
        string data_value = data02.GetData();
        Debug.Log(data_value);

        PlayerPrefs.SetString("Data01", data_value); //그 데이터로 Data01로 저장
        //PlayerPrefs.Save(); //변경된 값 전부 저장

        data01 = UserData.SetData(data_value); //data01을 전달받은 데이터로 설정
        Debug.Log(data01.GetData()); //data01에 제대로 전달됬는지 확인
    
    }


}
