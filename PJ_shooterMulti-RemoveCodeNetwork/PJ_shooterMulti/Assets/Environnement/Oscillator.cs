using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Oscillator : NetworkBehaviour {
    public Vector3 movementVector = new Vector3(10f, 10f, 10f);
    public float period = 2f;


    public float time;
    private Vector3 startingPos;
    [SyncVar]
    private Vector3 velocity;
	// Use this for initialization
	void Start () {
        startingPos = transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        CmdUpdateTime();
        UpdatePosition();


    }

    private void UpdatePosition() {
        transform.position += velocity;
    }

    [Command]
    private void CmdUpdateTime() {
        time += Time.deltaTime;
        CmdUpdatePosition();
    }

   [Command]
   private void CmdUpdatePosition() {
        if (period <= Mathf.Epsilon) {
            return;
        }
     
        float cycles = time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);
        Vector3 offset = movementVector * rawSinWave;
        velocity = (startingPos + offset) - transform.position ;

    }

   public Vector3 GetVelocity() {
        return velocity;
    }
    
}
