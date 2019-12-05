using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float daño = 0.5f;
    public float vida = 1;
    public bool ataqueCuerpo; //si puede hacer dano al tocar

    public void RestarVida(float dano)
    {
        vida = vida - dano;
        if (vida <= 0)
        {
            Morir();
        }
    }

    protected void Morir()
    {
        //antes de morir, sumar puntos al personaje
        FindObjectOfType<Personaje>()?.EnemigoVencido();
        Destroy(gameObject);
    }

    //Dano cuerpo - cuerpo
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(ataqueCuerpo)
        {
            //si choca con el jugador, restar vida al jugador
            if (collision.CompareTag(GameConstants.playerTag))
            {
                collision.gameObject.GetComponent<Personaje>().RestarVida(daño);
            }
        }
        
    }
}
