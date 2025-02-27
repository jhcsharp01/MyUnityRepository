using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    Transform target;
    Vector3 pos;
    double damage;
    string character_name;
    bool GetHit = false;

    Dictionary<string, GameObject> projectiles = new Dictionary<string, GameObject>();
    Dictionary<string, ParticleSystem> muzzles = new Dictionary<string, ParticleSystem>();


    private void Awake()
    {
        var pjs = transform.GetChild(0);
        var mzs = transform.GetChild(1);

        for (int i = 0; i < pjs.childCount; i++)
        {
            projectiles.Add(pjs.GetChild(i).name, pjs.GetChild(i).gameObject);
            Debug.Log(pjs.GetChild(i).name +"가 등록되었습니다.");
        }

        for(int i = 0; i < mzs.childCount; i++)
        {
            muzzles.Add(mzs.GetChild(i).name, mzs.GetChild(i).GetComponent<ParticleSystem>());
            Debug.Log(mzs.GetChild(i).name + "가 등록되었습니다.");
        }
    }

    public void Init(Transform tg, double dmg, string charname)
    {
        target = tg;
        transform.LookAt(target);
        GetHit = false;    
        pos = target.position;
        
        damage = dmg;
        character_name = charname;
        projectiles[charname].gameObject.SetActive(true);
    }


    IEnumerator ReturnObject(float timer)
    {
        yield return new WaitForSeconds(timer);
        Manager.POOL.pool_dict["Projectile"].ObjectReturn(gameObject);
    }


    private void Update()
    {
        if (GetHit) return;

        pos.y = 0.5f;

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, pos) <= 0.1f)
        {
            if(target != null)
            {
                GetHit = true;

                target.GetComponent<Character>().hp -= damage;

                projectiles[character_name].gameObject.SetActive(false);

                muzzles[character_name].Play();

                StartCoroutine(ReturnObject(muzzles[character_name].main.duration));
            }
        }
    }
}
