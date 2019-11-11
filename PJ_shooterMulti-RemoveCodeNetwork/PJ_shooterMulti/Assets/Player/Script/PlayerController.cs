using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
    CharacterController characterController;
    //Rigidbody rigidBody;
    //[SyncVar]
    Vector3 Velocity = Vector3.zero;
    public const float INITIALJUMPVELOCITY=10;
    public const float GRAVITYSTRENGHT = -15f;
    public const float MOVESPEED = 5;

    private bool hasControl = true;
    private bool isAlive = true;
    public GameObject deathParticleSystemObject;
    public GameObject mesh;

    private Camera mycam;
    private AudioListener audioListener;
    private PlayerRespawner playerRespawner;

    private Oscillator registeredContactOscillator;


    void Start() {
        characterController = GetComponent<CharacterController>();
    }
    
    void Update() {
        if ( hasControl) {
            ProcessGravity();
            ProcessMovementInput();
       }
        Move();
    }

    private void ProcessGravity() {
        if (!characterController.isGrounded) {
            Velocity.y += GRAVITYSTRENGHT * Time.deltaTime;
        } else {
            if(Velocity.y < 0) {
                Velocity.y = 0;
            }
        }
    }

    private Vector3 CalculatedMovementVector() {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        Vector3 mouvement = new Vector3(horizontal, 0, vertical);
        Vector3 ajustedMovement = transform.TransformDirection(mouvement);
        ajustedMovement = ajustedMovement.normalized * MOVESPEED;
        if (registeredContactOscillator != null) {
            ajustedMovement+=registeredContactOscillator.GetVelocity();
        }
        return ajustedMovement;
    }

    private void ProcessMovementInput() {
        Vector3 velocityMovementVector = CalculatedMovementVector();
        Velocity.x = velocityMovementVector.x;
        Velocity.z = velocityMovementVector.z;
        if (Input.GetAxis("Jump") > 0) {
            if (characterController.isGrounded) {
                Velocity.y = INITIALJUMPVELOCITY;
            }
        }
    }

    private void Move() {
        //  rigidbody.
        if (hasControl) {
            characterController.Move(Velocity * Time.deltaTime);
        }
       
    }


    
    public bool IsAlive() {
        return isAlive;
    }

    
}
