using UnityEngine;

public enum ExitDirection
{
    right,left,down,up
}

public class Exit : MonoBehaviour
{
    public string sceneName = "";
    public int doorNumber = 0;
    public ExitDirection direction = ExitDirection.down;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            RoomManager.ChangeScene(sceneName, doorNumber);
        }
    }

}
