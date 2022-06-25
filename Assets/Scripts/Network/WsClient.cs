using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class WsClient : MonoBehaviour
{
    // TODO: Move this into configuration file later
    private readonly string _wsURL = "ws://localhost:1106/ws/play/1";
    private WebSocket _ws;

    private void Start()
    {
        _ws = new WebSocket(_wsURL);
        _ws.Connect();

        _ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message Received from " + ((WebSocket)sender).Url + ", Data : " + e.Data);
        };
    }

    // Update is called once per frame
    private void Update()
    {
        if (_ws == null)
        {
            return;
        }
    }
}
