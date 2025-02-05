using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectShooter : MonoBehaviour
{
    //�߻� ����� �������ִ� Ŭ����
    //�浹 �� ������Ʈ�� ���������ִ� ���ҵ� �����մϴ�.
    GameObject objectGenerator;
    ObjectGenerator obj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectGenerator = GameObject.Find("ObjectGenerator");
        // == ������Ʈ Ž�� ��� ==
        //������ �ش� �̸��� ���� ���ӿ�����Ʈ�� ã�� �� ���� ������ GameObject.Find() ���
        //objectGenerator = GameObject.FindWithTag("Generator"); //Generator �±׸� ���� ������Ʈ�� Ž��
        //obj = FindObjectOfType<ObjectGenerator>(); <> �ȿ� �־��� Ÿ�Կ� �´� ������Ʈ�� Ž��

        //���� ���� �� Find()
        //������ �˻� ������ �ʹ� �������� ���ʿ��ϰ� ���� ���ϰ� �߻��� �� ����.
        //���� �׶����� Tag�� Type ������ �˻������� �����ؼ� ã�� ����� ���

        //���� �ش� ���� ������ null
    }
    /// <summary>
    /// ��ü�� �߻��ϴ� ����� ���� �Լ�(�޼ҵ�)
    /// </summary>
    /// <param name="direction">��ü�� �߻� ����</param>
    public void Shoot(Vector3 direction)
    {
        
        GetComponent<Rigidbody>().AddForce(direction);
        Debug.Log("�¾ҽ��ϴ�!");
    }



    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponentInChildren<ParticleSystem>().Play();

        if(collision.gameObject.tag == "terrain")
        {
            Destroy(gameObject, 1.0f);
        }
        else //������ ���
        {
            objectGenerator.GetComponent<ObjectGenerator>().ScorePlus(10);
        }

    }



}
