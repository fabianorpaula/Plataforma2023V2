using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int hp = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D tocar)
    {
        if(tocar.gameObject.tag == "Atk")
        {
            Morrer();
        }
    }

    public void Morrer()
    {
        Destroy(this.gameObject);
    }
}
