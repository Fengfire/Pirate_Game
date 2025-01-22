using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek obje (geminin Transform'u)
    public Vector3 offset;   // Kameran�n gemiye g�re uzakl���

    void Start()
    {
        // Kamera ba�lang�� pozisyonunu ayarla
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }

    void LateUpdate()
    {
        // Kameran�n pozisyonunu s�rekli g�ncelle
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
