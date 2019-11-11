using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamDispatcher  {
    private float numberOfRedPlayer = 0;
    private float numberOfBluePlayer = 0;
    // Use this for initialization

    public Team GetNextPlayerColor() {
        Team nextPlayerTeam;
        if(numberOfRedPlayer <= numberOfBluePlayer) {
            nextPlayerTeam = Team.RED;
            numberOfRedPlayer++;
        } else {
            nextPlayerTeam = Team.BLUE;
            numberOfBluePlayer++;
        }
        return nextPlayerTeam;

    }
    
}
