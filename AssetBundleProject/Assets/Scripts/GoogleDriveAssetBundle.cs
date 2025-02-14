using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;

public class GoogleDriveAssetBundle : MonoBehaviour
{

    //private string imageFileURL = "https://drive.usercontent.google.com/u/0/uc?id=1Ze_wU_EF6Sp_5Pl9EGjQ7xf5G3CR0YCB&export=download";
    private string imageFileURL = "http://drive.google.com/uc?export=download&id=11wh7-sj_NWNEcqMYgCStlJVFiPpaz9d5";
    public Image image;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("DownLoadImage");
    }

    IEnumerator DownLoadImage()
    {
        //�ش� �ּ�(URL)�� ���� �ؽ�ó�� ������Ʈ ��û�մϴ�.
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageFileURL);

        //������Ʈ�� �Ϸ�� ������ ����մϴ�.
        yield return www.SendWebRequest();

        //������Ʈ�� ����� �����̶��
        if(www.result == UnityWebRequest.Result.Success)
        {
            //�ٿ���� �ؽ�ó�� �����ϴ� �ڵ�
            var texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            //Texture2D�� UI���� ���� ���� Sprite ���·� ����
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1.0f);

            Debug.Log("�̹����� ���������� �����Խ��ϴ�.");

            image.sprite = sprite;
        }
        else
        {
            Debug.LogError("�̹����� �������� ���߽��ϴ�.");
        }
    }

}
