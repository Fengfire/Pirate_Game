using UnityEngine;

public class MinimapToggle : MonoBehaviour
{
    public GameObject minimapUI; // Minimap Raw Image objesi burada olacak.

    private void Update()
    {
        // "M" tu�una bas�ld���nda minimap a��l�p kapan�r.
        if (Input.GetKeyDown(KeyCode.M))
        {
            minimapUI.SetActive(!minimapUI.activeSelf);
        }
    }
}
