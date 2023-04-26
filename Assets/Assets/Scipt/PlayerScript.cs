using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D myBody;
    private bool initial_Push;
    private int push_Count;
    private bool player_Died;
    public float move_Speed = 6f;
    public float normal_Push = 10f;
    // private JetPack jetPack;
    public FixedJoystick joystick;
    public float maxJetFuel = 100f;
    public float jetForce = 3.5f;
    public float jetFuel;
    public float maxSpeed = 10f;

    // Reference to the UI Text component that will display the jet fuel value
    public TextMeshProUGUI jetFuelText;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        // Set initial jet fuel to max
        jetFuel = maxJetFuel;
    }

    // Update is called once per frame
    void Update()
    {
        // Get joystick input
        float verticalInput = joystick.Vertical;

        // Use jet if there's enough fuel and player throws joystick upwards
        if (verticalInput > 0 && jetFuel > 0)
        {
            // Clamp horizontal velocity to maxSpeed before applying jet force
            if (Mathf.Abs(myBody.velocity.x) < maxSpeed)
            {
                myBody.AddForce(Vector2.up * jetForce);
            }

            // Decrease jet fuel over time
            jetFuel -= Time.deltaTime;
        }

        // Move the player horizontally
        float horizontalInput = joystick.Horizontal;
        myBody.velocity = new Vector2(horizontalInput * move_Speed, myBody.velocity.y);
        // Clamp horizontal velocity between negative maxSpeed and maxSpeed
        myBody.velocity = new Vector2(Mathf.Clamp(myBody.velocity.x, -maxSpeed, maxSpeed), myBody.velocity.y);

        // Update the jet fuel text
        jetFuelText.text = "Jet Fuel: " + jetFuel.ToString("0") + "/" + maxJetFuel.ToString("0");
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "ExtraPush")
        {
            if (!initial_Push)
            {
                initial_Push = true;
                myBody.velocity = new Vector2(myBody.velocity.x, 15f);
                target.gameObject.SetActive(false);
            }
        }
        else if (target.tag == "Oils")
        {
            myBody.velocity = new Vector2(myBody.velocity.x, normal_Push);
            Destroy(target.gameObject);
        }
        else if (target.tag == "Fuel")
        {
            jetFuel += 20f; // Collecting oil gives additional jet fuel
            jetFuel = Mathf.Clamp(jetFuel, 0f, maxJetFuel); // Clamp jet fuel between 0 and max
            Destroy(target.gameObject);
        }
        /*else if (target.tag == "JetPack")
        {
            jetPack.CollectJets(1);
            Destroy(target.gameObject);*/
        if (target.gameObject.tag == "Deadline")
        {
            print(111);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (target.gameObject.tag == "Win")
        {
            SceneManager.LoadScene("Win");
        }
    }
}
