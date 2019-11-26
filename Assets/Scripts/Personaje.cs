using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public float vida = 3;
    public UIManager ui;
    public int monedas = 0; 
    

    public void SumarVida(float vidaAdicional)
    {
        vida = vida + vidaAdicional; 
    }

    public void RestarVida(float dano)
    {
        vida = vida - dano;

        if(vida < 0.5f)
        {
            //Ya esta muerto
            ui.PrenderPantallaGameOver();
        }
    }
    
}
