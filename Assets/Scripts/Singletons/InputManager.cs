using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;
using System;
using UnityEngine.Analytics;
using System.Collections;

/// <summary>
/// Responsible for player navigation, melody combos, any player controlled interaction
/// </summary>
public class InputManager : Singleton<InputManager>
{

    #region Fields
    //Navigation
    public bool navEnabled = true;
    public bool navHeld = false;
    public float navActivationTime;
    public float navHeldTime = 0f;
    private Vector3 navPoint;
    
    #endregion

    protected InputManager(){}

    void Update()
    {
        //Navigation
        if (navHeld && navEnabled)
        {
            navHeldTime += Time.deltaTime;
            if (navHeldTime >= navActivationTime)
            {
                navHeldTime = 0f;
                navEnabled = false;

                //Trigger nav in game manager
                GameManager.Instance.MovePlayer(navPoint);
            }
        }
        else
        {
            //Currently moving or movement disabled

        }
    }

    /// <summary>
    /// Navigation held down and activated 
    /// </summary>
    public void NavigationHeld(Vector3 navPointParam)
    {
        navPoint = navPointParam;
        Debug.Log("Nav point: " + navPoint);
        navHeld = true;
    }

    /// <summary>
    /// Exits the current navigation
    /// </summary>
    public void NavigationExit()
    {
        navHeld = false;
        navHeldTime = 0f;
    }

    /// <summary>
    /// Prevents the player from moving
    /// </summary>
    public void LockNavigation(bool lockThis)
    {
        navEnabled = !lockThis;
    }
}