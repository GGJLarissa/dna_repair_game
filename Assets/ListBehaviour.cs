using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ListBehaviour : MonoBehaviour
{
    public GameObject baseTemplate;

    private DnaSequenceGenerator _dnaSequenceGenerator;

    private float mistakeRate = 0.3f;

    public bool[] correct;

    public Sprite tx2d;

    public Sprite tx3d;

    private int _size = 100;

    public Dictionary<int, String[]> pairs;

    // Start is called before the first frame update
    void Start()
    {
        _dnaSequenceGenerator = new DnaSequenceGenerator();
        char[] bases = _dnaSequenceGenerator.GenerateSequence(_size);
        correct = new bool[_size];
        pairs = new Dictionary<int, String[]>();
        for( var i =0; i < bases.Length; i ++)
        {
            bool isWrong = Random.value <= mistakeRate;
	 		GameObject b = Instantiate(baseTemplate, new Vector2(i * 1.2f, this.transform.position.x), this.transform.rotation);
            b.name = bases[i].ToString() + i.ToString();
            b.GetComponentInChildren<BaseButoonAppearance>().label = bases[i].ToString();
            b.GetComponentInChildren<BaseButoonAppearance>().color = DnaSequenceGenerator.getBaseColor(bases[i]);
            b.GetComponentInChildren<BaseButoonAppearance>().id = i;
            b.GetComponentInChildren<SpriteRenderer>().sprite = (bases[i].Equals('A') || bases[i].Equals('T') ? tx2d : tx3d);
            b.transform.parent = this.gameObject.transform;

            char match = _dnaSequenceGenerator.BaseMatch(bases[i], isWrong);
            GameObject c = Instantiate(baseTemplate, new Vector2(i * 1.2f, this.transform.position.y - 2f), this.transform.rotation);
            c.name = match.ToString() + i.ToString();
            c.GetComponentInChildren<BaseButoonAppearance>().label = match.ToString();
            c.GetComponentInChildren<BaseButoonAppearance>().color = DnaSequenceGenerator.getBaseColor(match);
            c.GetComponentInChildren<BaseButoonAppearance>().id = i;
            c.GetComponentInChildren<SpriteRenderer>().sprite = (match.Equals('A') || match.Equals('T') ? tx2d : tx3d);
            c.GetComponentInChildren<SpriteRenderer>().flipY = true;
            c.GetComponentInChildren<SpriteRenderer>().gameObject.transform.Translate(0 , 0.5f, 0);
            
            c.transform.parent = this.gameObject.transform;

            correct[i] = isWrong;
            pairs[i] = new string[] {bases[i].ToString(), match.ToString()};
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        this.gameObject.transform.Translate(-1 * Time.deltaTime, 0, 0);
    }
    

    private void OnCollisionEnter(Collision other)
    {
        // contacts = new int[]{};
        foreach (ContactPoint cp in other.contacts)
        {
            Debug.DrawRay(cp.point, cp.normal, Color.white);
        }
       Vector3 contacts = other.GetContact(0).point;
       Debug.Log(contacts);
    }
}
