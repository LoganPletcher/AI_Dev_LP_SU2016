using UnityEngine;
using System.Collections;

public class AIBehaviorScript : MonoBehaviour {

    public GameObject HealthP1; //A GameObject used to reference the first Health pickup.
    public GameObject HealthP2; //A GameObject used to reference the second Health pickup.
    public GameObject SpeedP1;  //A GameObject used to reference the first Speed pickup.
    public GameObject SpeedP2;  //A GameObject used to reference the second Speed pickup.
    public GameObject RocketP;  //A GameObject used to reference the Rocket pickup.

    public float CarSpeed = 1.0f;
    float BaseSpeed = 0.0f;
    public float Health = 100;

    float lowestDist = 0;   //A float to hold the lowest value distance between the tank this script is attached to and another object.
    Vector3 closestPiUP = new Vector3(0, 0, 0); //The position of the pickup closest to this tank.
    GameObject Destination; //A GameObject called Destination that is determined near the end of the Update function.
    GameObject chosenPiUP;  //A GameObject to reference the pickup that is chosen as the Destination in a non-direct manner for ease.
	
	// Update is called once per frame
	void Update () {
        if (((60 > Vector3.Distance(SpeedP1.transform.position, transform.position)) && (lowestDist > 40))/* && (Destination == null)*/)
        {
            lowestDist = Vector3.Distance(SpeedP1.transform.position, transform.position);
            closestPiUP = SpeedP1.gameObject.transform.position;
            chosenPiUP = SpeedP1;
        }
        if (((60 > Vector3.Distance(SpeedP2.transform.position, transform.position)) && (lowestDist > 40))/* && (Destination == null)*/)
        {
            lowestDist = Vector3.Distance(SpeedP2.transform.position, transform.position);
            closestPiUP = SpeedP2.gameObject.transform.position;
            chosenPiUP = SpeedP2;
        }
        if ((RocketP != null)/* && (Destination == null)*/)
        {
            closestPiUP = RocketP.transform.position;
            chosenPiUP = RocketP;
        }
        if ((Health <= 60)/* && (Destination == null)*/)
        {
            lowestDist = Vector3.Distance(HealthP1.transform.position, transform.position);
            closestPiUP = HealthP1.transform.position;
            chosenPiUP = HealthP1;
        }
        if (((Health <= 60) && (lowestDist > Vector3.Distance(HealthP2.transform.position, transform.position)))/* && (Destination == null)*/)
        {
            lowestDist = Vector3.Distance(HealthP2.transform.position, transform.position);
            closestPiUP = HealthP2.transform.position;
            chosenPiUP = HealthP2;
        }
        if (chosenPiUP != null)
        {
            Destination = chosenPiUP;
            chosenPiUP = null;
        }
        if (Destination != null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Destination.transform.position - transform.position), (CarSpeed * Time.deltaTime));
            transform.Translate(Vector3.forward * (CarSpeed * Time.deltaTime));
        }
    }
}
