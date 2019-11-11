using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(AimController))]
public class FollowMouse : MonoBehaviour {
    [SerializeField] GameObject gun;
    [SerializeField] Camera playerCamera;
    [SerializeField] GameObject player;
    private AimController AimController;
    private float angle = 0;
    public float smooth = 2f;
    private const float DEFAULTSPEEDFUDGEFACTOR = 0.3f;
    private float defaultCameraLocationY = 1;

    public const float AIMINGROTATIONSPEED = 25;
    public const float NOTAIMINGROTATIONSPEED = 100;
    // Use this for initialization
    void Start() {
        AimController = GetComponent<AimController>();
    }

    // Update is called once per frame
    void Update() {
      
        if (Input.GetAxis("Mouse X") != 0) {
            if (AimController.IsAiming()) {
                player.transform.Rotate(0, Input.GetAxis("Mouse X") * AIMINGROTATIONSPEED, 0);
            } else {
                player.transform.Rotate(0, Input.GetAxis("Mouse X") * NOTAIMINGROTATIONSPEED, 0);
            }
        }
        if (Input.GetAxis("Mouse Y") != 0) {
            float speed;
            if (AimController.IsAiming()) {
                speed = AIMINGROTATIONSPEED;
            } else {
                speed = NOTAIMINGROTATIONSPEED;
                   
            }
            angle += speed * -Input.GetAxis("Mouse Y") * DEFAULTSPEEDFUDGEFACTOR;
            Vector3 targetEulerAngleRotation = new Vector3(angle, 0, 0);
            playerCamera.transform.localEulerAngles = targetEulerAngleRotation;
            gun.transform.localEulerAngles = targetEulerAngleRotation;
            if (!AimController.IsAiming()) {
                playerCamera.transform.localPosition = new Vector3(playerCamera.transform.localPosition.x, defaultCameraLocationY + angle * 0.01f, playerCamera.transform.localPosition.z);
            }

        }
    }
    
}
