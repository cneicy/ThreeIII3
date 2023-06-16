using Net.Client;
using Net.UnityComponent;
using UnityEngine;
public class SpawnPoint : MonoBehaviour
{
    public bool trigger=false;
    public NetworkObject Object;
    void Update()
    {
        if (NetworkObject.IsInitIdentity&&trigger==false)
        {
            var player = Instantiate(Object,transform.position,Quaternion.identity);
            player.Identity = ClientBase.Instance.UID;
            player.GetComponent<Player>().isLocalPlayer = true;
            trigger = true;
        }
    }
}
