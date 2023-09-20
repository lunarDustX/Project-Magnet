using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Magnet[] magnets;

    void Start()
    {
        magnets = FindObjectsOfType<Magnet>();
    }

    void Update()
    {

    }

    // 玩家input触发的移动
    public void Move(Vector2 _dir)
    {
        foreach (Magnet mag in magnets)
            mag.moveDepth = 99999;
        GetComponent<Magnet>().Move(_dir, 0);
    }

    public void SwitchPole()
    {
        GetComponent<Magnet>().SwitchPole();
    }


}
