// File name: GameController.cs
// Description: Keeps track of lives and scoring on the main gameplay scene
// Created by Winnie Chung on Nov. 20, 2016
// Last modified by Winnie Chung on Nov. 20, 2016
// Revision history:
// Nov. 20: File created

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // private instance variables
    private Text _title1Text, _title2Text, _startText;

    private int _score, _lives;
    private Text _scoreText, _treasuresText, _livesText;

    private GameObject[] _treasures;
    private int _treasuresLeft;

    private Transform _backupCam;
    private GameObject _minimap;

    private bool _isRestart;

    // public properties
    public int Score
    {
        get
        {
            return _score;
        }
    }

    public int Lives
    {
        get
        {
            return _lives;
        }
    }

    // Use this for initialization
    void Start()
    {
        this._title1Text = GameObject.Find("title1").GetComponent<Text>();
        this._title2Text = GameObject.Find("title2").GetComponent<Text>();
        this._startText = GameObject.Find("start").GetComponent<Text>();

        this._title1Text.gameObject.SetActive(false);
        this._title2Text.gameObject.SetActive(false);
        this._startText.gameObject.SetActive(false);

        this._backupCam = GameObject.Find("Backup Cam").GetComponent<Transform>();
        this._minimap = GameObject.Find("minimap");

        this._score = 0;
        this._lives = 50;

        this._treasures = GameObject.FindGameObjectsWithTag("treasure");
        this._treasuresLeft = this._treasures.Length;

        this._scoreText = GameObject.Find("score").GetComponent<Text>();
        this._treasuresText = GameObject.Find("treasure").GetComponent<Text>();
        this._livesText = GameObject.Find("lives").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // if game ended, restart scene when left mouse button is clicked
        if (this._isRestart && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Main");
        }

        if (this._lives > 0)
        {
            // move backup camera
            this._backupCam.position = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
            this._backupCam.position = new Vector3(this._backupCam.position.x, this._backupCam.position.y + .8f, this._backupCam.position.z);

            // update lives, score, and treasures UI elements
            this._scoreText.text = "Score: " + this._score;
            this._treasuresText.text = "Treasures left: " + this._treasuresLeft;
            this._livesText.text = "Lives: " + this._lives;
        }
        else
        {
            EndGame(true);
        }
    }

    // Displays UI elements indicating that the game is over
    public void EndGame(bool isDead)
    {
        this._isRestart = true;

        if (!isDead)
        {
            this._title1Text.text = "Game";
            this._title2Text.text = "Clear";
        }
        else
        {
            this._title1Text.text = "Game";
            this._title2Text.text = "Over";
        }

        this._title1Text.gameObject.SetActive(true);
        this._title2Text.gameObject.SetActive(true);
        this._startText.gameObject.SetActive(true);

        this._minimap.SetActive(false);
    }

    // Decrease lives
    public void HitEnemy()
    {
        this._lives--;
    }

    // Increase score
    public void GetTreasure()
    {
        if (this._treasuresLeft > 0)
        {
            this._score += 100;
            this._treasuresLeft--;
        }
        else
        {
            EndGame(false);
        }
    }
}
