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
    //Dev
    public bool isDebug;

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
        //Play music
        SoundManager.Instance.PlayMusic("Awakening", true);

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
        Vector3 newPoint = player.transform.position + (dir * 0.92f);
        newPoint = new Vector3(newPoint.x, 1.6f, newPoint.z);

        //Begin teleport
        player.isMoving = true;
        player.targetPosition = newPoint; //newPoint

        //Animatons and particles
        player.hands.PlayNavigate();
        player.navParticles.SetActive(true);

        //Sound
        int rand = UnityEngine.Random.Range(1, 3);
        SoundManager.Instance.PlayHandEffect("navHand" + rand);
    }
}