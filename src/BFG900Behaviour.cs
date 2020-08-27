// Decompiled with JetBrains decompiler
// Type: RocketLauncherBehaviour
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8801C201-2CA6-4942-BCCF-F7FF79E90238
// Assembly location: D:\SteamLibrary\steamapps\common\People Playground\People Playground_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BFG9000Behaviour : MonoBehaviour
{
  public float ScreenShakeIntensity = 0.5f;
  [SkipSerialisation]
  public GameObject Projectile;
  [SkipSerialisation]
  public AudioSource AudioSource;
  public Vector2 barrelPosition;
  public Vector2 barrelDirection;


  void Fire(){
    Object.Instantiate<GameObject>(this.Projectile, (Vector3) this.BarrelPosition, Quaternion.identity).transform.right = (Vector3) this.BarrelDirection;
  }
  public void Use()
  {
    this.AudioSource.PlayOneShot(this.AudioSource.clip);
    CameraShakeBehaviour.main.Shake(this.ScreenShakeIntensity, this.BarrelPosition, 1f);
    Invoke("Fire", 5.0f);
  }

  public Vector2 BarrelPosition
  {
    get
    {
      return (Vector2) this.transform.TransformPoint((Vector3) this.barrelPosition);
    }
  }

  public Vector2 BarrelDirection
  {
    get
    {
      return (Vector2) (this.transform.TransformDirection((Vector3) this.barrelDirection) * this.transform.localScale.x);
    }
  }

  private void OnDrawGizmos()
  {
    Gizmos.DrawRay((Vector3) this.BarrelPosition, (Vector3) this.BarrelDirection);
  }
}
