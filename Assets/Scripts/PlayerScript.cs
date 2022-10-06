using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int coin;
    public GameObject coinText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (coin >= 60)
        {
            SceneManager.LoadScene("GameWinScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coin += 10;
            Destroy(other.gameObject);
            coinText.GetComponent<Text>().text = "Score: " + coin;
        }

        if (other.gameObject.tag == "Water")
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }
}
