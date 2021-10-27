using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using LitJson;

public class NetworkManager : MonoBehaviour
{
    
    [SerializeField]
    string dato;  // solo prueba de campo
    [SerializeField]
    HammerGrabNetwork hammer;

   
    
    private void Start()
    {
        hammer.grabHammer += Sethammerdata;// event grab hammer perfomed
        hammer.useHelmet += SetHelmetdata;
        hammer.endjob += SetTimedata;
    }

    [ContextMenu("send data")]

    public void SendPost()
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre", dato);
        string url = NetworkSingleton.instance.URLNET+"/connect.php";
        StartCoroutine(SendDataPost(form,url));
        StartCoroutine(GetID(form));
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
            //Debug.Log(www.downloadHandler.text);
            string data = www.downloadHandler.text;
            int id = int.Parse(data);
            NetworkSingleton.instance.IDClient = id;// guarda en el singleton la ID del cliente 
        }

    }



    public void SetHelmetdata()
    {
        WWWForm form = new WWWForm();
        form.AddField("id", NetworkSingleton.instance.IDClient);
        int usehelmet = NetworkSingleton.instance.UsedHelmet == true ? 1 : 0;
        form.AddField("usehelmet", usehelmet);
        string url = NetworkSingleton.instance.URLNET + "/sethelmet.php";
        StartCoroutine(SendDataPost(form, url));
    }
   

    public void Sethammerdata()
    {
        WWWForm form = new WWWForm();
        form.AddField("id", NetworkSingleton.instance.IDClient);
        form.AddField("hammer", NetworkSingleton.instance.AttachedHammer);
        string url = NetworkSingleton.instance.URLNET + "/sethammer.php";
        StartCoroutine(SendDataPost(form,url));
    }


    public void SetTimedata()
    {
        WWWForm form = new WWWForm();
        form.AddField("id", NetworkSingleton.instance.IDClient);
        form.AddField("time", NetworkSingleton.instance.Endtime.ToString()); ;
        string url = NetworkSingleton.instance.URLNET+ "/settimer.php";
        StartCoroutine(SendDataPost(form,url));
        
    }

    /// <summary>
    /// Send data into the API with post method
    /// </summary>
    /// <param name="form"></param>
    
    IEnumerator SendDataPost(WWWForm form,string url)
    {
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
    /// <summary>
    /// get data form the API
    /// </summary>
    /// <param name="form"></param>
    /// <returns>all data in the singleton player class</returns>
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
            //Debug.Log(www.downloadHandler.text);
            //decode json Data
            JsonData jsonData = JsonMapper.ToObject(www.downloadHandler.text);
            NetworkSingleton.instance.PlayerName = jsonData["User"].ToString();
            //NetworkSingleton.instance.IDClient =(int) jsonData["ID"];
            NetworkSingleton.instance.AttachedHammer = int.Parse(jsonData["GrabTimesHammer"].ToString());
            NetworkSingleton.instance.UsedHelmet = (int.Parse(jsonData["UseHelmet"].ToString()) >= 1) ? true : false;
            NetworkSingleton.instance.Endtime = float.Parse(jsonData["finishTime"].ToString());

        }

    }
}
