using UnityEngine;

public class MinimapToggle : MonoBehaviour
{
    public GameObject minimapUI; // Minimap Raw Image objesi burada olacak.

    private void Update()
    {
        // "M" tuþuna basýldýðýnda minimap açýlýp kapanýr.
        if (Input.GetKeyDown(KeyCode.M))
        {
            minimapUI.SetActive(!minimapUI.activeSelf);
        }
    }
}
