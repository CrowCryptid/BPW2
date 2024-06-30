using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockactivecheck : MonoBehaviour
{
    
    public Renderer target;
    public Light Light;
    public bool Rock1 = false;
    public bool Rock2 = false;
    public bool Rock3 = false;
    bool eDown;
    public AudioSource LampOn;
    public AudioSource ding;
    bool alreadyplayed = false;
    bool alreadyplayed1 = false;
    bool TimerDone = false;
    public GameObject CutSceneCam;
    public GameObject PlayerCam;
    //public lampjes lampjestart;
    //public restartscreen RestartScreen;
    public GameObject PressE;
    public GameObject NoPressE;
    public Light Crystal1;
    public Light Crystal2;
    public Light Crystal3;
    public GameObject WindParticles;

    // Start is called before the first frame update
    void Start()
    {
        GameObject target = GameObject.Find("target");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e")) {
            eDown = true;
        }
        if (Input.GetKeyUp("e")) {
            eDown = false;
        }
        if (TimerDone == true)
        {
            if (!alreadyplayed1)
            {
                alreadyplayed1 = true;
                Light.enabled = true;
                LampOn.PlayOneShot(LampOn.clip);
            }
        }
        if (Rock1 == true)
        {
            Crystal1.enabled = true;
        }
        if (Rock2 == true)
        {
            Crystal2.enabled = true;
        }
        if (Rock3 == true)
        {
            Crystal3.enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!alreadyplayed && Rock1 == true && Rock2 == true && Rock3 == true)
        {
            PressE.SetActive(true);
        } else
        {
            NoPressE.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (Rock1 == true && Rock2 == true && Rock3 == true)
        {
            //Debug.Log("you did it");
            //target.transform.GetComponent<Renderer>().material.Emission = true;
            if (eDown == true)
            {
                if (!alreadyplayed)
                {
                    alreadyplayed = true;
                    StartCoroutine(TestCoroutine());
                    ding.PlayOneShot(ding.clip);
                    WindParticles.SetActive(true);
                    PlayerCam.SetActive(false);
                    PressE.SetActive(false);
                    CutSceneCam.SetActive(true);

                    //lampjestart.LampjeStart = true;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("object exit");
        PressE.SetActive(false);
        NoPressE.SetActive(false);
    }

public IEnumerator TestCoroutine()
    {
        Debug.Log("Started at:" + Time.time);

        yield return new WaitForSeconds(3);

        TimerDone = true;
        Debug.Log("Finished at:" + Time.time + "timer done:" + TimerDone);

        yield return new WaitForSeconds(9);

        //RestartScreen.RestartScreen = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
