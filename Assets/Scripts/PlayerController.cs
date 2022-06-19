using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Player player;

    private Vector2 _screenPosition = new(0, 0);

    private Vector3 _worldPosition = new(0, 0, 0);


    // Update is called once per frame
    void Update()
    {
        // Right-clicked
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
        }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);
    }

    private void FixedUpdate()
    {
        player.MoveTo(_worldPosition);
    }

    private void ditmehuy()
    {

    }
}
