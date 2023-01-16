using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TransformCube : NetworkBehaviour
{
    

    NetworkIdentity id;
    
    // Start is called before the first frame update
    public void Start()
    {
        
        GameObject go = Instantiate(this.gameObject);
        NetworkServer.Spawn(go, connectionToClient);
        id = go.GetComponent<NetworkIdentity>();
    }
    [Client]
    public void OwnershipTransferServer()
    {
        CmdRemoveAuthorityObject(id);
    }

    [Client]
    public void OwnershipTransferClient()
    {
        CmdAssignAuthorityObject(id);
    }

    [Command]
    public void CmdAssignAuthorityObject(NetworkIdentity objNetworkID)
    {
        objNetworkID.AssignClientAuthority(connectionToClient);
        objNetworkID.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    [Command]
    public void CmdRemoveAuthorityObject(NetworkIdentity objNetworkID)
    {
        objNetworkID.RemoveClientAuthority();
        objNetworkID.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }


}
