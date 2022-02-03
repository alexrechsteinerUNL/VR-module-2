using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DamageDetection : MonoBehaviour
{

    public GameObject pickup;
    public TextMeshProUGUI damageText;
    public GameObject ball;
    private int damageTaken;
    private PlayerController playerController;
    private Vector3 pickupStart;
    private Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        damageTaken = 0;
        playerController = ball.GetComponent<PlayerController>();
        startingPosition = transform.position;
        pickupStart = pickup.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerController.resetCount = false;
        if (damageTaken > 5)
		{
            playerController.resetCount = true;
            damageTaken = 0;
            damageText.text = "Damage: " + damageTaken.ToString();
            pickup.transform.position = pickupStart;
            transform.position = startingPosition;

            pickup.SetActiveRecursively(true);
        }
    }


    void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("PickUp"))
		{
            damageTaken += 1;
            damageText.text = "Damage: " + damageTaken.ToString();
		}
	}
}
