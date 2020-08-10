using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileMainMenu : MonoBehaviour
{
    public SocketIOComponent soc;

    public Text code;

    public void JoinButton()
    {
        JSONObject jdata = new JSONObject();
        jdata.AddField("code", code);

        soc.Emit("Join", jdata);
    }

    public void HostButton()
    {
        JSONObject jdata = new JSONObject();
        jdata.AddField("code", code);

        soc.Emit("Host", jdata);
    }

    public void QuitButton()
    {

    }
}
