using UnityEngine;
//C# 일반화 프로그래밍(Generic Programming)
//데이터 형식에 대한 일반화를 진행하는 기법입니다.
//일반적으로는 <T>를 이용해서 설계하는 방식을 의미합니다.

public class GenericSample : MonoBehaviour
{
    //배열을 전달받아서 배열의 요소를 순서대로 출력하는 코드
    public static void printIArray(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Debug.Log(numbers[i]);
        }
    }
    public static void printFArray(float[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Debug.Log(numbers[i]);
        }
    }

    public static void printSArray(string[] words)
    {
        for (int i = 0; i < words.Length; i++)
        {
            Debug.Log(words[i]);
        }
    }


    public static void printGArray<T>(T[] values)
    {
        for (int i = 0; i < values.Length; i++)
        {
            Debug.Log(values[i]);
        }
    }


    void Start()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        float[] numbers2 = { 1.1f, 2.2f, 3.3f, 4.4f, 5.5f };
        string[] words = { "hello", "my name", "is", "Bae" };

        printGArray<int>(numbers);
        printGArray(numbers2);
        printGArray(words); 
    }

}
