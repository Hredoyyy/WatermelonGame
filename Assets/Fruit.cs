using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    
    private string inthebasket = "y";
    private string time = "n";
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.y <5){
            inthebasket = "n";
            GetComponent<Rigidbody2D>().gravityScale = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inthebasket == "y"){
        
        GetComponent<Transform>().position = basket.basketpos;  

        }

        if(Input.GetKeyDown("space")){

            GetComponent<Rigidbody2D>().gravityScale = 2;
            inthebasket = "n";
            // basket.spawned = "n";
            StartCoroutine(gameover());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.tag == gameObject.tag){

            basket.colpos = transform.position;
            basket.newfruit = "y";
            basket.whichfruit = int.Parse(gameObject.tag);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other){

        if ((other.gameObject.name == "gameover") && (time== "y")){
        
        Debug.Log("Game Over");

        }
    }

    IEnumerator gameover(){

        yield return new WaitForSeconds(0.75f);
        time="y";

    }
    

    
}
