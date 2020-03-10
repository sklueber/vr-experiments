using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SphereController : MonoBehaviour
{
    public GameObject character;
    
    
    public SteamVR_Action_Boolean teleportAction;
    public SteamVR_Action_Vector2 joystickAction;
    public SteamVR_Action_Single squeezeAction;

    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public LayerMask Ground;


    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    private bool _isGrounded = true;
    private Transform _groundChecker;

    private void Awake()
    {
        teleportAction = SteamVR_Actions._default.Teleport;
        joystickAction = SteamVR_Actions._default.Move;
        squeezeAction = SteamVR_Actions._default.Squeeze;

        teleportAction[SteamVR_Input_Sources.Any].onStateDown += TeleportMethod;
        joystickAction[SteamVR_Input_Sources.Any].onUpdate += MoveMethod;
        squeezeAction[SteamVR_Input_Sources.Any].onAxis += SqueezeMethode;
    }


    private void Start()
    {
        _body = character.GetComponent<Rigidbody>();
        _groundChecker = character.transform.GetChild(0);
    }

    void Update()
    {
        #region oldCode
        //if(teleportAction[SteamVR_Input_Sources.Any].stateDown) //replace Any to only get e.g. left hand
        //{
        //    print("Teleport down");
        //}

        //if (SteamVR_Actions.default_GrabGrip.GetStateUp(SteamVR_Input_Sources.Any))
        //{
        //    print("Grab pinch up");
        //}

        //float triggerValue = squeezeAction.GetAxis(SteamVR_Input_Sources.Any);
        //if(triggerValue > 0.0f)
        //{
        //    print(triggerValue);
        //}

        //Vector2 joystickValue = joystickAction.GetAxis(SteamVR_Input_Sources.Any);

        //if(joystickValue != Vector2.zero)
        //{
        //    print(joystickValue);
        //}
        #endregion

        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
    }

    private void FixedUpdate()
    {
        _body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);
    }

    private void TeleportMethod(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (_isGrounded)
        {
            _body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
        print("jhgf");
    }

    private void MoveMethod(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta)
    {

        _inputs = new Vector3(axis.x, 0, axis.y);
    }
    private void SqueezeMethode(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta)
    {
        
    }
}
