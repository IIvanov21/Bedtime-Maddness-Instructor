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
        cameraOne.rect= new Rect(0,0,0.5f,1);
        camerTwo.rect= new Rect(0.5f,0,0.5f,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
