using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalProximity : MonoBehaviour
{

    // Prompt text
    public GameObject Prompt;

    // To assign player camera
    public GameObject playerCamera;

    // Define the terminal's position 
    public Transform targetPosition;

    // Define playerbody position to return to
    public Transform originalPosition;

    // Disable MouseLook and movement script attached to player
    public GameObject lookScriptObject;
    public GameObject moveScriptObject;

    private bool isCameraEnabled = true;
    private bool isPlayerInRange = false;

    //Terminal screen
    public GameObject TerminalScreen;



    void Start()
    {
        isCameraEnabled = !isCameraEnabled;

        TerminalScreen.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {

            isPlayerInRange = true;
           // Debug.Log("Player entered");
            Prompt.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;

            //Debug.Log("Player exited");
            Prompt.gameObject.SetActive(false);
        }
    }

    void Update()
    {


        // Check for input E
        if (Input.GetKeyDown(KeyCode.E) & isPlayerInRange)
        {


            // Toggle the camera script on/off
            isCameraEnabled = !isCameraEnabled;

            // If the camera is enabled, disable the MouseLook script
            if (isCameraEnabled)
            {
            

                MouseLook script = lookScriptObject.GetComponent<MouseLook>();
                script.enabled = false;

                PlayerMovement moveScript = moveScriptObject.GetComponent<PlayerMovement>();
                moveScript.enabled = false;

                Cursor.lockState = CursorLockMode.None;

                TerminalScreen.gameObject.SetActive(true);


                Prompt.gameObject.SetActive(false);

                // Set the camera's position and rotation
                playerCamera.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                playerCamera.transform.position = targetPosition.position;
            }
            // If the camera is disabled, enable the MouseLook script
            if (!isCameraEnabled)
            {
                // Re-enable the MouseLook script
                MouseLook script = lookScriptObject.GetComponent<MouseLook>();
                script.enabled = true;

                PlayerMovement moveScript = moveScriptObject.GetComponent<PlayerMovement>();
                moveScript.enabled = true;

                Cursor.lockState = CursorLockMode.Locked;

                TerminalScreen.gameObject.SetActive(false);

                //  playerCamera.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                playerCamera.transform.position = originalPosition.position;


                

                Prompt.gameObject.SetActive(true);

            }

        }
    }


}
