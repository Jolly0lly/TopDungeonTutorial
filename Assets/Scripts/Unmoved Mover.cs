using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnmovedMover : Attackable
{

    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    [SerializeField] protected float ySpeed = 0.75f;
    [SerializeField] protected float xSpeed = 1f;
    protected Rigidbody2D rb;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    protected virtual void UpdateMotor(Vector3 input)
    {
        //Reset moveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        //Swap sprite direction according to the direction player is heading

        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Apply push force

        rb.AddForce(pushDirection, ForceMode2D.Impulse);
        if (pushDirection != Vector3.zero)
            StartCoroutine(PushForceDiminish(pushRecoveryDelay));

        pushDirection = Vector3.zero;


        // Checking if movement in specified direction is possible by casting a box and checking then number of collisions
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actors", "BlockingObjects"));

        if (hit.collider == null)
        {
            // Player movement
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actors", "BlockingObjects"));

        if (hit.collider == null)
        {
            // Player movement
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }

    public IEnumerator PushForceDiminish(float pushRecoveryDelay)
    {
        yield return new WaitForSeconds(pushRecoveryDelay);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
    }

}
