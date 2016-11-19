// File name: HorseBehaviour.cs
// Description: Defines the horse's movement
// Created by Winnie Chung on Nov. 17, 2016
// Last modified by Winnie Chung on Nov. 18, 2016
// Revision history:
// Nov. 17: File created
// Nov. 18: Sound added

using UnityEngine;
using System.Collections;

public class HorseBehaviour : MonoBehaviour
{

    //public variables (for testing)
    public AudioSource walkSound;
    public AudioSource neighSound;

    // private instance variables
    private Transform _transform;
    private Rigidbody _rigidBody;
    private GameObject _player;
    private NavMeshAgent _agent;

    private float _origDistance;

    // Use this for initialization
    void Start()
    {
        this._transform = GetComponent<Transform>();
        this._rigidBody = GetComponent<Rigidbody>();
        this._player = GameObject.FindGameObjectWithTag("Player");
        this._agent = GetComponent<NavMeshAgent>();

        this._origDistance = Vector3.Distance(this._transform.position, this._player.GetComponent<Transform>().position);
    }

    // Update is called once per frame
    void Update()
    {
        // update destination
        Vector3 destination = this._player.GetComponent<Transform>().position;
        this._agent.SetDestination(destination);

        // update volume of trot sound
        float distance = Vector3.Distance(this._transform.position, destination);
        walkSound.volume = .25f * this._origDistance / distance;

    }

    // play neigh sound if the player is hit
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            neighSound.Play();
        }
    }
}
