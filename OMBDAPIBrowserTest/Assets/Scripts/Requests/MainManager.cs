using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private Getter getter;
    private void Start()
    {
        getter = GetComponent<Getter>();
    }


    public void InputFieldHandler(string input)
    {
        if (input.Length >= 3)
        {
            getter.GetResponse(Statics.OMDBAPIURL + Statics.apiKeySeparator + Statics.apiKey + Statics.searchSeparator + input);
        }
    }
}
