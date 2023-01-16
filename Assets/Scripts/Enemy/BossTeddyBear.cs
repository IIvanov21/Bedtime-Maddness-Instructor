using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeddyBear : Enemy
{
    //Boss values
    [SerializeField]
    Transform shootPosition;
    bool shoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.State == GameState.Play)
        {
            Chase();
            if (agent.stoppingDistance <= 3.0f) Fire();
        }
    }

    void Fire()
    {
        if (shoot) StartCoroutine(CreateBullet());
    }

    IEnumerator CreateBullet()
    {
        Instantiate(bullet, shootPosition.position, shootPosition.rotation);
        shoot = false;
        yield return new WaitForSeconds(2.0f);
        shoot = true;
    }
}
