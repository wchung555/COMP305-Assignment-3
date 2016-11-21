// File name: PlayerBehaviour.cs
// Description: Defines how the player's avatar interacts with other game objects
// Created by Winnie Chung on Nov. 17, 2016
// Last modified by Winnie Chung on Nov. 20, 2016
// Revision history:
// Nov. 17: File created
// Nov. 17: Tag for horse added
// Nov. 20: Moved score, lives to GameController

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
    private GameController _controller;

    // Use this for initialization
    void Start()
    {
        this._controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider hit)
    {
        // if treasure was collected, increase score and play treasure sound
        if (hit.gameObject.CompareTag("treasure"))
        {
            this._controller.GetTreasure();
            Destroy(hit.gameObject);
            treasureSound.Play();
        }
        // if hit by obstacle or horse, decrease lives and play sound
        else if (hit.gameObject.CompareTag("obstacle") || hit.gameObject.CompareTag("horse"))
        {
            if (this._controller.Lives > 0)
            {
                if (hit.gameObject.CompareTag("obstacle"))
                    hurtSound.Play();
                this._controller.HitEnemy();
            }
            // if ran out of lives, play dead sound
            else
            {
                deadSound.Play();
                Destroy(gameObject);
            }
        }
        else if (hit.gameObject.CompareTag("death"))
        {
            this._controller.EndGame(true);
            deadSound.Play();
        }
    }
}
