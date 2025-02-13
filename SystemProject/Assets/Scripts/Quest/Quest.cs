using System;
using UnityEngine;

//퀘스트 유형
public enum QuestType
{
    normal,daily,weekly
}
//일반 퀘스트 : 클리어하면 더이상 깰 수 없습니다.
//데일리 퀘스트 : 매일을 기준으로 퀘스트가 갱신됩니다.
//위클리 퀘스트 : 주를 기준으로 퀘스트가 갱신됩니다.

[CreateAssetMenu(fileName = "Quest", menuName = "Quest/Quest")]
public class Quest : ScriptableObject
{
    public QuestType 퀘스트유형;
    public Reward 보상;
    public Requirement 요구조건;

    [Header("퀘스트 정보")]
    public string 제목; //퀘스트의 제목
    public string 목표; //퀘스트의 목표
    [TextArea] public string 설명; //퀘스트에 대한 설명

    public bool 성공; //퀘스트의 성공 여부를 체크합니다.
    public bool 진행상태; //퀘스트가 진행 중인지를 확인하는 용도로 사용합니다.
}

//요구 조건에 대한 스크립터블 오브젝트 생성
[Serializable]
[CreateAssetMenu(fileName = "Requirement", menuName = "Quest/Requirement")]
public class Requirement : ScriptableObject
{
    public int 목표몬스터수;
    public int 현재잡은몬스터수;
}


[Serializable]
[CreateAssetMenu(fileName = "Reward", menuName = "Quest/Reward")]
public class Reward : ScriptableObject
{
    public int 돈;
    public float 경험치;
}