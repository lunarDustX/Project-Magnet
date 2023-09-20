using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MagnetPole
{
    S,
    N
}

public class Magnet : MonoBehaviour
{
    public MagnetPole pole;

    private SpriteRenderer sr;

    Magnet[] magnets;

    public void ChangePole(MagnetPole _pole)
    {
        if (sr == null)
            sr = GetComponent<SpriteRenderer>();

        pole = _pole;
        switch (pole)
        {
            case MagnetPole.N:
                sr.color = Color.blue;
                break;
            case MagnetPole.S:
                sr.color = Color.red;
                break;
        }
    }

    public void SwitchPole()
    {
        if (pole == MagnetPole.N)
            ChangePole(MagnetPole.S);
        else
            ChangePole(MagnetPole.N);
    }

    Vector2 comingDir;
    public void CheckSurrounding(Vector2 _comingDir)
    {
        comingDir = _comingDir;
        Invoke("RealCheck", 0.1f);
    }

    private void RealCheck()
    {
        foreach (Magnet mag in magnets)
        {
            // 相邻
            if (Vector2.Distance(transform.position, mag.transform.position) == 1f)
            {
                Vector2 v = transform.position - mag.transform.position;
                // 不是来的方向
                if (Vector2.Dot(v, comingDir) <= 0)
                {
                    // same
                    if (pole == mag.pole)
                    {
                        mag.Move(-v);
                    }
                }
            }
        }
    }

    public void Move(Vector2 _dir)
    {
        transform.position += (Vector3)_dir;
        CheckSurrounding(_dir);
    }

    void Start()
    {
        magnets = FindObjectsOfType<Magnet>();
    }

    private void OnValidate()
    {
        ChangePole(pole);
    }
}
