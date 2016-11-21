// File name: MenuController.cs
// Description: Defines the transition to the main gameplay scene
// Created by Winnie Chung on Nov. 20, 2016
// Last modified by Winnie Chung on Nov. 20, 2016
// Revision history:
// Nov. 20: File created

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // transition to main gamplay screen when the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
