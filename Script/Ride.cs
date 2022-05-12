using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ride : MonoBehaviour
{
    public bool isRide;
    GameObject Boat;
    Button button;

    void RideABoat()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        isRide = false;
        Boat = gameObject;
        button = gameObject.GetComponent<Button>();

        button.onClick.AddListener(RideABoat);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
