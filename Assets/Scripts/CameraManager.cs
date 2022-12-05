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

        //Vertical example using 0 to 1 units for width and height
        cameraOne.rect = new Rect(0, 0, 0.5f, 1);
        camerTwo.rect = new Rect(0.5f, 0, 0.5f, 1);

        //Horizontal example
        cameraOne.rect = new Rect(0, 0, Screen.width, Screen.height/2);
        camerTwo.rect = new Rect(0, 0.5f, Screen.width, Screen.height/2);

        //Horizontal example using 0 to 1 units for width and heigh
        cameraOne.rect = new Rect(0, 0, 1, 0.5f);
        camerTwo.rect = new Rect(0, 0.5f, 1, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
