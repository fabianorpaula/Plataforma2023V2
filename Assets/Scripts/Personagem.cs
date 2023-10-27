using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{

    private Rigidbody2D Corpo;
    private Animator Animador;
    public int qtd_pulos = 2;
    public float velExtra = 0;
    

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
        float velX = Input.GetAxis("Horizontal") * (4+velExtra);
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

        if (Input.GetKey(KeyCode.A))
        {
            velExtra += 0.01f;
        }
        else
        {
            velExtra = 0;
        }
    }

    void Pular()
    {
        if(qtd_pulos > 0)
        {
            qtd_pulos--;
            Corpo.AddForce(Vector3.up * 350);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D tocou)
    {
        

        if(tocou.gameObject.tag == "Solo")
        {
            qtd_pulos = 2;
        }
    }
}
