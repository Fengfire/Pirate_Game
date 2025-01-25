using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] int health;
    int minHealth = 0;
    bool isDead = false;

    [SerializeField] UnityEvent OnDeath;

    public void GetHit(int damage)
    {
        if (health > minHealth && !isDead)
        {
            health -= damage;
        }
        else if (health <= minHealth && !isDead)
        {
            health = 0;
            isDead = true;
            OnDeath.Invoke();
            Destroy(gameObject);
        }
    }
}
