using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NavEnabled : MonoBehaviour
{

    #region Fields
    private EventTrigger eventTrigger;
    #endregion

    void Start()
    {
        eventTrigger = gameObject.AddComponent<EventTrigger>();
        //Enter Event
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { InputHeld((PointerEventData)data); });
        eventTrigger.triggers.Add(entry);
        //Exit Event
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerUp;
        entry2.callback.AddListener((data) => { InputUp((PointerEventData)data); });
        eventTrigger.triggers.Add(entry2);
    }

    public void InputHeld(PointerEventData data)
    {
        InputManager.Instance.NavigationHeld(data.pointerCurrentRaycast.worldPosition);
    }

    public void InputUp(PointerEventData data)
    {
        InputManager.Instance.NavigationExit();
    }
}
