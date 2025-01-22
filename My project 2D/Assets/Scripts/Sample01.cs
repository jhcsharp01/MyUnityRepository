using UnityEngine;


public enum Rainbow
{ 
    RED, ORANGE, YELLOW, GREEN, BLUE, INDIGO, VIOLET
}


[AddComponentMenu("JH/Sample01")]
public class Sample01 : MonoBehaviour
{
    public bool jumpable;
    public string[] basket;
    public int money;
    [Range(1,99)] public int FieldofView;
    public Rainbow rainbow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
