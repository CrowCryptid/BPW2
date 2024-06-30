using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MushGlow2 : MonoBehaviour
{
    public Renderer target;
    bool eDown;
    public mushroomActivate MushroomActivate;
    bool alreadyPlayed = false;
    public GameObject Interact;
    public GameObject MushLight;
    public ParticleSystem Spore;
    public AudioSource ShroomChime;
    public GameObject Sigil;
    // Start is called before the first frame update
    void Start()
    {
        Spore.GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
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
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("fuk");
        if (!alreadyPlayed)
        {
            Interact.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (eDown == true)
        {
            MushroomActivate.Mushroom1 = true;
            eDown = false;
            MushLight.SetActive(true);
            Spore.GetComponent<ParticleSystem>().Play();
            ShroomChime.PlayOneShot(ShroomChime.clip);
            Sigil.SetActive(true);
            Debug.Log("object Activated");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("object left");
        Interact.SetActive(false);
    }
}
