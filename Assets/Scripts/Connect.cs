using Net.Component;
using Net.Share;
using UnityEngine;

public class Connect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ClientManager.I.client.AddRpc(this); //调用此方法, 可以收集 [Rpc]特性的方法
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ClientManager.I.client.SendRT("HelloWorld", "你好, 服务器!"); //服务器需要定义一个方法为HelloWorld方法进行接收
        }
    }

    [Rpc]
    private void HelloWorldCall(string msg)
    {
        Debug.Log(msg);
    }
}