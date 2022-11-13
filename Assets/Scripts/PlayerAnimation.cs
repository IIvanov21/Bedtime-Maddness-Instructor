using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    Animator playerAnimator;

    float horizontalInput;
    float verticalInput;

    bool shooting = false;

    private void Awake()
    {
        playerAnimator = GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateAnimation(0.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        //Capture controls
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        MovingAnimation();

        if (Input.GetButtonDown("Fire1")) Shoot();
        else if (Input.GetButtonUp("Fire1")) Shoot();
    }

    void MovingAnimation()
    {
        //Update the locomotion animations
        UpdateAnimation(horizontalInput, verticalInput);
    }

    public void UpdateAnimation(float v, float h)
    {
        playerAnimator.SetFloat("vertical", v);
        playerAnimator.SetFloat("horizontal", h);
    }

    void Shoot()
    {
        shooting = !shooting;//Switch between true and false

        playerAnimator.SetBool("shooting", shooting);

    }
}
