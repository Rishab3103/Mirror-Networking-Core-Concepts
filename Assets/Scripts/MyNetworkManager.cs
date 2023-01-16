using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkBehaviour
{
    public override void OnStartServer()
    {
        Debug.Log("Server Started");
    }

    public override void OnStopServer()
    {
        Debug.Log("Server Stopped");

    }
    public override void OnStartClient()
    {
        Debug.Log("Connected to Server");
    }

    public override void OnStopClient()
    {
        Debug.Log("Disconnected from server");
    }
    
}
