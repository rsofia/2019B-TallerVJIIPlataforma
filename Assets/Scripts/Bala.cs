using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float tiempoVida = 3.0f;
    void Start()
    {
        Invoke("Destruir", tiempoVida);
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }
}
