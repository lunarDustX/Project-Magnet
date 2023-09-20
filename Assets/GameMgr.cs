using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    float h, v;
    bool readyMove;
    float timer;
    Player player;


    void Start()
    {
        player = FindObjectOfType<Player>();
        readyMove = true;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.3f)
        {
            timer = 0;
            readyMove = true;
        }

        if (readyMove)
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKeyDown(KeyCode.W))
                dir = Vector2.up;
            if (Input.GetKeyDown(KeyCode.S))
                dir = Vector2.down;
            if (Input.GetKeyDown(KeyCode.A))
                dir = Vector2.left;
            if (Input.GetKeyDown(KeyCode.D))
                dir = Vector2.right;
            if (dir.sqrMagnitude > 0)
            {
                readyMove = false;
                player.Move(dir);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.SwitchPole();
        }
    }
}
