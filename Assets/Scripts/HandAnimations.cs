using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimations : MonoBehaviour
{
    #region Fields
    //Assigned
    public Animator handsAnimator;
    public Animator motionAnimator;
    #endregion

    /// <summary>
    /// Plays the navigation animation 
    /// </summary>
    public void PlayNavigate()
    {
        handsAnimator.Play("EnterNavigate");
        motionAnimator.Play("NavigateMotion");
    }
}
