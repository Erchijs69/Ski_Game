using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
   public delegate void OnHit();
   public static event OnHit onHitEvent;

   public static void CallOnHitEvent()
   {
    if(onHitEvent != null)
    onHitEvent();
   }
}
