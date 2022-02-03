using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;
	public bool resetCount;

        private float movementX;
        private float movementY;

	private Rigidbody rb;
	private int count;

	public AudioSource Clink;

	// At the start of the game..
	void Start ()
	{
		resetCount = false;
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;

		SetCountText ();

                // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
                winTextObject.SetActive(false);
	}

	void Update()
	{
		if (resetCount == true)
		{
			count = 0;
			Debug.Log("RESET");
			SetCountText(); 
		}
	}

	void FixedUpdate ()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();

			Clink.Play();
		}

		if (other.gameObject.CompareTag("chaser"))
		{
			other.gameObject.transform.Translate(10, 10, 10);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText();

			Clink.Play();
		}
	}

        void OnMove(InputValue value)
        {
        	Vector2 v = value.Get<Vector2>();

        	movementX = v.x;
        	movementY = v.y;
        }

        void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 15) 
		{
			// Set the text value of your 'winText'
			winTextObject.SetActive(true);
			GameObject[] gameObjectPickup = GameObject.FindGameObjectsWithTag("pickUp");
			GameObject[] gameObjectChaser = GameObject.FindGameObjectsWithTag("chaser");
			foreach (GameObject objPickup in gameObjectPickup)
			{
				objPickup.SetActive(false);
			}
			foreach (GameObject objPickup in gameObjectChaser)
			{
				objPickup.SetActive(false);
			}


		}
	}
}