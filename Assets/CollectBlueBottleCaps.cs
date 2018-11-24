using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBlueBottleCaps : MonoBehaviour {

    void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "Player")
        {
            Destroy(gameObject);
            collision.GetComponent<PlayerScript>().totalPoints = collision.GetComponent<PlayerScript>().totalPoints + 30;
            collision.GetComponent<PlayerScript>().bluePoints = collision.GetComponent<PlayerScript>().bluePoints + 1;
        }else if(collision.gameObject.tag.Equals("enemy")){
            Destroy(gameObject);
        }
    }
}
