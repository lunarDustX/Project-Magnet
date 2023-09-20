using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    void Start()
    {

    }

    void Update()
    {

    }

    public void Move(Vector2 _dir)
    {
        GetComponent<Magnet>().Move(_dir);

        //transform.position += (Vector3)_dir;
        //GetComponent<Magnet>().CheckSurrounding(_dir);
    }

    public void SwitchPole()
    {
        GetComponent<Magnet>().SwitchPole();
    }


}
