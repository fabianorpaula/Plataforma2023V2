using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{

    private Rigidbody2D Corpo;
    private Animator Animador;
    

    void Start()
    {
        Corpo = GetComponent<Rigidbody2D>();
        Animador = GetComponent<Animator>();
    }

    void Update()
    {
        Mover();
    }

    void Mover()
    {
        float velX = Input.GetAxis("Horizontal") * 4;
        float vely = Corpo.velocity.y;
        Corpo.velocity = new Vector2(velX, vely);

        if(velX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            Animador.SetBool("Correndo", true);
        }else if (velX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            Animador.SetBool("Correndo", true);
        }
        else
        {
            Animador.SetBool("Correndo", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Pular();
        }
    }

    void Pular()
    {
        Corpo.AddForce(Vector3.up * 500);
    }
}
