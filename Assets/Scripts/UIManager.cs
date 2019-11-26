using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //nos permite acceder a variables de UI


public class UIManager : MonoBehaviour
{
    //Mostrar vida de personaje - 

    //Mostrar powerup activo

    //Menu inicio, prob. aparte

    //pantalla game over -

    //INTRO SCRIPT: VARIABLES, FUNCIONES, OBJETO
    public GameObject pantallaGameOver;

    public Image[] vidas;
    public Sprite vidaLlena;
    public Sprite vidaMitad;
    public Sprite vidaVacia;
    public Personaje personaje;

    [Header("Monedas")]
    public Text txtMoneda;

    //-- funciones de monobehaviour
    private void Start()
    {
        //apagar desde un inicio la pantalla de gameover
        ApagarPantallaGO(); 
    }

    //---Funciones propias

    //Funcion == accion
    public void PrenderPantallaGameOver()
    {
        pantallaGameOver.SetActive(true);
    }

    public void ApagarPantallaGO()
    {
        pantallaGameOver.SetActive(false);
    }
   
    public void RefrescarVida()
    {
        if(personaje.vida >= 3)
        {
            //Llenar todas las vidas
            vidas[0].sprite = vidaLlena;
            vidas[1].sprite = vidaLlena;
            vidas[2].sprite = vidaLlena;
        }
        else if(personaje.vida >= 2.5f)
        {
            vidas[0].sprite = vidaLlena;
            vidas[1].sprite = vidaLlena;
            vidas[2].sprite = vidaMitad;
        }
        else if(personaje.vida >= 2.0f)
        {
            vidas[0].sprite = vidaLlena;
            vidas[1].sprite = vidaLlena;
            vidas[2].sprite = vidaVacia;
        }
        else if(personaje.vida >= 1.5f)
        {
            vidas[0].sprite = vidaLlena;
            vidas[1].sprite = vidaMitad;
            vidas[2].sprite = vidaVacia;
        }
        else if(personaje.vida >= 1.0f)
        {
            vidas[0].sprite = vidaLlena;
            vidas[1].sprite = vidaVacia;
            vidas[2].sprite = vidaVacia;
        }
        else if(personaje.vida >= 0.5f)
        {
            vidas[0].sprite = vidaMitad;
            vidas[1].sprite = vidaVacia;
            vidas[2].sprite = vidaVacia;
        }
        else
        {
            vidas[0].sprite = vidaVacia;
            vidas[1].sprite = vidaVacia;
            vidas[2].sprite = vidaVacia;

        }


    }

    public void RefrescarMoneda(int numMonedas)
    {
        txtMoneda.text = "$" + numMonedas;
    }

}
