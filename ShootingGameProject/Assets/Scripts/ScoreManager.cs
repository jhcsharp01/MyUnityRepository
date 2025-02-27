using UnityEngine;
using UnityEngine.UI;

//������ �����ϴ� ������ �Ŵ���
public class ScoreManager : MonoBehaviour
{
    #region Singleton
    public static ScoreManager Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score");
        currentScoreUI.text = $"���� ���� : {currenetScore}";
        bestScoreUI.text = $"�ְ� ���� : {bestScore}";
    }


    //Inspector
    public Text currentScoreUI;
    public Text bestScoreUI;

    //Inner
    private int currenetScore;
    private int bestScore;

    //���� ������ ���� ������Ƽ ����
    //���� ���� ���ٰ� ������ ����ó�� ������ �� �ֽ��ϴ�.
    public int Score
    {
        get
        {
            return currenetScore;
        }

        set
        {
            //1. ���޹��� ���� ������ ������ �����˴ϴ�.
            currenetScore = value;
            //2. UI�� �ش� ���� ����˴ϴ�.
            currentScoreUI.text = $"���� ���� : {currenetScore}";

            //������ ������ �ְ� ������ �Ѿ��ٸ�
            if(currenetScore > bestScore)
            {
                //�� ������ �ְ� ������ �����Ǹ�
                bestScore = currenetScore;
                //UI�� ���ŵ˴ϴ�.
                bestScoreUI.text = $"�ְ� ���� : {bestScore}";
                //���� �����Ϳ��� �� ��ġ�� �����մϴ�.
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }
}
