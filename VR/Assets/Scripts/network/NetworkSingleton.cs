using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkSingleton : MonoBehaviour
{
    public static NetworkSingleton instance;
    [SerializeField]
    NetwokObject player;
    [SerializeField]
      string URL;
    
    

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    public string URLNET
    {
        get { return URL; }   // get method
        set { URL = value; }  // set method
    }
    // Player Parameters
    public string PlayerName
    {
        get { return player.name; }
        set
        {
            player.name = value;
        }
    }
    public int IDClient
    {
        get { return player.id; }   // get method
        set { player.id = value; }  // set method
    }
    public int AttachedHammer
    {
        get { return player.timesHammer; }
        set { player.timesHammer= value; }
    }
    public bool UsedHelmet
    {
        get
        {
            return player.helmetused;
        }
        set
        {
            player.helmetused = value;
         }
    }
    public float Endtime
    {
        get { return player.endTime; }
        set { player.endTime = value; }
    }
}
