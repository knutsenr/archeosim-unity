using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  // private PlayerControls controls;
  public Rigidbody2D rb;
  private Vector2 moveInput;
  Animator anim;
  private SpriteRenderer rend;
  public GridManager gridScript;

  [Header("Movement Settings")]
  public float moveSpeed = 5f;
  float horizontalMovement;
  float verticalMovement;
  [SerializeField] InputAction interact;
  [SerializeField] public GameObject currentTile;

  [HideInInspector]
  public bool isDigging = false;

  // Start is called once before the first execution of Update after the MonoBehaviour is create

  private void Awake()
  {
    rend = GetComponent<SpriteRenderer>();
    interact = InputSystem.actions.FindAction("Dig");
  }

  private void Start()
  {
    anim = GetComponent<Animator>();
    anim.SetBool("moving", false);
  }

  public void Move(InputAction.CallbackContext context)
  {
    anim.SetBool("moving", true);
    horizontalMovement = context.ReadValue<Vector2>().x;
    verticalMovement = context.ReadValue<Vector2>().y;
  }

  // private void OnTriggerEnter2D(Collider2D other)
  // {
  //   if (other.tag == "Cell")
  //   {
  //     currentTile = other.GameObject();
  //   }
  // }

  // private void OnTriggerExit2D(Collider2D other)
  // {
  //   hilight.SetActive(false);
  // }

  // Update is called once per frame
  void Update()
  {
    rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, verticalMovement * moveSpeed);

    if (rb.linearVelocity.x < 0) { anim.SetTrigger("walkingLeft"); rend.flipX = true; }
    else if (rb.linearVelocity.x > 0) { anim.SetTrigger("walkingLeft"); rend.flipX = false; }
    else if (rb.linearVelocity.y < 0) { anim.SetTrigger("walkingForward"); }
    else if (rb.linearVelocity.y > 0) { anim.SetTrigger("walkingBack"); }
    else { anim.SetBool("moving", false); }

    // currentTile = gridScript.GetTileAtPosition(rb.linearVelocity);

    if (interact.WasPressedThisFrame()) { currentTile.GetComponent<Tile>().Dig(); } else { isDigging = false; }
  }

}
