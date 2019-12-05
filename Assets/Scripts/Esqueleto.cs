using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esqueleto : Enemigo
{
    public float velocidad = 5;
    private Rigidbody2D rb;

    public Transform puntoA, puntoB;
    private float margenError = 0.2f;
    private bool irPuntoA = true;
    private Vector2 dir = Vector2.zero;
    private bool canMove = true;
    public float tiempoEspera = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        irPuntoA = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceA = Mathf.Abs(Vector2.Distance(transform.position, puntoA.position));
        if(irPuntoA &&  distanceA >= margenError)
        {
            dir = puntoA.position - transform.position;
        }
        else if(irPuntoA)
        {
            //estamos en el punto A
            StartCoroutine(WaitToChange(false));
        }

        float distanceB = Mathf.Abs(Vector2.Distance(transform.position, puntoB.position));
        if (!irPuntoA && distanceB >= margenError)
        {
            dir = puntoB.position - transform.position;
        }
        else if (!irPuntoA)
        {
            //estamos en el punto A
            StartCoroutine(WaitToChange(true));
        }

        if (canMove)
            Caminar(dir);
        else
            rb.velocity = Vector2.zero;
    }

    public void Caminar(Vector2 direccion)
    {
        rb.velocity = direccion.normalized * velocidad;
    }

    IEnumerator WaitToChange(bool value)
    {
        canMove = false;
        yield return new WaitForSeconds(tiempoEspera);
        irPuntoA = value;
        canMove = true;
    }
}
