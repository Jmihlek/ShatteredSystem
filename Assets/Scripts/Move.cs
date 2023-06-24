using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Animator animator;
   // private Rigidbody rigidbody;
    public float rotationSpeed = 10;
    public float speed = 2f;
    public Transform FirstCam;
    public CharacterController CharacterController;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public float boostSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {

      animator = GetComponent<Animator>();
      //rigidbody = GetComponent<Rigidbody>();  
      CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var isRun = Input.GetKey(KeyCode.LeftShift);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 directionVector = new Vector3(-v, 0, h);
        if (directionVector.magnitude > Mathf.Abs(0.05f))
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(directionVector),Time.deltaTime * 10);
        animator.SetFloat("MovmentSpeed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
        //transform.position = Vector3.ClampMagnitude(directionVector,1) * speed;
        groundedPlayer = CharacterController.isGrounded;
        if (groundedPlayer && directionVector.y < 0)
        {
            directionVector.y = 0f;
        }
        if (directionVector != Vector3.zero)
        {
            gameObject.transform.forward = directionVector;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            directionVector.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        directionVector.y += gravityValue * Time.deltaTime;
        CharacterController.Move(directionVector * (isRun ? boostSpeed : speed) * Time.deltaTime);
    }
}
