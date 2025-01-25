using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] int damage;
    GameObject enemyObj;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            enemyObj = collision.gameObject;
            Attack();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            enemyObj = collision.gameObject;
            Attack();
        }
    }

    void Attack()
    {
        enemyObj.GetComponent<Health>().GetHit(damage);
    }
}
