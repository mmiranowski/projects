using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitCoins : MonoBehaviour {

    public int score = 0;

    public Text scoreText;
    public Text scoreTextEnd;
    public Text scoreTextPause;
    public Text scoreTextKill;

    void Update()
    {
        scoreText.text = score.ToString();
        scoreTextEnd.text = score.ToString();
        scoreTextPause.text = score.ToString();
        scoreTextKill.text = score.ToString();
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log(gameObject.name + " was triggerd by " + collider.name);
        if (collision.transform.root.gameObject.name == "Coins")
        {
            score++;

            //Debug.Log("Coin Collected.Score: " + score);
        }
    }
}
