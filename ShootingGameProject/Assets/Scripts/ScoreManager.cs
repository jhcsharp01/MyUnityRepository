using UnityEngine;
using UnityEngine.UI;

//점수를 관리하는 유일한 매니저
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
        currentScoreUI.text = $"현재 점수 : {currenetScore}";
        bestScoreUI.text = $"최고 점수 : {bestScore}";
    }


    //Inspector
    public Text currentScoreUI;
    public Text bestScoreUI;

    //Inner
    private int currenetScore;
    private int bestScore;

    //현재 점수에 대한 프로퍼티 설계
    //값에 대한 접근과 설정을 변수처럼 진행할 수 있습니다.
    public int Score
    {
        get
        {
            return currenetScore;
        }

        set
        {
            //1. 전달받은 값이 현재의 점수로 설정됩니다.
            currenetScore = value;
            //2. UI에 해당 값이 적용됩니다.
            currentScoreUI.text = $"현재 점수 : {currenetScore}";

            //현재의 점수가 최고 점수를 넘었다면
            if(currenetScore > bestScore)
            {
                //그 점수가 최고 점수로 설정되며
                bestScore = currenetScore;
                //UI에 갱신됩니다.
                bestScoreUI.text = $"최고 점수 : {bestScore}";
                //내부 데이터에도 그 수치를 적용합니다.
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }
}
