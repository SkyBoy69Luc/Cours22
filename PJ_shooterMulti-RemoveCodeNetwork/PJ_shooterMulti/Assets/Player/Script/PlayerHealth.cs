using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerHealth : MonoBehaviour, Damagable {
    private PlayerController playerController;
    private ScoreDisplayer scoreDisplayer;
    private TeamManager teamManager;
    void Start() {
        playerController = GetComponent<PlayerController>();
        teamManager = GetComponent<TeamManager>();
    }
  
    
    public void DealDamage(GameObject from, int damage) {
     
    }
}
