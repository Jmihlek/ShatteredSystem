using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public float cameraSwitchDelay = 1.0f; // Задержка перед сменой камеры
    private float cameraSwitchTimer = 0.0f; // Таймер для отслеживания задержки смены камеры

    public bool canSwitchCamera = true; // Флаг, указывающий, можно ли менять камеры
    void Start()
    {

      animator = GetComponent<Animator>();
      //rigidbody = GetComponent<Rigidbody>();  
      CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    public bool CanSwitchCamera()
    {
        if (canSwitchCamera)
        {
            canSwitchCamera = false;
            cameraSwitchTimer = 0.0f;
            return true;
        }
        else
            return false;
        // Устанавливаем флаг и сбрасываем таймер
    }
    void Update()
    {
        // Проверяем, можно ли менять камеры
        if (!canSwitchCamera)
        {
            cameraSwitchTimer += Time.deltaTime;

            // Если прошло достаточно времени, сбрасываем флаг и таймер
            if (cameraSwitchTimer >= cameraSwitchDelay)
            {
                canSwitchCamera = true;
                cameraSwitchTimer = 0.0f;
            }
        }

        var isRun = Input.GetKey(KeyCode.LeftShift);
        // Получаем активную камеру
        Camera activeCamera = FindObjectOfType<Camera>();
        if (activeCamera == null)
        {
            Debug.LogError("Нет активной камеры!");
            return;
        }

        // Получаем ввод от игрока
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Преобразуем ввод относительно направления камеры
        Vector3 cameraForward = activeCamera.transform.forward;
        Vector3 cameraRight = activeCamera.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Вычисляем направление движения персонажа относительно камеры
        Vector3 movementDirection = (cameraForward * verticalInput) + (cameraRight * horizontalInput);
        movementDirection.Normalize();

        // Применяем движение персонажа
        Vector3 movement = movementDirection * (isRun ? boostSpeed : speed) * Time.deltaTime;
        animator.SetFloat("MovmentSpeed", Vector3.ClampMagnitude(movementDirection, 1).magnitude);
        //transform.position = Vector3.ClampMagnitude(directionVector,1) * speed;
        groundedPlayer = CharacterController.isGrounded;
        if (groundedPlayer && movement.y < 0)
        {
            movement.y = 0f;
        }
        if (movement != Vector3.zero)
        {
            gameObject.transform.forward = movement;
        }
        CharacterController.Move(movement);

        // Поворачиваем персонажа в сторону ходьбы
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = toRotation;
        }


    //    float h = Input.GetAxis("Horizontal");
    //    float v = Input.GetAxis("Vertical");
    //    Vector3 directionVector = new Vector3(-v, 0, h);
    //    if (directionVector.magnitude > Mathf.Abs(0.05f))
    //    transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(directionVector),Time.deltaTime * 10);

    //    // Changes the height position of the player..
    //    if (Input.GetButtonDown("Jump") && groundedPlayer)
    //    {
    //        directionVector.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    //    }
    //    directionVector.y += gravityValue * Time.deltaTime;
    //    CharacterController.Move(directionVector * (isRun ? boostSpeed : speed) * Time.deltaTime);
     }
}
