﻿using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Properties + COmponent References
    #region
    [Header("Component References")]
    public Animator myAnim;
    public GameObject imageParent;
   
    [Header("Properties")]
    public Vector3 destination;
    public bool readyToMove;
    public bool destinationReached;
    public float travelSpeed;
    #endregion

    // Initialization 
    #region
    
    public void InitializeSetup(Vector3 startPos, Vector3 endPos, float speed)
    {
        transform.position = startPos;
        destination = endPos;
        travelSpeed = speed;
        FaceDestination();
        readyToMove = true;
    }
    #endregion

    // Movement logic
    #region
    private void Update()
    {
        if (readyToMove)
        {
            MoveTowardsTarget();
        }
    }   
    public void MoveTowardsTarget()
    {
        if(transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, travelSpeed * Time.deltaTime);
            if(transform.position == destination)
            {
                destinationReached = true;
                DestroySelf();
            }
        }
    }
    #endregion

    // Misc Logic
    #region
    public void FaceDestination()
    {
        Vector2 direction = destination - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10000f);
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    #endregion

}
