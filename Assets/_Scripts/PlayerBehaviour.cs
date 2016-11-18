// File name: PlayerBehaviour.cs
// Description: Defines how the player's avatar interacts with other game objects
// Created by Winnie Chung on Nov. 17, 2016
// Last modified by Winnie Chung on Nov. 17, 2016
// Revision history:
// Nov. 17: File created

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{
    // public variables (for testing)
    public AudioSource hurtSound;
    public AudioSource deadSound;
    public AudioSource treasureSound;

    // private instance variables
    private int _score, _lives;
    private Text _scoreText, _livesText;

    // Use this for initialization
    void Start()
    {
        this._score = 0;
        this._lives = 100;

        this._scoreText = GameObject.Find("score").GetComponent<Text>();
        this._livesText = GameObject.Find("lives").GetComponent<Text>();
    }

    // Update is called once per frame (for physics)
    void FixedUpdate()
    {
        if (this._lives > 0)
        {
            this._scoreText.text = "Score: " + this._score;
            this._livesText.text = "Lives: " + this._lives;
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("treasure"))
        {
            this._score += 100;
            Destroy(hit.gameObject);
            treasureSound.Play();
        }
        else if (hit.gameObject.CompareTag("obstacle"))
        {
            if (this._lives > 0)
            {
                hurtSound.Play();
                this._lives--;
            }
            else
            {
                deadSound.Play();
            }
        }
    }
}
