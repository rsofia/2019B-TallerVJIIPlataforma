using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public float vida = 3;
    private float maxVida = 3.0f;
    public UIManager ui;
    public int monedas = 0;

    [Header("Player controller")]
    public Rigidbody2D rb;
    public Animator anim;
    public Transform feet;
    public SpriteRenderer charSprite;
    public float speed = 5.0f;
    public float jumpForce = 500f;
    private bool grounded = true;

    [Header("Disparos")]
    public GameObject prefabBala;
    public Transform puntaArma;
    

    public void SumarVida(float vidaAdicional)
    {
        vida = vida + vidaAdicional;
        if (vida > maxVida)
            vida = maxVida;
        ui.RefrescarVida();
    }

    public void RestarVida(float dano)
    {
        vida = vida - dano;
        ui.RefrescarVida();
        if (vida < 0.5f)
        {
            //Ya esta muerto
            ui.PrenderPantallaGameOver();
        }
    }

    private void SumarMoneda()
    {
        monedas++;
        if(monedas == 100)
        {
            //100 monedas hacen 1 vida
            SumarVida(1);
            monedas = monedas - 100;
        }
        ui.RefrescarMoneda(monedas);
    }

    /// <summary>
    /// Se manda a llamar automaticamente al entrar en una colision con Trigger
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Recoger moneda
        if(collision.CompareTag("Moneda"))
        {
            SumarMoneda(); //sumar puntaje moneda
            collision.gameObject.SetActive(false); //apagar moneda
        }
        else if(collision.CompareTag("Enemigo"))
        {
            RestarVida(0.5f);
        }
    }

    private void Update()
    {
        Inputs();
    }

    private void Inputs()
    {
        //Recibir inputs para movimiento
        float inputX = Mathf.Round(Input.GetAxisRaw("Horizontal"));
        float inputY = 0;
        //Saltar
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics2D.Raycast(feet.position, -feet.up, 1.0f) && grounded)
            {
                StartCoroutine(JumpCooldown());
                rb.AddForce(new Vector2(0, jumpForce));
            }
        }
        //Disparar con mouse izq
        if(Input.GetMouseButtonDown(0))
        {
            Disparar();
        }
        //Reproducir su animacion
        bool isWalking = (Mathf.Abs(inputX) + Mathf.Abs(inputY)) > 0;
        anim.SetBool("Walk", isWalking);
        //acomodar al sprite en la direccion correcta
        if (inputX < 0)
            charSprite.flipX = true;
        else
            charSprite.flipX = false;

        //mover usando su rigidbody
        Vector2 inputDir = new Vector2(inputX, inputY);
        rb.velocity = inputDir.normalized * speed;
    }

    IEnumerator JumpCooldown()
    {
        grounded = false;
        yield return new WaitForSeconds(1.0f);
        grounded = true;
    }

    public void Disparar()
    {
        GameObject bala = Instantiate(prefabBala);
        bala.transform.position = puntaArma.position;
        bala.GetComponent<Rigidbody2D>().AddForce(new Vector2(150, 0));
        //todo mejorar rango
        //todo elimar balas
    }


}
