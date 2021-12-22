using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    /// <summary>
    /// Длина уровня
    /// </summary>
    private float lengthLvlZ, lengthLvlX;

    [SerializeField] private Register register;
    [SerializeField] private GameObject ground;
    private int index;
    

    void Start()
    {
        var bounds = GetComponent<Collider>().bounds;
        lengthLvlZ = bounds.size.z;
        lengthLvlX = bounds.size.x*2;
        if(register)
        register.OnReg += GenerateActiveted;
    }

    public void GenerateActiveted()
    {
        index = Random.Range(0, 2);
        print(index.ToString());
        if (index == 0)
        {
            Vector3 placeGenertionZ = new Vector3(transform.position.x, 0, transform.position.z + lengthLvlZ-3);
            ground = Instantiate(ground, placeGenertionZ, Quaternion.identity);
            
        }
        if (index == 1)
        {
            Vector3 placeGenertionX = new Vector3(transform.position.x + lengthLvlX-4, 0, transform.position.z);
            ground = Instantiate(ground, placeGenertionX, Quaternion.identity);
           
        }
        index = Random.Range(0, 2);
    }
}
