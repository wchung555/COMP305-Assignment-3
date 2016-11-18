// File name: HorseBehaviour.cs
// Description: Defines the horse's movement
// Created by Winnie Chung on Nov. 17, 2016
// Last modified by Winnie Chung on Nov. 17, 2016
// Revision history:
// Nov. 17: File created

using UnityEngine;
using System.Collections;

public class HorseBehaviour : MonoBehaviour {

    // private instance variables
    private Transform _transform;
    private Rigidbody _rigidBody;
    private GameObject _player;
    private NavMeshAgent _agent;

    // Use this for initialization
    void Start () {
        this._transform = GetComponent<Transform>();
        this._rigidBody = GetComponent<Rigidbody>();
        this._player = GameObject.FindGameObjectWithTag("Player");
        this._agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        this._agent.SetDestination(this._player.GetComponent<Transform>().position);
    }
}
