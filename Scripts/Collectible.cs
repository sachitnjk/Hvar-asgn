using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    
    [SerializeField] int points;

    public void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.inst.AddScore(points);
            Destroy(this.gameObject);
        }
    }

}
