using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerScript player;
    public void changeToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerScript>();
    }

    private void Update()
    {
        if (player.playerHealth <= 0)
        {
            changeToScene(2);
        }
    }
}
