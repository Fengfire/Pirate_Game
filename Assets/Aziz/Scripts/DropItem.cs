using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] int itemCount;
    [SerializeField] float dropRadius = 0.5f;

    public void Drop()
    {
        for (int i = 0; i < itemCount; i++)
        {
            Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle * dropRadius;
            Instantiate(item, randomPosition, Quaternion.identity);
        }
    }
}
