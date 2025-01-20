using UnityEngine;

public class EntryArea : MonoBehaviour
{
    [SerializeField] GameObject parent;
    [SerializeField] GameObject player;
    GameObject island;
    Vector2 closestPoint;
    Vector2 landingPoint;
    [SerializeField] float landingOffset = 0.3f;
    [SerializeField] GameObject landingPointObj;

    void Start()
    {
        
    }

    void Update()
    {
        if (island != null)
        {
            closestPoint = island.GetComponent<Rigidbody2D>().ClosestPoint(transform.position);
            Vector2 landingDir = closestPoint - new Vector2(transform.position.x, transform.position.y);
            landingDir.Normalize();
            landingPoint = closestPoint + landingDir * landingOffset;
            landingPointObj.transform.position = landingPoint;
        }
        else if (island == null)
        {
            closestPoint = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Island"))
        {
            island = collision.gameObject;
            landingPointObj.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Island"))
        {
            island = null;
            landingPointObj.gameObject.SetActive(false);
        }
    }

    public void EnterShip()
    {
        parent.GetComponent<ShipController>().inputMaster.Enable();
        player.gameObject.SetActive(false);
        player.transform.parent = transform;
        player.transform.position = transform.position;
    }
    public void AttemptExitShip()
    {
        if (island != null)
        {
            parent.GetComponent<ShipController>().inputMaster.Disable();
            player.transform.parent = null;
            player.transform.position = landingPoint;
            player.transform.rotation = Quaternion.identity;
            player.gameObject.SetActive(true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(closestPoint.x, closestPoint.y, 0), 0.1f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(new Vector3(landingPoint.x, landingPoint.y, 0), 0.1f);
    }
}
