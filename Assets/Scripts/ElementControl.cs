using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ElementControl : MonoBehaviour
{
    [SerializeField]
    private GameObject percentageText;

    [SerializeField]
    private Slider percentageSlider;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePercentage();
    }

    public void UpdatePercentage()
    {
        percentageText.GetComponent<TMPro.TextMeshProUGUI>().text = percentageSlider.value.ToString() + "%";
    }

}
