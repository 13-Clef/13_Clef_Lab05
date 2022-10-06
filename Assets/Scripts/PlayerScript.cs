using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int coin;
    public GameObject coinText;

    public float timer;
    public Text timerText;

    public ParticleSystem particle;

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

        timer -= Time.deltaTime;
        timerText.text = "Timer: " + timer.ToString("0:00") + " Seconds";

        if (timer <= 0)
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coin += 10;
            Destroy(other.gameObject);
            particle.Play();
            coinText.GetComponent<Text>().text = "Score: " + coin;
        }

        if (other.gameObject.tag == "Water")
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }

    
}
