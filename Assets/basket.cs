using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class basket : MonoBehaviour
{
    public Transform[] fruitObj;
    static public string spawned = "n";
    static public Vector2 basketpos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        spawn();

        if (Input.GetKey("a")){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-5,0);            
        }
        if (Input.GetKey("d")){
            GetComponent<Rigidbody2D>().velocity = new Vector2(5,0);            
        }
        if (!Input.GetKey("a") && !Input.GetKey("d")){
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);            
        }

        basketpos = transform.position;
        
    }

    void spawn(){

        if (spawned == "n"){
            StartCoroutine(spawntimer());
            spawned = "y";
        }

    }

    IEnumerator spawntimer(){

        yield return new WaitForSeconds(.75f);
        Instantiate(fruitObj[UnityEngine.Random.Range(0,3)],transform.position, quaternion.identity);
        
        
    }
}
