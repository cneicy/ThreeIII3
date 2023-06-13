using Net.Component;
using Net.Share;
using UnityEngine;

public class Connect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ClientManager.I.client.AddRpc(this); //���ô˷���, �����ռ� [Rpc]���Եķ���
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ClientManager.I.client.SendRT("HelloWorld", "���, ������!"); //��������Ҫ����һ������ΪHelloWorld�������н���
        }
    }

    [Rpc]
    private void HelloWorldCall(string msg)
    {
        Debug.Log(msg);
    }
}