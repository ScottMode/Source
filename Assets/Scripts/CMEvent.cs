using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CMEventType
{
    Animation,
    Sfx,
    Music,
    Camera,
    Custom
}

public enum CMEventTriggerType
{
    Autostart,
    Sequence, 
    TriggerEnter
}

public class CMEvent : MonoBehaviour
{
    #region Fields
    //Logic
    public CMEventType eventType;
    public CMEventTriggerType triggerType;
    public float startDelay;
    public float exitTime;
    private bool started = false;
    private bool finished = false;

    //Assigned
    public string audioFileName;
    public AudioSource targetAudioSource;
    public CMEvent nextEvent;
    #endregion

    
    void Start()
    {
        if (triggerType == CMEventTriggerType.Autostart)
        {
            PlayEvent();
        }
    }
    
    void Update()
    {
        if (startDelay > 0f)
        {
            startDelay -= Time.deltaTime;

            if (startDelay <= 0f)
            {
                startDelay = 0f;
                PlayEvent();
            }
        }
    }

    /// <summary>
    /// Plays the event
    /// </summary>
    public void PlayEvent()
    {
        started = true;

        switch (eventType)
        {
            case CMEventType.Sfx:
                if (targetAudioSource != null)
                {
                    //Play audio at target source
                    
                }
                else
                {
                    Debug.Log("Failed to provide audio source, event " + gameObject.name + " completing");
                    EventComplete();
                }
                break;
        }
    }


    /// <summary>
    /// Event has been completed
    /// </summary>
    public void EventComplete()
    {

    }
}
