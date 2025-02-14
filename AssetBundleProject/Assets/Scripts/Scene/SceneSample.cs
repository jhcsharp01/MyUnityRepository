using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSample : MonoBehaviour
{
    //유니티 라이프 싸이클(life cycle)
    //유니티에서는 시작 단계부터 종료 단계까지를 함수로 제공합니다.
    //ex) Awake(시작 전) , Start(시작), Update(진행중) ...

    //활성화 되었을 경우
    private void OnEnable()
    {
        Debug.Log("OnSceneLoaded가 등록되었습니다.");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //비활성화일 경우
    private void OnDisable()
    {
        Debug.Log("OnSceneLoaded가 해제되었습니다.");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"현재 로드된 씬의 이름은 {scene.name}입니다.");
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            SceneManager.LoadScene("BRP Sample Scene");
            //따로 씬 모드를 설정하지 않으면 LoadSceneMode는 Single로 처리됩니다.
            //Single 모드의 설정은 씬을 갈아타도록 설정합니다.
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene("BRP Sample Scene",LoadSceneMode.Additive);
            //LoadSceneMode가 Additive일 경우는 기존 씬 위에 새로운 씬을 중복해서 로드하는 설정
            //당연히 이 작업을 진행할 경우 기본 오브젝트들(Main Camera , Direction Light) 등도
            //다 로드되기 때문에 주의해야 합니다.
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine("LoadSceneC");

            //SceneManager.LoadSceneAsync("BRP Sample Scene", LoadSceneMode.Additive);
            //비동기적(async) 로드

            //일반적인 씬의 로딩 작업은 동기적으로 처리됩니다.
            //씬이 로딩이 다될 때까지 다른 요소들은 작동하지 않게 됩니다.
        }
    }
    IEnumerator LoadSceneC()
    {
        yield return SceneManager.LoadSceneAsync("BRP Sample Scene", LoadSceneMode.Additive);
    }

}
