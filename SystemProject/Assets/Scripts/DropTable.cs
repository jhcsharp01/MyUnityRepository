using System.Collections.Generic;
using UnityEngine;

//CreateAssetMenu의 설정
//()안에 fileName, menuName, order를 설정할 수 있습니다.
//fileName : 생성되는 에셋의 이름
//menuName : Create를 통해 만들어지는 메뉴의 이름을 설정합니다. /를 넣을 경우 경로가 추가됩니다.
//order : 메뉴 중에서 몇번째 위치에 존재할 지 표시할 때 설정하는 값, 값이 클수록 마지막에 표기됩니다.
[CreateAssetMenu(fileName ="DropTable", menuName = "DropTable/drop table", order = 0)]
public class DropTable : ScriptableObject
{
    public List<GameObject> drop_table;
}
