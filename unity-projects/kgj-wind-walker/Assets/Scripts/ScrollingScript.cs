using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class ScrollingScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);
    public bool isLinkedToCamera = false;
    public bool isLooping = false;
    private List<Transform> backgroundList;

    // 3 - Get all the children
    void Start()
    {
        if (isLooping)         // For infinite background only
        {
            RebuildList();
        }
    }

  

    private static Func<Transform, float> sorterOfBackgrounds()
    {
        return t => t.position.x;
    }

    void Update()
    {
        // Movement
        Vector3 movement = new Vector3(
          speed.x * direction.x,
          speed.y * direction.y,
          0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }

        if (isLooping) //for backgrounds
        {
            Transform firstChild = backgroundList.FirstOrDefault();
          
            if (firstChild != null)
            {
                // Check if the child is already (partly) before the camera.
                // We test the position first because the IsVisibleFrom
                // method is a bit heavier to execute.
                if (checkIfChildIsPartlyBeforeCamera(firstChild))
                {
                    // If the child is already on the left of the camera,
                    // we test if it's completely outside and needs to be
                    // recycled.
                    if (firstChild.GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
                    {
                        // Get the last child position.
                        Transform lastChild = backgroundList.LastOrDefault();
                        Vector3 lastPosition = lastChild.transform.position;
                        float lastSize = lastChild.GetComponent<Renderer>().bounds.size.x;
                            //(lastChild.GetComponent<Renderer>().bounds.max - lastChild.GetComponent<Renderer>().bounds.min);

                        // Set the position of the recyled one to be AFTER
                        // the last child.
                        // Note: Only work for horizontal scrolling currently.
                        firstChild.position = new Vector3(lastPosition.x + (-1 * direction.x * lastSize), firstChild.position.y, firstChild.position.z);

                        // Set the recycled child to the last position
                        // of the backgroundPart list.
                        backgroundList.Remove(firstChild);
                        backgroundList.Add(firstChild);
                    }
                }
            }
        }
    }

    private bool checkIfChildIsPartlyBeforeCamera(Transform firstChild)
    {
        var camX = Camera.main.transform.position.x;
        var posX = firstChild.position.x;
        return direction.x < 0 ? posX < camX : posX > camX;
    }

    private void RebuildList()
    {
        backgroundList = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            // Add only the visible children
            if (child.GetComponent<Renderer>() != null)
            {
                backgroundList.Add(child);
            }
        }

        // Sort by position.
        var backs = direction.x < 0 ? backgroundList.OrderBy(sorterOfBackgrounds())
            : backgroundList.OrderByDescending(sorterOfBackgrounds());
        backgroundList = backs.ToList();
    }
}
