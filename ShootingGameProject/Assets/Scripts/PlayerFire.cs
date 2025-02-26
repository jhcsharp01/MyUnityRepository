using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;//ÃÑ¾Ë ÇÁ¸®ÆÕ
    public GameObject firePosition; //ÃÑ ¹ß»ç À§Ä¡

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //Left Ctrl
        {
            //ÃÑ¾Ë »ý¼º
            GameObject bullet = Instantiate(bulletFactory);
            //ÃÑ¾Ë À§Ä¡ º¯°æ
            bullet.transform.position = firePosition.transform.position;
        }
    }
}
