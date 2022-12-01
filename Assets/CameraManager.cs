using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    Camera cameraOne,camerTwo;

    // Start is called before the first frame update
    void Start()
    {
        //Vertical example
        cameraOne.rect= new Rect(0,0,Screen.width/2,Screen.height);
        camerTwo.rect= new Rect(0.5f,0,Screen.width/2,Screen.height);

        //Horizontal example
        cameraOne.rect = new Rect(0, 0, Screen.width, Screen.height/2);
        camerTwo.rect = new Rect(0, 0.5f, Screen.width, Screen.height/2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
