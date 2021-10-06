using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMe : MonoBehaviour
{
    public float size = 0.35f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, size);

    }
}
