using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espantapajaros : Enemigo
{
    //TODOS
    public float velocidad = 5;
    private Rigidbody2D rb;

    //zombie
    public Vector2 direccion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //para no arrastar
    }

    // Update is called once per frame
    void Update()
    {
        Caminar(direccion);
    }

    //Movimiento Zombie
    public void Caminar(Vector2 direccion)
    {
        rb.velocity = direccion.normalized * velocidad;
    }

}
