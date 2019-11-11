using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AimController : MonoBehaviour {
    [SerializeField] GameObject aimedTargetLocation;
    [SerializeField] GameObject unaimedTargetLocation;
    [SerializeField] float timeToAim=1f;
    [SerializeField] float aimedFieldOfView = 30;
    [SerializeField] float unaimedFiledOfView = 60;
    [SerializeField] Camera playerCamera;

    private float progression = 0;
    private float calculatedTime = 0;
    private bool isAiming = false;
    private GameObject currentTargetLocation;

    private void Start() {
        currentTargetLocation = unaimedTargetLocation;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update () {
        if (Input.GetAxis("Fire2") > 0) {
            isAiming = true;
            AjustProgression();
        } else {
            isAiming = false;
            AjustProgression();
        }
	}

    public bool IsAiming() {
        return isAiming;
    }

    private void AjustProgression() {
        if (isAiming) {
            calculatedTime += Time.deltaTime;
            calculatedTime = Mathf.Min(calculatedTime, timeToAim);
            progression = calculatedTime / timeToAim;
            currentTargetLocation = aimedTargetLocation;
        } else {
            calculatedTime -= Time.deltaTime;
            calculatedTime = Mathf.Max(calculatedTime, 0);
            progression = calculatedTime / timeToAim;
            currentTargetLocation = unaimedTargetLocation;
        }
        AjustCameraPosition();
        AjustCameraFieldOfView();
    }

    private void AjustCameraPosition () {
        playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, currentTargetLocation.transform.position, progression);
        playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.transform.rotation, currentTargetLocation.transform.rotation, progression);
    }

    private void AjustCameraFieldOfView() {
        playerCamera.fieldOfView = unaimedFiledOfView - (progression * (unaimedFiledOfView-aimedFieldOfView));
    }
}
