using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp;
using Random = UnityEngine.Random;

public class GamePlay : MonoBehaviour
{
    public string roomID;
    public GameObject players;
    public GameObject player;

    private WebSocket conn;

    private Player myPlayer;
    private IDictionary<string, Player> otherPlayers = new Dictionary<string, Player>();

    ConcurrentQueue<string> queue = new ConcurrentQueue<string>();

    void Start()
    {
        myPlayer = CreatePlayer(true, Random.Range(999, 9999).ToString());

        conn = new WebSocket("ws://127.0.0.1:1106/ws/play/" + roomID + "/" + myPlayer.id);
        conn.OnMessage += OnMessage;
        conn.OnError += OnError;
        conn.Connect();
    }

 

    Player CreatePlayer(bool mine, string playerID)
    {
        GameObject playerInstantiate = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);

        Player playerCom = playerInstantiate.GetComponent<Player>();
        playerCom.id = playerID;
        playerCom.name = "Player #" + playerCom.id;
        playerCom.mine = mine;

        playerInstantiate.transform.SetParent(players.transform);
        playerInstantiate.SetActive(true);

        return playerCom;
    }

    private void OnMessage(object sender, MessageEventArgs e)
    {
        if (!e.IsText)
        {
            return;
        }

        queue.Enqueue(e.Data);
    }

    private void OnError(object sender, ErrorEventArgs e)
    {
        Debug.Log(e);
    }

    void OnDestroy()
    {
        if (conn != null && conn.ReadyState == WebSocketState.Open)
            conn.Close();
    }

    private void Handle(string message)
    {
        Debug.Log(message);
        JObject data = JObject.Parse(message);

        if (data.ContainsKey("error"))
        {
        }

        if (data.ContainsKey("method"))
        {
            string playerId;

            switch (data["method"].ToString())
            {
                case "SUBSCRIBE":
                    playerId = data["player"].ToString();
                    if (playerId == "123")
                    {
                        break;
                    }

                    otherPlayers.Add(playerId, CreatePlayer(false, playerId));
                    break;
                case "UNSUBSCRIBE":
                    playerId = data["player"].ToString();
                    Destroy(otherPlayers[playerId].gameObject);
                    otherPlayers.Remove(playerId);
                    break;
                case "MESSAGE":
                    switch (data["message"]["action"].ToString())
                    {
                        case "MOVE":
                            playerId = data["player"].ToString();
                            otherPlayers[playerId].playerMovement.MoveTo(new Vector3(
                                (float) data["message"]["position"]["x"],
                                (float) data["message"]["position"]["y"], (float) data["message"]["position"]["z"]));
                            break;
                    }

                    break;
            }
        }
    }

    public void Send(object message)
    {
        conn.Send(JsonConvert.SerializeObject(message));
    }

    void Update()
    {
        // if (queue.TryDequeue(out string message))
        // {
        //     Handle(message);
        // }
    }
}