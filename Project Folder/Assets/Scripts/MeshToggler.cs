using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshToggler : MonoBehaviour
{
    public GameObject ModelObject;
    private bool isActive = true;

    public void Toggle()
    {
        if (isActive)
        {
            ModelObject.SetActive(false);
            isActive = false;   
        }
        else
        {
            ModelObject.SetActive(true);
            isActive = true;    
        }
    }

}
