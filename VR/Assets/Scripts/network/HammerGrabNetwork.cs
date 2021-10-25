using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerGrabNetwork : MonoBehaviour
{
    public delegate void GrabHammer();
    public GrabHammer grabHammer;


    [ContextMenu("hammer set")]
    public void HammerAttached()
    {
        NetworkSingleton.instance.AttachedHammer++; //increase  number hammer grab
        grabHammer.Invoke();
    }

 
    
}
