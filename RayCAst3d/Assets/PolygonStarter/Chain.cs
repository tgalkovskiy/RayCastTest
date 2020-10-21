using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
   [SerializeField] private float Radius = 5f;

   public void Badabum()
   {
      Destroy(this);
      var Colliders = Physics.OverlapSphere(transform.position, Radius);
      foreach (var cldr in Colliders)
      {
         if (cldr.attachedRigidbody == null)
         {
            continue;
         }

         var Dir = cldr.transform.position - transform.position;
         var Dist = Dir.magnitude;
         var K = Dist / Radius;
         cldr.attachedRigidbody.AddForce(K*40f*Dir.normalized, ForceMode.Impulse);
         
      }
   }
   
}
