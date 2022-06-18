using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private GameObject sword;
    private Dray dray;

    private void Start()
    {
        sword = transform.Find("Sword").gameObject;
        dray = transform.parent.GetComponent<Dray>();

        sword.SetActive(false);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90 * dray.facing);
        sword.SetActive(dray.mode == Dray.eMode.attack);
    }
}
