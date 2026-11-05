using System;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class fragment : MonoBehaviour
{
    public Boolean isExplosion;
    float lifetime = 2;

    // Update is called once per frame
    void Update()
    {
        if (!isExplosion) return;

        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
