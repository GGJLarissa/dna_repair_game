using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseButoonAppearance : MonoBehaviour
{
	public string label;

    public Color color;

    

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponentInChildren<TextMeshPro>().text = this.label;
        this.gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(this.color.r,this.color.g,this.color.b);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
