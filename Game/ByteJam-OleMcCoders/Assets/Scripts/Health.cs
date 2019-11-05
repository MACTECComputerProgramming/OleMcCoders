using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public Slider healthbar;
    public static int health;
    public int loss;

    void Start()
    {
        health = 100;    
    }


    void Update()
    {
        healthbar.value = health;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy") {
            if (health > 0)
            {
                health -= loss;

            }
            if (health <= 0)
            {

                //Game Over Here

            }
           
            Destroy(other.gameObject);
        }
    }

    

    
}
