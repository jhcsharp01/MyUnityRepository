using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    Animator animator;

    //�Ϲ����� ��ġ�� ������ ü���̳� ���ݷ� ���� ��ġ��
    //�ſ� ���� �� ����.
    public double hp;
    public double atk;
    //���� �ӵ��� �ʹ� ������ ������ �� �� ����.
    public float attack_speed;

    protected float attack_range = 3.0f; //���� ����
    protected float target_range = 5.0f; //Ÿ�ٿ� ���� ����
    protected bool isATTACK = false;
    protected Transform target; //Ÿ�ٿ� ���� ����(��ġ)
    public Transform bullet_transform;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected void SetMotionChange(string motion_name, bool param)
    {
        if(motion_name == "isATTACK")
        {
            animator.SetTrigger("isATTACK");
            return;
        }

        animator.SetBool(motion_name, param);
    }

    //animation event�� ���� ȣ��� �Լ�
    protected virtual void Thrown()
    {

        Manager.POOL.PoolObject("Projectile").GetGameObject((value) =>
        {
            value.transform.position = bullet_transform.position;
            value.GetComponent<Projectile>().Init(target, atk, "smoke");

        });

    }

    protected void InitAttack() => isATTACK = false;

    

    //Ÿ���� ã�� ���
    protected void TargetSearch<T>(T[] targets) where T : Component
    {
        var units = targets;//���޹��� ���� ���� �Ҵ�
        Transform closet = null; //���� ����� ���� ���� null
        float max_distance = target_range; //�ִ� �Ÿ� == Ÿ���� �Ÿ�

        //Ÿ�ٵ� ��ü�� ������� �Ÿ��� üũ�մϴ�.

        foreach(var unit in units)
        {
            //������ �Ÿ� üũ
            float distance = Vector3.Distance(transform.position, unit.transform.position);

            //Ÿ�� �Ÿ����� ������ ���� ����� ��
            if (distance < max_distance)
            {
                closet = unit.transform;
                max_distance = distance;
            }
        }
        //Ÿ�� ����
        target = closet;

        //Ÿ���� �����մϴ�.
        if (target != null)
            transform.LookAt(target.position);
    }


}
