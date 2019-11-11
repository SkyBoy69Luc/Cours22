using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class SpawnManager : NetworkBehaviour {

    public GameObject scoreDisplayerPrefab;
    public GameObject playerRespawnManagerPrefab;
    public GameObject middleOscillatorPrefab;
    public GameObject RedSide;
    public GameObject BlueSide;


    // Use this for initialization
    void Start () {
        CmdSpawnManager();
    }


    [Command]

    private void CmdSpawnManager()
    {
        GameObject scoreDisplayer = (GameObject)Instantiate(scoreDisplayerPrefab);
        NetworkServer.Spawn(scoreDisplayer);

        GameObject playerRespawnManager = (GameObject)Instantiate(playerRespawnManagerPrefab);
        NetworkServer.Spawn(playerRespawnManager);

    }

    [Command]
    private void CmdSpawnOscillartor()
    {
        GameObject middleOscillator = (GameObject)Instantiate(middleOscillatorPrefab, RedSide.transform);
        middleOscillator.transform.localPosition = new Vector3(12.5f, 0, 23);
        NetworkServer.Spawn(middleOscillator);

        middleOscillator = (GameObject)Instantiate(middleOscillatorPrefab, BlueSide.transform);
        middleOscillator.transform.localPosition = new Vector3(12.5f, 0, 23);
        NetworkServer.Spawn(middleOscillator);
    }
	
    
    
}
