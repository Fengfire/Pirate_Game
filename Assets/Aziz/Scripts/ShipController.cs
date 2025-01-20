using UnityEngine;

public class ShipController : MonoBehaviour
{
    public InputMaster inputMaster;
    Rigidbody2D rb;
    Vector2 moveDir;
    [SerializeField] int moveSpeed = 4;
    [SerializeField] int turnSpeed = 80;
    bool isTurning;
    bool isMovingVertical;
    [SerializeField] GameObject entryArea; 

    private void OnEnable()
    {

    }

    private void Awake()
    {
        inputMaster = new InputMaster();
        rb = GetComponent<Rigidbody2D>();
        inputMaster.Ship.Movement.performed += context => Move(context.ReadValue<Vector2>());
        inputMaster.Ship.Movement.canceled += context => Move(context.ReadValue<Vector2>());
        inputMaster.Player.Interaction.performed += _ => PressedE();
    }

    private void FixedUpdate()
    {
        if (isMovingVertical)
        {
            rb.MovePosition(rb.position + (Vector2)transform.up * moveDir.y * Time.fixedDeltaTime * moveSpeed);
        }
        if (isTurning)
        {
            rb.MoveRotation(rb.rotation + -moveDir.x * Time.fixedDeltaTime * turnSpeed);
        }
    }

    void Move(Vector2 direction)
    {
        moveDir = direction;
        if (moveDir.y != 0)
        {
            isMovingVertical = true;
        }
        else
        {
            isMovingVertical= false;
        }

        if(moveDir.x != 0)
        {
            isTurning = true;
        }
        else
        {
            isTurning = false;
        }
    }

    void PressedE()
    {
        entryArea.GetComponent<EntryArea>().AttemptExitShip();
    }

    private void OnDisable()
    {
        inputMaster.Disable();
    }
}
