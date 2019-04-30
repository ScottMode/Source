using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;
using System;
using UnityEngine.Analytics;
using System.Collections;

public class GameManager : Singleton<GameManager>
{
    #region Fields
    //World
    public GameObject gameWorld;

    //Player
    public Player player;
    #endregion

    protected GameManager() { }

    void Awake()
    {
        //Hide game world
        gameWorld.SetActive(false);
    }

    /// <summary>
    /// Inits the game world
    /// </summary>
    public void Init()
    {
        //Set objects to active
        gameWorld.SetActive(true);

        //Init player
        player.Init();
    }

    /// <summary>
    /// Teleports the player to select position
    /// </summary>
    /// <param name="position"></param>
    public void MovePlayer(Vector3 position)
    {
        //Alter position so as to not run through walls
        //This currently makes a triangle
        Vector3 dir =  position - player.transform.position;
        Vector3 newPoint = player.transform.position + (dir * 0.95f);
        newPoint = new Vector3(newPoint.x, 1.6f, newPoint.z);

        //Begin teleport
        player.isMoving = true;
        player.targetPosition = newPoint; //newPoint
    }
}