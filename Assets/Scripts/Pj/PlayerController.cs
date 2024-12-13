using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private Vector2 movVector = Vector2.zero;
    public float movementVelocity;
    private Rigidbody2D rb;
    //Timer
    [SerializeField] float stunTime;
    float stunTimer;
    public bool stunned;
    private void Start()
    {
        movementVelocity = 7.5f;
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        OnMove();
    }
    private void Update()
    {
        stunCooldown();
    }
    private void OnMove()
    {
        if (stunned) return;
        movVector = InputManager.instance.GetMovementPj();
        if (movVector == null) return;
        movVector.Normalize();
        rb?.MovePosition(rb.position + movVector * Time.fixedDeltaTime * movementVelocity);
    }
    public void TakeKnockback(Vector2 kb)
    {
        if (stunned) return;
        stunned = true;
        rb.AddForce(kb, ForceMode2D.Impulse);
    }
    #region Cooldown
    void stunCooldown()
    {
        if(!stunned) return;
        stunTimer += Time.deltaTime;
        if (stunTimer >= stunTime)
        {
            stunned = false;
            stunTimer = 0;
        }
    }
    #endregion
}
