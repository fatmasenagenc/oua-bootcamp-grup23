using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class charController : MonoBehaviour
{
    [Header("Movement Speeds")]
    [SerializeField] private float walkSpeed = 6.0f;
    [SerializeField] private float sprintMultiplier = 10.0f;

    [Header("Jump Parameters")]
    [SerializeField] private float jumpForce = 2.0f;
    [SerializeField] private float gravity = 9.18f;

    [Header("Look Sensitivity")]
     [SerializeField] private float mouseSensitivity = 2.0f;
     [SerializeField] private float upDownRange = 85.0f;

    private CharacterController charCont;
    private Camera mainCamera;
    private playerInputHandler inputHandler;
    private Vector3 currentMovement;
    private float verticalLookRotation;

    private void Awake(){
        charCont = GetComponent<CharacterController>();
        mainCamera = GetComponentInChildren<Camera>();
        inputHandler = GetComponent<playerInputHandler>();
    }
    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement(){
        float speed = walkSpeed * (inputHandler.SprintValue > 0 ? sprintMultiplier : 1.0f);
        Vector3 inputDirection = new Vector3(inputHandler.MoveInput.x, 0f, inputHandler.MoveInput.y);
        Vector3 worldDirection = transform.TransformDirection(inputDirection);
        worldDirection.Normalize();

        currentMovement.x = worldDirection.x * speed;
        currentMovement.y = worldDirection.y * speed;
        currentMovement.z = worldDirection.z * speed;

        charCont.Move(currentMovement * Time.deltaTime);
        // HandleJumping();
        // HandleSwimming();

    }

    // void HandleSwimming(){
    //     if(charCont.isGrounded){
    //         currentMovement.y = -0.5f;
    //     }
    //     else{
    //         currentMovement.y -= 0.5f * Time.deltaTime;
    //     }
    // }
    // void HandleJumping(){
    //     if(charCont.isGrounded){
    //         currentMovement.y = -0.5f;
    //      if(inputHandler.JumpTriggered){
    //          currentMovement.y = jumpForce;
    //      }
    //     }
    //     else{
    //         currentMovement.y -= gravity * Time.deltaTime;
    //     }
    // }

    void HandleRotation()
    {
    float mouseXRotaion = inputHandler.LookInput.x * mouseSensitivity;
    transform.Rotate(0, mouseXRotaion, 0);
    float mouseYRotation = inputHandler.LookInput.y * mouseSensitivity;
    transform.Rotate(-mouseYRotation, 0, 0);

    verticalLookRotation += inputHandler.LookInput.y * mouseSensitivity;
    verticalLookRotation = Mathf.Clamp(verticalLookRotation, -upDownRange, upDownRange);
    mainCamera.transform.localRotation = Quaternion.Euler(verticalLookRotation, 0, 0);
   }

}
