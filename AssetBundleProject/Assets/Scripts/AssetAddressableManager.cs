using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetAddressableManager : MonoBehaviour
{
    //AssetReference�� Ư�� Ÿ���� �������� �ʰ� ��巹������ ���ҽ��� �����ϰ� �˴ϴ�.
    //AssetReferenceGameObject�� ��巹���� ���ҽ� �߿��� GameObject�� �ش��ϴ� ���� �����մϴ�.
    //AssetReferenceT�� ���׸��� �̿��� Ư�� ������ ��巹���� ���ҽ��� �����մϴ�.
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
        //Addressables.ReleaseInstance(go); //����
        capsule.ReleaseAsset();
    }
}
