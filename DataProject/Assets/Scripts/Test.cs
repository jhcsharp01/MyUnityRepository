using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject preObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        preObject = null;

        Instantiate(preObject);   
    }

    // Update is called once per frame
    void Update()
    {
        int j = 0;
        //for (int i = 0; i < transform.childCount; j++)
        //{
        //}
        //while (true) ;
    }

    private void LateUpdate()
    {
        
    }
}
