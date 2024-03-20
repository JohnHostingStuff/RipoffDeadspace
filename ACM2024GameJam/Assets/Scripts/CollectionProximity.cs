using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionProximity : MonoBehaviour
{
    // Hi Jack I'm just gonna borrow your code if you don't mind :P

    private bool isPlayerInRange = false;
    
    // PlayerInfo reference
    public PlayerInfo playerInfo;
    void Start()
    {
        Debug.Log(playerInfo.currentItem);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            other.gameObject.GetComponent<PlayerMovement>();
            Debug.Log("Player entered");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("Player exited");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for input E
        if (Input.GetKeyDown(KeyCode.E) & isPlayerInRange)
        {
            // The player is now holding a bone.
            playerInfo.currentItem = PlayerInfo.Item.Bone;
            Debug.Log(playerInfo.currentItem);
        }
    }
}
