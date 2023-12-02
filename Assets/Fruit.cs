using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private string inthebasket = "y";
    // Start is called before the first frame update
    void Start()
    {
        
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
            basket.spawned = "n";
        }
    }

    
}
