using System.IO;
using UnityEngine;
//Json 사용 방법(로드)
//1. 읽을 수 있는 데이터 형태로 만들어줍니다.
//2. 파일 경로 기반으로 json 파일을 찾아서 내부의 텍스트를 읽어냅니다.
//3. 읽어낸 데이터를 통해 클래스화를 진행합니다.
//4. 마음껏 쓰시면 됩니다.

[System.Serializable]
public class Item01
{
    public string name;
    public string description; 
}
public class JsonLoadSample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string load_json = File.ReadAllText(Application.dataPath + "/item01.json");
        //작업 폴더를 의미합니다.(유니티에서의 Assets 폴더 위치0
        var data = JsonUtility.FromJson<Item01>(load_json);
        Debug.Log(data.name);

        //데이터 변경
        data.name = "마음대로 바꿔보기";
        data.description = "우헿우헹우헤헿";

        //Json 파일로 내보내기(Save)
        File.WriteAllText(Application.dataPath + "/item02.json", JsonUtility.ToJson(data));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
