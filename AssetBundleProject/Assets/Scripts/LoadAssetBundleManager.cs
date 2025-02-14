using System.Collections;
using System.IO;
using UnityEngine;

public class LoadAssetBundleManager : MonoBehaviour
{
    //경로 작성
    string path = "Assets/Bundles/asset1";
    void Start()
    {
        StartCoroutine(LoadAsync(path));   
    }
    IEnumerator LoadAsync(string path)
    {
        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));

        //리퀘스트가 끝날 때까지 대기
        yield return request;

        //리퀘스트를 통해 받아온 에셋 번들의 정보를 적용합니다.
        AssetBundle bundle = request.assetBundle;

        //전달받은 번들을 통해 에셋을 로드합니다.
        GameObject prefab = bundle.LoadAsset<GameObject>("Blue_Sphere");
        //LoadAsset<T>("이름");


        Instantiate(prefab);
    }

}
