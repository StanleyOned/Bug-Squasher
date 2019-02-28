using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroObject : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
