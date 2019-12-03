using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float daño = 0.5f;
    public float vida = 1;

    public void RestarVida(float dano)
    {
        vida = vida - dano;
        if (vida <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        //antes de morir, sumar puntos al personaje
        FindObjectOfType<Personaje>()?.EnemigoVencido();
        Destroy(gameObject);
    }
}
