using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleToggle : MonoBehaviour
{
    public void particleShoot(GameObject particle)
    {
        GameObject particleVFX;
        particleVFX = Instantiate(particle);
    }
}
