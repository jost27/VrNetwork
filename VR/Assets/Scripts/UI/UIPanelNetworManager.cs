using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelNetworManager : MonoBehaviour
{
    [SerializeField]
    Text id, _name, hammer, helmet, time;

    [ContextMenu("uiData")]
    public void SetUIData()
    {


        id.text = NetworkSingleton.instance.IDClient.ToString();
        _name.text = NetworkSingleton.instance.PlayerName.ToString();
        hammer.text = NetworkSingleton.instance.AttachedHammer.ToString();
        helmet.text = NetworkSingleton.instance.UsedHelmet.ToString();
        time.text = NetworkSingleton.instance.Endtime.ToString();
    }
}
