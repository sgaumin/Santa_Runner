using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float movementSpeed = 100f;
    [SerializeField] private float screenBoundaryBuffer = 20f; // Adjust how far off screen player can go
    [SerializeField] private string deathColliderTag = "Building";
    [SerializeField] private GameObject refGM;
    [SerializeField] private GameObject refWind;

    private Vector3 movement;
	private Rigidbody body;

	protected void Start()
	{
		body = GetComponent<Rigidbody>();
	}

	private void Update()
	{
        // User input
		movement.x = Input.GetAxis("Horizontal");
		movement.z = Input.GetAxis("Vertical");

        // Apply force based on user input
		body.AddForce(movement * movementSpeed * Time.deltaTime, ForceMode.Impulse);

        // Apply wind, can disable on Wind object inspector
        Vector3 wind_vel = refWind.GetComponent<WindBehavior>().GetWindVel();
        body.AddForce(wind_vel * Time.deltaTime);

        // Only move player if on screen, else stop the play on screen boundaries IF the player has enough velocity to push past boundary
        // Also reset the moving velocity in the direction of collision to allow faster recovery in opposite direction
        Vector3 player_screen = Camera.main.WorldToScreenPoint(transform.position);
        float original_y = transform.position.y; 
        //Debug.Log(player_screen);
        if (player_screen.x < screenBoundaryBuffer && body.velocity.x < 0)
        {
            player_screen.x = screenBoundaryBuffer;
            body.velocity = new Vector3(0, body.velocity.y, body.velocity.z);
        }
        else if (player_screen.x > (Screen.width - screenBoundaryBuffer) && body.velocity.x > 0)
        {
            player_screen.x = Screen.width - screenBoundaryBuffer;
            body.velocity = new Vector3(0, body.velocity.y, body.velocity.z);
        }
        if (player_screen.y < screenBoundaryBuffer && body.velocity.z < 0)
        {
            player_screen.y = screenBoundaryBuffer;
            body.velocity = new Vector3(body.velocity.x, body.velocity.y, 0);
        }
        else if (player_screen.y > (Screen.height - screenBoundaryBuffer) && body.velocity.z > 0)
        {
            player_screen.y = Screen.height - screenBoundaryBuffer;
            body.velocity = new Vector3(body.velocity.x, body.velocity.y, 0);
        }
        transform.position = Camera.main.ScreenToWorldPoint(player_screen);
        transform.position = new Vector3(transform.position.x, original_y, transform.position.z); // Make sure player doesn't move up or down
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == deathColliderTag)
        {
            //Debug.Log("Player collided with a building");
            MenuManager.Instance.toState(Game.GameStates.GameOver);
        }
    }
}
