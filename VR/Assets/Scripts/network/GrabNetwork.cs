using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabNetwork : MonoBehaviour
{
    public delegate void GrabHammer();
    public GrabHammer grabHammer;

    public delegate void UseHelmet();
    public UseHelmet useHelmet;
    public delegate void EndJob();
    public EndJob endjob;


    float timer;

    public void Start()
    {
        timer = Time.time;
    }
    [ContextMenu("hammer set")]
    public void HammerAttached()
    {
        NetworkSingleton.instance.AttachedHammer++; //increase  number hammer grab
        grabHammer.Invoke();
    }

    [ContextMenu("set hammer")]
    public void WearHelmet()
    {
        NetworkSingleton.instance.UsedHelmet = true;
        useHelmet.Invoke();
    }

   

    [ContextMenu("terminar")]
    public void Endjob()
    {
        timer = Mathf.Abs(timer - Time.time);
        NetworkSingleton.instance.Endtime = timer;
        endjob.Invoke();
    }

}
