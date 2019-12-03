using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bala : MonoBehaviour
{
    public float tiempoVida = 3.0f;
    public bool isPlayerBullet = false;
    private float damage = 0;
    float cooldown = 2.0f;
    bool canDamge = true;
    void Start()
    {
        Invoke("Destruir", tiempoVida);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(canDamge)
        {
            if (isPlayerBullet && other.CompareTag(GameConstants.enemyTag))
            {
                Debug.Log("Disparo a enemigo!!");
                other.GetComponent<Enemigo>().RestarVida(damage);
                canDamge = false;
                Destruir();
                
            }
            else if (!isPlayerBullet && other.CompareTag(GameConstants.playerTag))
            {
                Debug.Log("Disparo a jugador!!");
                other.GetComponent<Personaje>().RestarVida(damage);
                canDamge = false;
                Destruir();
            }
        }
        
    }

    public void Shoot(bool isPlayerBullet, Vector2 force, float damage)
    {
        this.isPlayerBullet = isPlayerBullet;
        this.damage = damage;
        GetComponent<Rigidbody2D>().AddForce(force);
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }
}
