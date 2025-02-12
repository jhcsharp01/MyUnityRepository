using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public enum ENEMYTYPE
    {
        Goblin,Slime,Wolf
    }
    /// <summary>
    /// Factory에서 다루는 데이터 형태를 return하는 코드
    /// </summary>
    /// <param name="type">생성할 객체의 형태 표현</param>
    /// <returns></returns>
    public Enemy Create(ENEMYTYPE type)
    {
        switch(type)
        {
            case ENEMYTYPE.Goblin:
                return new Goblin();
            case ENEMYTYPE.Slime:
                return new Slime();
            case ENEMYTYPE.Wolf:
                return new Wolf();
            default:
                //예외 상황 발생(생성이 제대로 안된 경우)
                throw new System.Exception("생성 실패");
        }
    }
}
