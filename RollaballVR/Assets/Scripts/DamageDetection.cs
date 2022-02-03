using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DamageDetection : MonoBehaviour
{

    public TextMeshProUGUI damageText;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(count >= 6)
		{
            Time.timeScale = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
    }


    void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("PickUp"))
		{
            count += 1;
            damageText.text = "Damage: " + count.ToString();
		}
	}
}
