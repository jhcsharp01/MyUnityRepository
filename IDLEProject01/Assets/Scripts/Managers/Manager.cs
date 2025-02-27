using System;
using UnityEngine;

//프로젝트에서 개발할 매니저(종합)
public class Manager : MonoBehaviour
{
    //싱글톤 개발
    public static Manager instance;

    private static PoolManager pool_manager = new PoolManager();
    public static PoolManager POOL 
    { 
        get
        {
            return pool_manager;
        }
    }


    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        if(instance == null)
        {
            instance = this;
            POOL.Initialize(transform);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
             
    }

    //Resources 폴더가 반드시 필요한 코드
    public GameObject CreateFromPath(string path)
    {
        return Instantiate(Resources.Load<GameObject>(path));
    }

}
