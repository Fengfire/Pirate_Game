using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] TextMeshProUGUI[] txts;
    [SerializeField] string[] prefKeys;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateUIs();
    }

    public void UpdateUIs()
    {
        for (int i = 0; i < txts.Length; i++)
        {
            txts[i].text = PlayerPrefs.GetInt(prefKeys[i], 0).ToString();
        }
    }
}
