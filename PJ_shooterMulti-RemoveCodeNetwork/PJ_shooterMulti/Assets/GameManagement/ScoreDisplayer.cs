using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ScoreDisplayer : NetworkBehaviour {
    public GameObject blueTeamScoreText;
    public GameObject redTeamScoreText;

    private int redTeamScore;
    private int blueTeamScore;

    private Announcer announcer;


    private void Start() {
        announcer = FindObjectOfType<Announcer>();
    }


    [ClientRpc]
    public void RpcAddKill(Team teamThatKilled) {
        print(teamThatKilled);
        if(Team.BLUE == teamThatKilled) {
            redTeamScore++;
        } else {
            blueTeamScore++;
        }
        UpdateScore();
    }

    private void UpdateScore() {
        blueTeamScoreText.GetComponent<Text>().text = blueTeamScore.ToString();
        redTeamScoreText.GetComponent<Text>().text = redTeamScore.ToString();
    }
}
