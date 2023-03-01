using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadlightsController : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    public void TurnOn()
    {
        if(this.isActiveAndEnabled == false)
            this.gameObject.SetActive(true);
        else
            this.gameObject.SetActive(false);
    }
}
