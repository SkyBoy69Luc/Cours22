using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TeamManager : MonoBehaviour {
  
    private Team team;
    public GameObject playerBody;
  
    private Color color;

    private void Start() {
        ChangeColor();
    }

    public void AssignTeam(Team newTeam) {
        team = newTeam;
        ChangeColor();
    } 

    public Team GetTeam() {
        return team;
    }

    private void ChangeColor() {
        if(team == Team.BLUE) {
            playerBody.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        } else {
            playerBody.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
    }
   
}
