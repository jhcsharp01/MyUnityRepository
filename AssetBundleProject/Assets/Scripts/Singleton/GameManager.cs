using UnityEngine;

public class GameManager : TSingleton<GameManager>
{
    public int score;

    public void ScorePlus() => score++;
}
