using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playerInputHandler : MonoBehaviour
{
    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset playerControls;

    [Header("Action Map Name References")]
    [SerializeField] private string actionMapName="Player";

    [Header("Action Name References")]
    [SerializeField] private string move="Move";
    [SerializeField] private string look="Look";
    [SerializeField] private string jump="Jump";
    [SerializeField] private string sprint="Sprint";
    // [SerializeField] private string swiming="Swiming";

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction; 
    private InputAction sprintAction;   

    // private InputAction swimingAction;


    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }
    public bool JumpTriggered { get; private set; }
    public float SprintValue { get; private set; }

    // public InputAction SwimingDown { get; private set; }
    // public InputAction SwimingUp { get; private set; }


    public static playerInputHandler Instance { get; private set; }


    private void Awake(){
        /*if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }*/

        moveAction = playerControls.FindActionMap(actionMapName).FindAction(move);
        lookAction = playerControls.FindActionMap(actionMapName).FindAction(look);
        jumpAction = playerControls.FindActionMap(actionMapName).FindAction(jump);
        sprintAction = playerControls.FindActionMap(actionMapName).FindAction(sprint);
        // SwimingDown = playerControls.FindActionMap(actionMapName).FindAction(swiming);
        // SwimingUp = playerControls.FindActionMap(actionMapName).FindAction(swiming);
        RegisterInputActions();
    }

    void RegisterInputActions(){
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;

        lookAction.performed += context => LookInput = context.ReadValue<Vector2>();
        lookAction.canceled += context => LookInput = Vector2.zero;

        jumpAction.performed += context => JumpTriggered = true;
        jumpAction.canceled += context => JumpTriggered = false;

        sprintAction.performed += context => SprintValue = context.ReadValue<float>();
        sprintAction.canceled += context => SprintValue = 0f;
    }

    private void OnEnable(){
        moveAction.Enable();
        lookAction.Enable();
        jumpAction.Enable();
        sprintAction.Enable();
    }

    private void OnDisable(){
        moveAction.Disable();
        lookAction.Disable();
        jumpAction.Disable();
        sprintAction.Disable();
    }
}
