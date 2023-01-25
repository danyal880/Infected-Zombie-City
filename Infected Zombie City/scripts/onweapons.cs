using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onweapons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject  allweapons;
    void Start()
    {
       allweapons.transform.GetChild(weaponSelection.numb).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
