using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class basket : MonoBehaviour
{
    public Transform[] fruitObj;
    static public string spawned = "n";
    static public Vector2 basketpos;
    static public Vector2 colpos;
    static public string newfruit = "n";
    static public int whichfruit = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(fruitObj[UnityEngine.Random.Range(0,3)],transform.position, quaternion.identity);
        spawned = "y";
    }

    // Update is called once per frame
    void Update()
    {   
        spawn();
        replace();

        if (Input.GetKey("a")){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-5,0); 

            if (transform.position.x < -5.5){
                GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            }          
        }
        if (Input.GetKey("d")){
            GetComponent<Rigidbody2D>().velocity = new Vector2(5,0); 

            if (transform.position.x > 5.5){
                GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);  
            }         
        }
        if (!Input.GetKey("a") && !Input.GetKey("d")){
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);            
        }

        basketpos = transform.position;

        if (Input.GetKeyDown("space") && spawned == "y"){

            spawned = "n";
        }
        
    }

    void spawn(){

        if (spawned == "n"){
            StartCoroutine(spawntimer());
            spawned = "w";
        }

    }
    void replace(){

        if (newfruit == "y"){

            newfruit = "n";
            if (whichfruit > 7){
                whichfruit = 7;
            }
            Instantiate(fruitObj[whichfruit],colpos,quaternion.identity);
            
            
        }
    }
    IEnumerator spawntimer(){

        yield return new WaitForSeconds(.75f);
        Instantiate(fruitObj[UnityEngine.Random.Range(0,3)],transform.position, quaternion.identity);
        spawned = "y";
        
    }
}
