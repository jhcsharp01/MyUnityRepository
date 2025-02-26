using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name +"과 트리거 충돌 했습니다.");
        Destroy(other.gameObject);
    }
}
