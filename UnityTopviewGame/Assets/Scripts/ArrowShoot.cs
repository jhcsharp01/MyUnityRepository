using System;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public float speed = 12.0f;
    public float delay = 0.25f;
    public GameObject bowPrefab; //활
    public GameObject arrowPrefab;

    bool inAttack = false; //공격 모드인지 확인
    GameObject bowObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 pos = transform.position;
        bowObject = Instantiate(bowPrefab, pos, Quaternion.identity);
        bowObject.transform.SetParent(transform);
        //활 오브젝트의 부모는 플레이어입니다.
    }

    // Update is called once per frame
    void Update()
    {
        //left shift
        if(Input.GetButtonDown("Fire3"))
        {
            Attack();
        }


        //rotate bow , order
        float bowZ = -1; //캐릭터보다 앞에 나오게 됩니다.
        var player_controller = GetComponent<PlayerController>();

        if(player_controller.z > 30 && player_controller.z < 150)
        {
            bowZ = 1;
        }
        bowObject.transform.rotation = Quaternion.Euler(0, 0, player_controller.z);

        bowObject.transform.position = new Vector3(transform.position.x, transform.position.y, bowZ);
    }

    private void Attack()
    {
        //화살을 가지고 있고, 공격 상태가 아닌 경우
        if(ItemKeeper.hasArrows > 0 && inAttack == false)
        {
            ItemKeeper.hasArrows--; //화살 1개 소모
            inAttack = true; //공격 모드로 전환

            var player_controller = GetComponent<PlayerController>();

            float z = player_controller.z; //회전 각

            var rotation = Quaternion.Euler(0, 0, z);

            //계산한 회전 각으로 오브젝트를 생성합니다.
            var arrow_object = Instantiate(arrowPrefab, transform.position, rotation);

            float x = Mathf.Cos(z * Mathf.Deg2Rad);
            float y = Mathf.Sin(z * Mathf.Deg2Rad);

            Vector3 vector = new Vector3(x, y) * speed;

            var rbody = arrow_object.GetComponent<Rigidbody2D>();

            rbody.AddForce(vector, ForceMode2D.Impulse);

            //발사 딜레이만큼 지연 시켜서 공격 모드를 해제합니다.
            Invoke("AttackChange", delay);
        }
    }

    public void AttackChange() => inAttack = false;
}
