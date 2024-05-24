using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    /*
    public GameObject PlanetObject;
    public Vector3 RotationVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlanetObject.transform.Rotate(RotationVector * Time.deltaTime);
    }
    */
    [SerializeField] private GameObject targetObject;

    [SerializeField] private float expandDuration = 1.0f;
    private float currentTime = 0f;
    [SerializeField] private Vector3 breatheIn;
    [SerializeField] private Vector3 breatheOut;
    private bool breathingIn = true;

    [SerializeField] private bool pulsing = false;

    private void Awake()
    {
        if (!targetObject)
        {
            targetObject = this.gameObject;
        }
    }

    void Update()
    {
        PulseUpdate();
    }

    private void PulseUpdate()
    {
        if (pulsing)
        {
            Vector3 targetScale = breathingIn ? breatheIn : breatheOut;
            Vector3 startScale = breathingIn ? breatheOut : breatheIn;

            currentTime += Time.deltaTime;
            float lerpFactor = currentTime / expandDuration;

            targetObject.transform.localScale = Vector3.Lerp(startScale, targetScale, lerpFactor);

            if (lerpFactor >= 1.0f)
            {
                breathingIn = !breathingIn;
                currentTime = 0f;
            }
        }
    }
}
