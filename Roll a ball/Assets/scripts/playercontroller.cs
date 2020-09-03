using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private int count;
    public Text counttext;
    public Text wintext;

    void Start()
    {
        rb= GetComponent<Rigidbody>();
        count=0;
        setcounttext();
        wintext.text="";
    }


    void FixedUpdate()
    {
        float movehorizontal = Input.GetAxis("Horizontal");
        float movevertical = Input.GetAxis( "Vertical");
        Vector3 movement= new Vector3(movehorizontal,0.0f,movevertical);
        rb.AddForce(movement*speed);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("pick up"))
        {
            other.gameObject.SetActive (false);
            count=count+1;
            setcounttext();
        }
    }
    void setcounttext()
    {
        counttext.text=" Count: "+count.ToString();
        if(count==10)
        {
            wintext.text="Hurrayyy! You win";
        }
    }
}
