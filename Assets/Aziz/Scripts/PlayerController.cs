using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    enum FaceDirection { left, right }
    FaceDirection faceDir;
    FaceDirection pastFaceDir;

    InputMaster inputMaster;
    Rigidbody2D rb;
    Vector2 moveDir;
    [SerializeField] float moveSpeed = 4;
    bool isMoving;
    [SerializeField] GameObject body;
    bool enteredArea;
    GameObject enteredObject;

    [SerializeField] UnityEvent Turn;
    Interactable interactable;

    private Vector2 MoveDir 
    { 
        get { return moveDir; } 
        set 
        { 
            moveDir = value;
            if (moveDir != Vector2.zero)
            {
                isMoving = true;
                if (moveDir.x > 0)
                {
                    faceDir = FaceDirection.right;
                }
                else if (moveDir.x < 0)
                {
                    faceDir = FaceDirection.left;
                }
                body.GetComponent<SpriteRenderer>().flipX = (faceDir == FaceDirection.right);
                body.GetComponent<Animator>().SetBool("Walk", true);
                if (pastFaceDir != faceDir)
                {
                    pastFaceDir = faceDir;
                    Turn.Invoke();
                }
            }
            else
            {
                isMoving = false;
                body.GetComponent<Animator>().SetBool("Walk", false);
            }
        }
    }

    private void OnEnable()
    {
        inputMaster.Enable();
    }

    private void Awake()
    {
        inputMaster = new InputMaster();
        rb = GetComponent<Rigidbody2D>();
        inputMaster.Player.Movement.performed += context => SetDirection(context.ReadValue<Vector2>());
        inputMaster.Player.Movement.canceled += context => SetDirection(context.ReadValue<Vector2>());
        inputMaster.Player.Interaction.performed += _ => PressedE();
        inputMaster.Player.Attack.performed += _ => PressedLeftClick();
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            rb.MovePosition(rb.position + moveDir * Time.fixedDeltaTime * moveSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EntryArea"))
        {
            enteredArea = true;
            enteredObject = collision.gameObject;
        }
        if (collision.GetComponent<Interactable>() != null)
        {
            interactable = collision.GetComponent<Interactable>();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EntryArea"))
        {
            enteredArea = false;
            enteredObject = null;
        }
        if (collision.GetComponent<Interactable>() != null)
        {
            interactable = null;
        }
    }

    void SetDirection(Vector2 direction)
    {
        MoveDir = direction;
    }

    void PressedE()
    {
        if (enteredArea)
        {
            enteredObject.GetComponent<EntryArea>().EnterShip();
        }
        if (interactable != null)
        {
            interactable.Interact();
        }
    }

    void PressedLeftClick()
    {
        body.GetComponent<Animator>().SetTrigger("Attack");
    }

    private void OnDisable()
    {
        inputMaster.Disable();
    }
}
