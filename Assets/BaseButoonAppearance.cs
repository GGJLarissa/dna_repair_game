using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseButoonAppearance : MonoBehaviour
{
	public string label;

    public Color color;

    public int id;
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponentInChildren<TextMeshPro>().text = this.label;
        this.gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(this.color.r,this.color.g,this.color.b);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
    }

    private void OnMouseDown()
    {
        char newLabel = DnaSequenceGenerator.GetNextBase(this.label[0]);
        this.gameObject.GetComponentInChildren<TextMeshPro>().text = newLabel.ToString();
        label = newLabel.ToString();

        this.gameObject.GetComponentInChildren<SpriteRenderer>().color = DnaSequenceGenerator.getBaseColor(newLabel);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
