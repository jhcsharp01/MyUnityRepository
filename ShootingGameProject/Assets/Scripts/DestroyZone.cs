using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name +"�� Ʈ���� �浹 �߽��ϴ�.");
        Destroy(other.gameObject);
    }
}
