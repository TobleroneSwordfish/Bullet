using UnityEngine;

[RequireComponent(typeof(Camera)), RequireComponent(typeof(Rigidbody))]
public class GhostFreeRoamCamera : MonoBehaviour
{
    public float initialSpeed = 10f;
    public float increaseSpeed = 1.25f;

    public bool allowMovement = true;
    public bool allowRotation = true;

    public KeyCode forwardButton = KeyCode.W;
    public KeyCode backwardButton = KeyCode.S;
    public KeyCode rightButton = KeyCode.D;
    public KeyCode leftButton = KeyCode.A;

    public float cursorSensitivity = 0.025f;
    public bool cursorToggleAllowed = true;
    public KeyCode cursorToggleButton = KeyCode.Escape;

    private float currentSpeed = 0f;
    private bool moving = false;
    private bool togglePressed = false;
    private Rigidbody rb;

    private void OnEnable()
    {
        if (cursorToggleAllowed)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    private void Update()
    {
        if (allowMovement)
        {
            bool lastMoving = moving;
            Vector3 deltaPosition = Vector3.zero;

            if (moving)
            {
                currentSpeed += increaseSpeed * Time.deltaTime;
            }
                
            moving = false;

            CheckMove(forwardButton, ref deltaPosition, transform.forward);
            CheckMove(backwardButton, ref deltaPosition, -transform.forward);
            CheckMove(rightButton, ref deltaPosition, transform.right);
            CheckMove(leftButton, ref deltaPosition, -transform.right);

            if (moving)
            {
                if (moving != lastMoving)
                {
                    currentSpeed = initialSpeed;
                }

                rb.MovePosition(rb.position + deltaPosition * currentSpeed * Time.deltaTime);
                //transform.position += deltaPosition * currentSpeed * Time.deltaTime;
            }
            else
            {
                currentSpeed = 0f;
                rb.velocity = Vector3.zero;
            }
        }

        if (allowRotation && Cursor.lockState == CursorLockMode.Locked)
        {
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.x += -Input.GetAxis("Mouse Y") * 359f * cursorSensitivity;
            eulerAngles.y += Input.GetAxis("Mouse X") * 359f * cursorSensitivity;
            //Debug.Log("euler x: " + eulerAngles.x);
            float origX = transform.eulerAngles.x;
            if (origX > 271 && origX < 360 && eulerAngles.x > 89 && eulerAngles.x < 271)
            {
                eulerAngles.x = origX;
            }
            else if (origX > 0 && origX < 89 && eulerAngles.x < 271 && eulerAngles.x > 89)
            {
                eulerAngles.x = origX;
            }
            
            transform.eulerAngles = eulerAngles;
        }

        if (cursorToggleAllowed)
        {
            if (Input.GetKey(cursorToggleButton))
            {
                if (!togglePressed)
                {
                    togglePressed = true;
                    if (Cursor.lockState == CursorLockMode.Locked)
                    {
                        Cursor.lockState = CursorLockMode.None;
                    }
                    else
                    {
                        Cursor.lockState = CursorLockMode.Locked;
                    }
                    Cursor.visible = !Cursor.visible;
                }
            }
            else togglePressed = false;
        }
        else
        {
            togglePressed = false;
            Cursor.visible = false;
        }
    }

    private bool Between(float x, float min, float max)
    {
        return x > min && x < max;
    }

    private void CheckMove(KeyCode keyCode, ref Vector3 deltaPosition, Vector3 directionVector)
    {
        if (Input.GetKey(keyCode))
        {
            moving = true;
            deltaPosition += directionVector;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        moving = false;
        //rb.velocity -= collision.relativeVelocity;
        rb.velocity = Vector3.zero;
    }
}
