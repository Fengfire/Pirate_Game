using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek obje (geminin Transform'u)
    public Vector3 offset;   // Kameranýn gemiye göre uzaklýðý

    void Start()
    {
        // Kamera baþlangýç pozisyonunu ayarla
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }

    void LateUpdate()
    {
        // Kameranýn pozisyonunu sürekli güncelle
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
