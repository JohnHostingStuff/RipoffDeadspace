using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public float damping = 2.0f;
    private Transform playerTransform;

    void Start()
    {
        // Find the player's transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Calculate the rotation needed to look at the player
        Quaternion rotation = Quaternion.LookRotation(playerTransform.position - transform.position);

        // Smoothly rotate towards the player
       transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }
}
