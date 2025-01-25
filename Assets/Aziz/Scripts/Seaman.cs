using UnityEngine;

public class Seaman : MonoBehaviour, Interactable
{
    public void Interact()
    {
        if (PlayerPrefs.GetInt("Berry") >= 10 && PlayerPrefs.GetInt("Seaman", 0) < 4)
        {
            PlayerPrefs.SetInt("Berry", PlayerPrefs.GetInt("Berry", 0) - 10);
            PlayerPrefs.SetInt("Seaman", PlayerPrefs.GetInt("Seaman", 0) + 1);
            UIController.instance.UpdateUIs();
            Destroy(gameObject);
        }
    }
}
