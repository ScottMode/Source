﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : UIScreen
{
    #region Fields
    //Assigned
    
    #endregion

    /// <summary>
    /// Start game was clicked
    /// </summary>
    public void StartClicked()
    {
        //Disable this screen temporarily
        gameObject.SetActive(false);

        //Enable game world
        GameManager.Instance.Init();
    }
}
