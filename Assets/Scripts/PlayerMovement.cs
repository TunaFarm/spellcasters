using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player player;
    private Vector3 target;
    private float speed = 4.4f;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if ( player.mine && Input.GetMouseButtonDown(1))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;

            player.Move(target);
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    
    public void MoveTo(Vector3 vector3)
    {
        target = vector3;
    }
}
