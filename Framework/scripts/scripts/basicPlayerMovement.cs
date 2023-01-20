
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMovement : MonoBehaviour
{
	[SerializeField] private Rigidbody rb;
	[SerializeField] private float speed;
	[SerializeField] private float rayDistance;
	[SerializeField] private float jumpForce;
	[SerializeField] private float sensitivity;
	[SerializeField] private bool flyMode;
	[SerializeField] private bool isGrounded;
	[SerializeField] private GameObject Feet;
    private Vector3 prevVelocity;
    public bool hideMouse;
	public bool paused;
	public float flySpeed;
	public float distance;

	private void Start()
	{
    	rb = gameObject.AddComponent<Rigidbody>();
    	rb.constraints = RigidbodyConstraints.FreezeRotation;
	}


	private void Update()
	{
		if (!paused)
		{
			HandleMovement();
			HandleRotation();
			HandleJumping();
			Mouse();
            button();
		}
	}

    private void button()
    {
        Ray ray = new Ray(Camera.main.gameObject.transform.position, Camera.main.gameObject.transform.forward);
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("e");
            if (Physics.Raycast(ray, out hit, distance))
            {
                print(hit.collider.name);
                if (hit.collider.gameObject.CompareTag("button"))
                {
                    hit.collider.gameObject.GetComponent<buttonHandler>().Press(hit.collider.name);
                }
            }
        }
    }

    private void HandleMovement()
    {
        // Getting the horizontal and vertical input axis
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        prevVelocity = rb.velocity;

        // Setting the velocity of the rigidbody based on the input axis and the speed variable
        Vector3 velocity = (transform.forward * vertical + transform.right * horizontal) * speed;
        if (!(horizontal != 0 || vertical != 0)) velocity = Vector3.zero;
        velocity.y = prevVelocity.y;
        rb.velocity = velocity;

        // If fly mode is enabled, disable gravity and adjust y-velocity based on input
        if (flyMode)
        {
            rb.useGravity = false;
            rb.velocity = new Vector3(rb.velocity.x, Input.GetKey(KeyCode.Space) ? flySpeed : Input.GetKey(KeyCode.LeftShift) ? -flySpeed : 0, rb.velocity.z);
        }
        // If fly mode is not enabled, enable gravity
        else
        {
            rb.useGravity = true;
        }
    }



    private void HandleRotation()
    {
        // Getting the horizontal and vertical mouse axis
        Vector2 mousePos = new Vector2(Input.GetAxis("Mouse X") * sensitivity, -Input.GetAxis("Mouse Y") * sensitivity);
        // Rotating the player horizontally based on the horizontal mouse axis
        transform.Rotate(new Vector3(0, mousePos.x, 0));
        // Rotating the main camera vertically based on the vertical mouse axis
        Camera.main.transform.Rotate(mousePos.y, 0, 0);
    }

    #region Jump
    private void HandleJumping()
    {
        // Creating a ray going downwards from the player's position
        Ray ray = new Ray(Feet.gameObject.transform.position, Vector3.down);
        RaycastHit groundRay;

        // Raycasting downwards to detect if the player is on the ground and setting isGrounded accordingly
        isGrounded = Physics.Raycast(ray, out groundRay, rayDistance) && groundRay.collider.gameObject.CompareTag("ground") ? true : false;

        // Checking if the jump button is pressed and the player is on the ground
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Adding an upward velocity to the player's rigidbody
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            // Setting isGrounded to false when the player jumps
            isGrounded = false;
        }
    }


    #endregion

    public void MouseHide(bool value)
    {
        // Locking the cursor if the value passed as a parameter is true, unlocking otherwise
        Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
        // Hiding the cursor if the value passed as a parameter is true, showing otherwise
        Cursor.visible = !value;
        // Updating the hideMouse variable with the value passed as a parameter
        hideMouse = value;
    }

    // This method controls the visibility and lock state of the cursor. 
    public void Mouse()
    {
        // If hideMouse is true, lock cursor and hide it, if it is not, unlock the cursor and show it.
        Cursor.lockState = hideMouse ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !hideMouse;
    }

    public void MouseHide()
	{
		hideMouse = !hideMouse;
	}
}
