using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player; // oyuncu karakterinin konumu
    public Vector3 offset; // kameranýn oyuncuya olan mesafesi
     
private void LateUpdate()
    {
        transform.position = player.position + offset; // baðlý olduðu nesnenin konumunu, oyuncuya ve mesafeye göre günceller
    }

}
