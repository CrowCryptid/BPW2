using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroomActivate : MonoBehaviour
{
    public Renderer target;
    public bool Mushroom1 = false;
    public bool Mushroom2 = false;
    public bool Mushroom3 = false;
    bool eDown;
    bool alreadyPlayed = false;
    public GameObject Interact;
    public GameObject CannotInteract;
    public GameObject PlayerCam;
    public GameObject CutSceneCam;
    public GameObject restartbutton;
    public GameObject GOD;
    public ParticleSystem GODTrail;
    public GameObject sigil;
    public GameObject Beams;

    /*
    public Light Light;
    public AudioSource LampOn;
    public AudioSource ding;
    
    
    //public lampjes lampjestart;
    //public restartscreen RestartScreen;
    public GameObject PressE;
    public GameObject NoPressE;
    public Light Crystal1;
    public Light Crystal2;
    public Light Crystal3;
    public GameObject WindParticles;
    */


    public void Start()
    {
        GameObject target = GameObject.Find("target");
        GODTrail.GetComponent<ParticleSystem>().Stop();
    }

    public void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            eDown = true;
        }
        if (Input.GetKeyUp("e"))
        {
            eDown = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Mushroom1 == true && Mushroom2 == true && Mushroom3 == true)
        {
            //Debug.Log("you did it");
            //target.transform.GetComponent<Renderer>().material.Emission = true;
            if (eDown == true)
            {
                if (!alreadyPlayed)
                {
                    StartCoroutine(RestartCoroutine());
                    alreadyPlayed = true;
                    PlayerCam.SetActive(false);
                    CutSceneCam.SetActive(true);
                    GOD.SetActive(true);
                    Interact.SetActive(false);
                    GODTrail.GetComponent<ParticleSystem>().Play();
                    sigil.SetActive(true);
                    Beams.SetActive(true);
                    Debug.Log("yippie");
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("fuk");
        if (!alreadyPlayed && Mushroom1 == true && Mushroom2 == true && Mushroom3 == true)
        {
            Interact.SetActive(true);
        }
        else
        {
            CannotInteract.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("object left");
        Interact.SetActive(false);
        CannotInteract.SetActive(false);
    }

    public IEnumerator RestartCoroutine()
    {
        Debug.Log("Started at:" + Time.time);

        yield return new WaitForSeconds(15);
        restartbutton.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
