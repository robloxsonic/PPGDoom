// Decompiled with JetBrains decompiler
// Type: LaunchedRocketBehaviour
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8801C201-2CA6-4942-BCCF-F7FF79E90238
// Assembly location: D:\SteamLibrary\steamapps\common\People Playground\People Playground_Data\Managed\Assembly-CSharp.dll
using System;
using UnityEngine;

public class BFGProjectile : MonoBehaviour
{
  public float UnitsPerSecond = 4f;
  public float AccelerationPerSecond = 0.5f;
  public float MaxSpeed = 80f;
  private float Seed;
  private LayerMask mask;
  private float f;
  private float PushAwayDistance = 200;

  //have to do this bullshit because I can't figure out Unity
  bool glitched = false;
  private void Awake()
  {
    this.Seed = 0;
    this.mask = (LayerMask) LayerMask.GetMask("Objects", "Bounds");
    
    if( Mathf.Approximately((float)this.gameObject.transform.position.x, (float)170.9647) ){
      glitched = true;
    }else{
      ModAPI.Notify("nice");
    }

  }

  


  private void Update()
  {

    if(!glitched){
      Vector3 vector3 = this.transform.right + 0.25f * new Vector3((float) ((double) Mathf.PerlinNoise(0.0f, 2f * Time.time + this.Seed) * 2.0 - 1.0), (float) ((double) Mathf.PerlinNoise(2f * Time.time - this.Seed, 5f) * 2.0 - 1.0), 0.0f);
      vector3.Normalize();
      float distance = Mathf.Min(this.MaxSpeed, this.UnitsPerSecond + this.AccelerationPerSecond * this.f) * Time.deltaTime;
      RaycastHit2D raycastHit2D = Physics2D.Raycast((Vector2) this.transform.position, (Vector2) vector3, distance, (int) this.mask);
      if ((bool) raycastHit2D)
      {
        Vector2 vector2 = raycastHit2D.point + raycastHit2D.normal * 0.05f;
        

        //prevents rpg from firing bfg balls
        UnityEngine.GameObject.Destroy(this.gameObject);


        //haha BOOM
        ExplosionCreator.CreatePulseExplosion((Vector3) vector2, 240f, 900f, true, true);

        raycastHit2D.transform.SendMessage("Shot", (object) new Shot(raycastHit2D.normal, raycastHit2D.point, 35f), SendMessageOptions.DontRequireReceiver);
        raycastHit2D.transform.SendMessage("ExitShot", (object) new Shot(raycastHit2D.normal, raycastHit2D.point, 35f), SendMessageOptions.DontRequireReceiver);
        raycastHit2D.transform.SendMessage("Break", (object) (distance * (Vector2) vector3), SendMessageOptions.DontRequireReceiver);

        


      }
      else
        this.transform.position += vector3 * distance;
      this.f += Time.deltaTime;
    }else{
      //don't ask, I don't know either, it just works and I'm too tired to question it
      this.transform.position = new Vector2(10000, 10000);
    }
    
  }
}
