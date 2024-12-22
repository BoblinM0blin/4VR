using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TestBehaviourScript : MonoBehaviour
{
    //public GameObject test;
    public int x = 0;
    public Text TXTField;
    private bool fl1 = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        x++;
        //Debug.Log(x);
        TXTField.text = x.ToString();
        switch(x)
        {
            case 100:
                //Destroy(test);
                //this.gameObject.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickBut()
    {
        switch(fl1)
        {
            case true:
                this.GetComponent<Renderer>().material.color = new Color32(128, 0, 215, 1);
                fl1 = false;
                break;
            
            case false:
                this.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 1);
                fl1 = true;
                break;
        }
        
    }
}
