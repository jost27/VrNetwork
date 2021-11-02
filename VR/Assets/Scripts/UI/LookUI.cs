using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUI : MonoBehaviour
{
    GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(mainCamera.transform, Vector3.up);
    }
}
