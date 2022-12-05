using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTelephone : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource telephoneRing;
    CommandController commandData = null;

    // Update is called once per frame
    void Update()
    {
       /* var stats = commandData.Commands[0].Stats;
        if (stats != null) {
            if (stats.TelephoneFlag == 1)
            {
                telephoneRing.Play();
            }
        }*/
       
    }
}
