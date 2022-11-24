using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSelfDestruct : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1);
    }
}
