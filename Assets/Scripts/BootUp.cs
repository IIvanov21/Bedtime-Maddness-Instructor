using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BootUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
