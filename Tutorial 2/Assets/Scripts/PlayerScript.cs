using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public int score;
    public int lives;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject winTextObject;
    public GameObject loseTextObject;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score = 0;

        rd2d = GetComponent<Rigidbody2D>();
        lives = 3;

        SetScoreText();
        winTextObject.SetActive(false);

        SetScoreText();
        loseTextObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            score += 1;
            SetScoreText();
            Destroy(collision.collider.gameObject);
        }

        if (collision.collider.tag == "Enemy")
        {
            lives -= 1;
            SetScoreText();
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse); //the 3 in this line of code is the player's "jumpforce," and you change that number to get different jump behaviors.  You can also create a public variable for it and then edit it in the inspector.
            }
        }
    }

    private void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score == 4)
        {
            winTextObject.SetActive(true);
        }

        livesText.text = "Lives: " + lives.ToString();
        if (lives == 0)
        {
            loseTextObject.SetActive(true);
        }
    }
}