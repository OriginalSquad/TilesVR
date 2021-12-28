using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour
{
    [SerializeField] private float _intensity = 1f;
    [SerializeField] private string _hexcode = "C4DCE5";
    
    // Start is called before the first frame update
    void Start()
    {
        string hashedHexcode = "#" + _hexcode;
        Color color;
        ColorUtility.TryParseHtmlString(hashedHexcode, out color);

        Light[] lights = GetComponentsInChildren<Light>();
        
        foreach (Light i in lights)
        {
            i.intensity = _intensity;
            i.color = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
