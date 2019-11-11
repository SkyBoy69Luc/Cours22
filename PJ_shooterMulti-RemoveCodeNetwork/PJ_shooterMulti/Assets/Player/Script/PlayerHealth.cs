using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour, Damagable {
    private PlayerController playerController;
    private ScoreDisplayer scoreDisplayer;
    private TeamManager teamManager;
    void Start() {
        playerController = GetComponent<PlayerController>();
        teamManager = GetComponent<TeamManager>();
    }

    public override void OnStartServer()
    {
        scoreDisplayer = FindObjectOfType<ScoreDisplayer>();
    }
  
    
    public void DealDamage(GameObject from, int damage) {
        CmdDealDamage(from, damage);
    }

    [Command]
    public void CmdDealDamage(GameObject from, int damage)
    {
        if (from != null)
        {
            TeamManager fromTeamManager = from.GetComponent<TeamManager>();
            if(fromTeamManager !=null)
            {
                if (scoreDisplayer !=null)
                {
                    if (fromTeamManager.GetTeam() != teamManager.GetTeam())
                    {
                        scoreDisplayer.RpcAddKill(fromTeamManager.GetTeam());
                    }
                }

            }
        }
        playerController.RpcDie();
    }
}
