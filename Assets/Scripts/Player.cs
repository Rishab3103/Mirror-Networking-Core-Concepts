using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using TMPro;
public class Player : NetworkBehaviour
{
    [SerializeField] private Vector3 movement = new Vector3();
    [SyncVar(hook = nameof(OnHolaCountChanged))]
    int holaCount = 0;
 
    // Start is called before the first frame update

    public void Start()
    {
        
        
    }

    public void HandleMovement()
    {
        if(isLocalPlayer)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal * 0.1f, moveVertical *0.1f, 0);
            transform.position = transform.position + movement;
            
        }
    }

    public void Update()
    {
        HandleMovement();
        if(isLocalPlayer&& Input.GetKeyDown(KeyCode.X))
        {
            
            Debug.Log("Sending Hola to Server");
            Hola();
        }
        
        if(isServer && transform.position.y>3)
        {
            HeightThreshold();
        }

    }

    public override void OnStartServer()
    {
        Debug.Log("Player has been spawned on the Server");
    }

    [Command]
    void Hola()
    {
        Debug.Log("Received Hola from Client");
        holaCount += 1;
        ReplyHola();
    }
    [TargetRpc]
    void ReplyHola()
    {
        Debug.Log("Received Hola from Server");
    }

    [ClientRpc]
    void HeightThreshold()
    {
        Debug.Log("Height Threshold crossed");
    }

    public void OnHolaCountChanged(int oldCount, int newCount) 
    {
        Debug.Log($"We had {oldCount} holas, but now we have {newCount} holas");
    }
    

    
}
