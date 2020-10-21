using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]private LayerMask DestroyMask;
    private float TimeSpanw;
    private float TimeExplos = 2f;
    private float RadExpl = 0.5f;
    private GameObject Exp;

    IEnumerator ExposIE()
    {
        yield return new WaitForSeconds(1);
    }
    void Update()
    {
        TimeSpanw += Time.deltaTime;
        if (TimeSpanw > this.TimeExplos)
        {
            Exp = GameObject.Find("Exp");
            Exp.transform.DOScale(Vector3.one * 2f, 0.1f);
            StartCoroutine(ExposIE());
            var Coll = Physics.OverlapSphere(transform.position, RadExpl, DestroyMask);
            
            foreach (var cldr in Coll)
            {
                Destroy(cldr.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
