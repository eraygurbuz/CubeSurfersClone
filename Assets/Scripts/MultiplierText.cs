using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierText : MonoBehaviour
{
    public int multiplier = 2;
    // Start is called before the first frame update
    void Start()
    {
        GameObject text = new GameObject();
        TextMesh t = text.AddComponent<TextMesh>();
        t.text = multiplier + "X";
        t.fontSize = 20;
        //t.transform.localEulerAngles += new Vector3(90, 0, 0);
        t.transform.localPosition = transform.position;
    }

}
