using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToggle : MonoBehaviour
{
    //public GameObject human;

    public void humanDie(GameObject person)
    {
        person.GetComponent<Animator>().Play("Death");
    }
}
