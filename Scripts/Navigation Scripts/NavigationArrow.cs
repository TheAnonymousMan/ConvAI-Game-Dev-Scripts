using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationArrow : MonoBehaviour
{
    [SerializeField]
    private Transform harold;

    [SerializeField]
    private Transform player;

    private Vector3 displacementVector;

    // Update is called once per frame
    void Update()
    {
        displacementVector = harold.position - player.position;

        transform.rotation = Quaternion.Euler(90f,
            90f + Mathf.Atan2(displacementVector.x, displacementVector.z) * Mathf.Rad2Deg,
            0.0f);

        //transform.Rotate(new Vector3(0f,
        //    0f,
        //    Mathf.Atan(displacementVector.z / displacementVector.x) * Mathf.Rad2Deg - player.rotation.eulerAngles.y));
    }
}
