using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using LitJson;

public class NetworkManager : MonoBehaviour
{
    private int actualid;
    [SerializeField]
    string dato;
    [SerializeField]
    HammerGrabNetwork hammer;
    private void Start()
    {
        hammer.grabHammer += Sethammerdata;// event grab hammer perfomed
    }

    [ContextMenu("send data")]

    public void SendPost()
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre", dato);
        StartCoroutine(Register(form));
    }

    [ContextMenu("get all data")]

    public void GetALLbyId()
    {
       int id= NetworkSingleton.instance.IDClient;
        WWWForm form = new WWWForm();
        form.AddField("id", id);
        
        StartCoroutine(Getall(form));
    }
    /// <summary>
    /// register the new client in the data base and get the ID singleton player 
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    IEnumerator Register(WWWForm form)
    {
        string url = NetworkSingleton.instance.URLNET;
        url += "/connect.php";
        Debug.Log(url);
        UnityWebRequest www = UnityWebRequest.Post(url,form);//URl
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);

            StartCoroutine(GetID(form));
        }

    }
    /// <summary>
    /// get the ID player using the name, take care the name must be unic
    /// </summary>
    /// <param name="form"></param>
    /// <returns> ID in singleton network</returns>
    IEnumerator GetID(WWWForm form)
    {
        string url = NetworkSingleton.instance.URLNET;
        url += "/getdata.php";
        Debug.Log(url);
        UnityWebRequest www = UnityWebRequest.Post(url, form);//URl
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            string data = www.downloadHandler.text;
            int id = int.Parse(data);
            NetworkSingleton.instance.IDClient = id;// guarda en el singleton la ID del cliente 
        }

    }




    IEnumerator Getall(WWWForm form)
    {
        string url = NetworkSingleton.instance.URLNET;
        url += "/getalldata.php";
        Debug.Log(url);
        UnityWebRequest www = UnityWebRequest.Post(url, form);//URl
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            JsonData jsonData = JsonMapper.ToObject(www.downloadHandler.text);
            NetworkSingleton.instance.PlayerName = jsonData["User"].ToString();
            //NetworkSingleton.instance.IDClient =(int) jsonData["ID"];
            NetworkSingleton.instance.AttachedHammer =int.Parse( jsonData["GrabTimesHammer"].ToString());
            NetworkSingleton.instance.UsedHelmet =int.Parse( jsonData["UseHelmet"].ToString());
            NetworkSingleton.instance.Endtime =float.Parse(
                jsonData["finishTime"].ToString());

        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>

    public  void Sethammerdata()
    {
        WWWForm form = new WWWForm();
        form.AddField("id", NetworkSingleton.instance.IDClient);
        form.AddField("hammer", NetworkSingleton.instance.AttachedHammer);
        StartCoroutine(Posthammer(form));
    }


    IEnumerator Posthammer(WWWForm form)
    {
        string url = NetworkSingleton.instance.URLNET;
        url += "/sethammer.php";
        Debug.Log(url);
        UnityWebRequest www = UnityWebRequest.Post(url, form);//URl
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);

        }

    }




}
