using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    public Rigidbody rb;

    private float myG = 6.67f;

    public static List<Attraction> planetAttractions;

    void Attract(Attraction other)
    {
        Rigidbody rbOther = other.rb;

        Vector3 direction = rb.position - rbOther.position;

        float distance = direction.magnitude;

        float forceMagnitude = myG * (rb.mass * rbOther.mass) / Mathf.Pow(distance, 2);

        Vector3 force = direction.normalized * forceMagnitude;

        rbOther.AddForce(force);
    }//Attract

    private void OnEnable()
    {
        if (planetAttractions == null) 
        {
            planetAttractions = new List<Attraction>();
        }

        planetAttractions.Add(this);

    }//OnEnable

    void FixedUpdate()
    {
        foreach (var pAttraction in planetAttractions) 
        {
            if (pAttraction != this)
            {
                Attract(pAttraction);
            }
        }
    }//FixedUpdate

}//Attraction
