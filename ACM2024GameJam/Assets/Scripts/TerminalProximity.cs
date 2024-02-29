using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TerminalProximity : MonoBehaviour
{

    public GameObject Prompt;


    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered");

            Prompt.gameObject.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered");

            Prompt.gameObject.SetActive(false);

        }
    }


}
