using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
   [SerializeField] private GameObject choppedTree;
   [SerializeField] private LayerMask playerLayer;
   [SerializeField] private float treeDurability;
   [SerializeField] private BoolBox interact;
   [SerializeField] private Collider thisColl;
   [SerializeField] private StatsObject stats;
   [SerializeField] private SliderValueHolder progress;
   private float treeChopProgress;
   private bool inRange;
   
   public void KillTree ()
   {
      Destroy(gameObject);
      inRange = false;
      interact.on = false;
      Instantiate(choppedTree,transform.position,transform.rotation);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (!Physics.CheckBox(thisColl.bounds.center, thisColl.bounds.extents, transform.rotation, playerLayer)) return;
      inRange = true;
      interact.on = true;
      // progress.progress = 0;
   }

   private void OnTriggerExit(Collider other)
   {
      if (Physics.CheckBox(thisColl.bounds.center, thisColl.bounds.extents+ new Vector3(0.5f,0.5f,0.5f), transform.rotation, playerLayer))
      {
         inRange = false;
         interact.on = false;
         // progress.progress = 0;
      }
   }

   private void Update()
   {
      if (treeChopProgress >= treeDurability)
      {
         KillTree();
      }
      
      if (!inRange) return;
      progress.sliderMaxValue = treeDurability;
      progress.progress = treeChopProgress;
      
      if (Input.GetKey(KeyCode.E))
      {
         treeChopProgress += stats.chopSpeed * Time.deltaTime;
      }
   }

   

}
