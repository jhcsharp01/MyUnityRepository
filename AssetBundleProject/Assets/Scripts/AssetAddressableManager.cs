using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetAddressableManager : MonoBehaviour
{
    //AssetReference는 특정 타입을 지정하지 않고 어드레서블의 리소스를 참조하게 됩니다.
    //AssetReferenceGameObject는 어드레서블 리소스 중에서 GameObject에 해당하는 값을 참조합니다.
    //AssetReferenceT는 제네릭을 이용해 특정 형태의 어드레서블 리소스를 참조합니다.
    public AssetReferenceGameObject capsule;

    public GameObject go;

    private void Start()
    {
        StartCoroutine("Init");
    }

    private IEnumerator Init()
    {
        var init = Addressables.InitializeAsync();
        yield return init;
    }

    public void OnCreateButtonEnter()
    {
        capsule.InstantiateAsync().Completed += (obj) =>
        {
            go = obj.Result;
        };
    }

    public void OnReleaseButtonEnter()
    {
        //Addressables.ReleaseInstance(go); //해제
        capsule.ReleaseAsset();
    }
}
