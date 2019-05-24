using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Fields

    //Movement
    public bool isMoving = false;
    public Vector3 moveVelocity = Vector3.zero;
    public float travelTime;
    public Vector3 targetPosition;

    //Hands
    public HandAnimations hands;

    //Effects
    public GameObject navParticles;

    //Camera
    public GameObject camera;

    #endregion

    void Update()
    {
        //Movement
        if (isMoving)
        {
            //Smooth damp to position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref moveVelocity, travelTime);

            //Stop movement
            if (transform.position == targetPosition)
            {
                InputManager.Instance.navEnabled = true;
                isMoving = false;
                targetPosition = Vector3.zero;

                //Effects stop
                navParticles.SetActive(false);

                //Sound
                //SoundManager.Instance.PlaySurroundEffect("navStop2");
            }
        }

        //Hands
        if (!isMoving)
        {
            hands.transform.rotation = camera.transform.rotation;
        }

        //Effects
        navParticles.transform.rotation = camera.transform.rotation;

    }


    /// <summary>
    /// Inits the player at the start of the game
    /// </summary>
    public void Init()
    {
        hands.gameObject.SetActive(true);
    }
}
