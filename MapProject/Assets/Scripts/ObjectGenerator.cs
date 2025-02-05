using TMPro;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    //1. �� Ŭ������ ������Ʈ�� �����ϴ� ����� ������ �ֽ��ϴ�.
    //2. ���콺 ��ư�� ������ ��, ī�޶��� ��ũ�� ������ ����
    //   ��ü�� ������ �����մϴ�.
    //3. ��ü�� ���⿡ ���� �߻��ϴ� ����� ȣ���ؿ��ڽ��ϴ�.

    public GameObject prefab; //������Ʈ ������ ���
    public GameObject scoreText; //���� ǥ��ǥ
    public float power = 1000f; //��ô ���ݷ�
    public int score = 0; //����

    private void Start()
    {
        scoreText = GameObject.Find("score"); //���� ������ score�� ã�Ƽ� ���
        SetScoreText(); //���� 1ȸ
    }

    /// <summary>
    /// ���� ȹ��
    /// </summary>
    /// <param name="value">��ġ</param>
    public void ScorePlus(int value)
    {
        score += value;
        SetScoreText();
    }

    /// <summary>
    /// �� ������ ���� ���
    /// </summary>
    void SetScoreText()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = $"���� : {score}";
    }


    // Update is called once per frame
    void Update()
    {
        //~~down : Ŭ�� �� 1��
        //~~up :��ư�� ������ �� 1��
        // : Ŭ���ϰ� �ִ� ���� ����

        //���콺 0�� ��ư�� ������ ��
        //���콺 ��ư
        //0 : ����
        //1 : ������
        //2 : ��
        if(Input.GetMouseButtonDown(0))
        {
            var thrown = Instantiate(prefab);
            //as GameObject�� Instantiate�� ���� ����ϸ� ���ӿ�����Ʈ�ν� �����϶�� �ǹ��Դϴ�.

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //����(Ray)
            //������ ������ ������, �߻�Ǵ� ���� ������ ������ ������ �ֽ��ϴ�.
            //�Ϲ����� Ray�� Vector3�� ���� ������, Ray2D�� ���� Vector2�� ���� ������ �˴ϴ�.

            //�Ϲ����� ���� ����� ���
            //Vector3 origin = new Vector3(0, 0, 0);
            //Vector3 vect_dir = Vector3.forward;
            //Ray newRay = new Ray(origin, vect_dir);

            //���̴� �����͸� ������ �ִ� ����ü�̹Ƿ�, ��������δ� �Ҽ� �ִ� ���� ������
            //Ray�� �̿��� ���� ����̳� RayCast�� �̿��� ������Ʈ �浹 ������� Ȱ���մϴ�.

            Vector3 direction = ray.direction; //���� ����

            thrown.GetComponent<ObjectShooter>().Shoot(direction.normalized * power);
        }
    }



}
