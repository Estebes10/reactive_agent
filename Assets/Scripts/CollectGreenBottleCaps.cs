using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGreenBottleCaps : MonoBehaviour {

    void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "Player")
        {
            Destroy(gameObject);
            collision.GetComponent<PlayerScript>().totalPoints = collision.GetComponent<PlayerScript>().totalPoints + 15;
            collision.GetComponent<PlayerScript>().greenPoints = collision.GetComponent<PlayerScript>().greenPoints + 1;
        }
        else if (collision.gameObject.tag.Equals("enemy")){
            Destroy(gameObject);
        }
    }
}
