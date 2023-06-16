using Net.Component;
using Net.Server;
using Net.Share;
using Net.UnityComponent;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class ServerSetting : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        ClientManager.I.ip = "127.0.0.1";
        ClientManager.I.port = 9543;
        ClientManager.I.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
