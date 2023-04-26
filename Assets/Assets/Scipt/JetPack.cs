using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    public float jetForce = 10f;  // The force applied to the player when using the jet
    public float jetDuration = 1f;  // The duration (in seconds) of the jet
    public int maxJetCount = 3;  // The maximum number of jets the player can carry
    private int jetCount;  // The current number of jets the player has
    private bool usingJet;  // Flag to indicate if the player is currently using the jet
    private float jetTimer;  // Timer to keep track of how long the jet has been used

    // Start is called before the first frame update
    void Start()
    {
        jetCount = maxJetCount;
        usingJet = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is using the jet and has time left
        if (usingJet && jetTimer > 0f)
        {
            // Apply the jet force to the player
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jetForce));

            // Reduce the jet timer
            jetTimer -= Time.deltaTime;
        }
        else
        {
            // Stop using the jet
            usingJet = false;
        }
    }

    // Method to use the jet
    public void UseJet()
    {
        if (jetCount > 0 && !usingJet)
        {
            // Start using the jet
            usingJet = true;
            jetCount--;
            jetTimer = jetDuration;
        }
    }

    // Method to collect more jets
    public void CollectJets(int count)
    {
        jetCount += count;
        if (jetCount > maxJetCount)
        {
            jetCount = maxJetCount;
        }
    }
}