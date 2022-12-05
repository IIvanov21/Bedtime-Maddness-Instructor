using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.State==GameState.Play)
        {
            GameManager.Instance.GetComponent<ScenesManager>().NextLevel();
        }
    }
}
