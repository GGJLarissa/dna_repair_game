using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<TextMeshPro>().text += PlayerPrefs.GetInt("totalScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
