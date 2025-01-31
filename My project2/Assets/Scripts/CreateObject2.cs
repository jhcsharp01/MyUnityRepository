using UnityEngine;

public class CreateObject2 : MonoBehaviour
{
    public GameObject prefab;

    private GameObject square;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        square = Instantiate(prefab);

        Destroy(square, 5.0f); //5초 뒤에 파괴합니다.
        Debug.Log("파괴되었습니다.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
