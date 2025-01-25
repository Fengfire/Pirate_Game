using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class EquippableItem : MonoBehaviour
{
    GameObject playerObj;
    bool isNear;
    [SerializeField] float equipSpeed = 1.5f;
    [SerializeField] GameObject parent;
    [SerializeField] string itemName;
    public UnityEvent OnEquip;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isNear = true;
            playerObj = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isNear = false;
            playerObj = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Equip();
            OnEquip.Invoke();
            Destroy(parent);
        }
    }

    private void Update()
    {
        if (isNear)
        {
            Vector3 dir = playerObj.transform.position - transform.position;
            transform.Translate(dir * Time.deltaTime * equipSpeed);
        }
    }

    void Equip()
    {
        PlayerPrefs.SetInt(itemName, PlayerPrefs.GetInt(itemName, 0) + 1);

        UIController.instance.UpdateUIs();
    }
}
