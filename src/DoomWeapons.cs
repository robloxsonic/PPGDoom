using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

/*

hello there! you can use this as a reference for making your own mods,
although I am also working on making tutorial which will go on my Twitter

*/

namespace DoomWeapons
{

    
    public class DoomWeapons
    {
        public static void Main()
        {
			
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Shotgun"),
                    NameOverride = "Doom Shotgun",
                    NameToOrderByOverride = "Doom Shotgun",
                    DescriptionOverride = "This is my boomstick",
                    CategoryOverride = ModAPI.FindCategory("Firearms"),
                    ThumbnailOverride = ModAPI.LoadSprite("ShotgunIcon.png", 5f),
                    AfterSpawn = (Instance) =>
                    {

                        var firearm = Instance.GetComponent<FirearmBehaviour>();

                        firearm.BulletsPerShot = 7;
                        firearm.ShotSounds = new AudioClip[]
                        {
                            ModAPI.LoadSound("DSSHOTGN.wav")
                            
                        };

                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("SHOTA0.png", 1.5f);

                        BoxCollider2D[] colliders = Instance.GetComponents<BoxCollider2D>();
                        for(int i = 0; i < colliders.Length; i++){
                            UnityEngine.GameObject.Destroy(colliders[i]);
                        }

                        var barrel = Instance.AddComponent<BoxCollider2D>();
                        barrel.offset = new Vector2(0.2967865f, 0.08143535f);
                        barrel.size = new Vector2(1.206427f, 0.1799865f);

                        var handle = Instance.AddComponent<BoxCollider2D>();
                        handle.offset = new Vector2(-0.6044311f, -0.03619349f);
                        handle.size = new Vector2(0.5911378f, 0.2921863f);

                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Shotgun"),
                    NameOverride = "Doom Super Shotgun",
                    NameToOrderByOverride = "Doom Super Shotgun",
                    DescriptionOverride = "This is my boomstick",
                    CategoryOverride = ModAPI.FindCategory("Firearms"),
                    ThumbnailOverride = ModAPI.LoadSprite("SuperShotgunIcon.png", 5f),
                    AfterSpawn = (Instance) =>
                    {

                        var firearm = Instance.GetComponent<FirearmBehaviour>();
                        firearm.InitialInaccuracy = 0.2f;
                        firearm.BulletsPerShot = 20;
                        firearm.ShotSounds = new AudioClip[]
                        {
                            ModAPI.LoadSound("SSG.wav")
                            
                        };
                        
                        BoxCollider2D[] colliders = Instance.GetComponents<BoxCollider2D>();
                        for(int i = 0; i < colliders.Length; i++){
                            UnityEngine.GameObject.Destroy(colliders[i]);
                        }

                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("SGN2A0.png", 1f);

                        var barrel = Instance.AddComponent<BoxCollider2D>();
                        barrel.offset = new Vector2(0.3513924f, 0.1270209f);
                        barrel.size = new Vector2(0.8375123f, 0.139269f);

                        var handle = Instance.AddComponent<BoxCollider2D>();
                        handle.offset = new Vector2(-0.5533118f, -0.02573015f);
                        handle.size = new Vector2(0.4336729f, 0.3489566f);

                        var middleHandle = Instance.AddComponent<BoxCollider2D>();
                        middleHandle.offset = new Vector2(-0.2005489f, 0.05699047f);
                        middleHandle.size = new Vector2(0.2645392f, 0.1792521f);

                    }
                }
            );

            
           
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Red Barrel"),
                    NameOverride = "Doom Explosive Barrel",
                    NameToOrderByOverride = "Doom Explosive Barrel",
                    DescriptionOverride = "haha barrel go boom",
                    CategoryOverride = ModAPI.FindCategory("Explosives"),
                    ThumbnailOverride = ModAPI.LoadSprite("BarrelIcon.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        /*todo: figure out explosion sounds*/
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("BAR1A0.png", 1f);
                        Instance.FixColliders();
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {

                    OriginalItem = ModAPI.FindSpawnable("Light Machine Gun"),
                    NameOverride = "Doom Chaingun",
                    NameToOrderByOverride = "Doom Chaingun",
                    DescriptionOverride = "makes the pistol useless",
                    CategoryOverride = ModAPI.FindCategory("Firearms"),
                    ThumbnailOverride = ModAPI.LoadSprite("ChaingunIcon.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        var firearm = Instance.GetComponent<FirearmBehaviour>();

                        firearm.ShotSounds = new AudioClip[]
                        {
                            ModAPI.LoadSound("DSPISTOL.wav")
                            
                        };
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("MGUNA0.png", 1f);
                        Instance.FixColliders();
                    }
                }
            );


            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Machine Blaster"),
                    NameOverride = "Doom Plasma Rifle",
                    NameToOrderByOverride = "Doom Plasma Rifle",
                    DescriptionOverride = "it's not a Plasma Gun it's a Plasma RIFLE",
                    CategoryOverride = ModAPI.FindCategory("Firearms"),
                    ThumbnailOverride = ModAPI.LoadSprite("PlasmaIcon.png", 5f),

                    AfterSpawn = (Instance) =>
                    {
                        /**/
                        
                        //get rid of yellow light thingys
                        
                        UnityEngine.Object.Destroy(Instance.transform.GetChild(0).gameObject);
                        UnityEngine.Object.Destroy(Instance.transform.GetChild(1).gameObject);
                        UnityEngine.Object.Destroy(Instance.transform.GetChild(2).gameObject);

                                       

                        var firearm = Instance.GetComponent<BlasterBehaviour>();
                        
                        var Bolt = firearm.Bolt;
                        Color c1 = new Color(0, 0, 1, 1);
                        Color c2 = new Color(0, 0, 1, 1);
                        
                        Bolt.GetComponent<BlasterboltBehaviour>().lineRenderer.SetColors(c1, c2);
                        

                        firearm.Clips = new AudioClip[]
                        {
                            ModAPI.LoadSound("DSPLASMA.wav")
                            
                        };
                        
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("PLASA0.png", 1f);
                        Instance.FixColliders();
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rocket Launcher"),
                    NameOverride = "Doom Rocket Launcher",
                    NameToOrderByOverride = "Doom Rocket Launcher",
                    DescriptionOverride = "makes badguys go boom",
                    CategoryOverride = ModAPI.FindCategory("Firearms"),
                    ThumbnailOverride = ModAPI.LoadSprite("RocketLauncherIcon.png", 5f),
                    AfterSpawn = (Instance) =>
                    {

                        var firearm = Instance.GetComponent<RocketLauncherBehaviour>();

                        //have to do this to prevent it from being replaced by BFG ball
                       // UnityEngine.GameObject.Destroy(Projectile.GetComponent<BFGProjectile>());
                       // Projectile.AddComponent<LaunchedRocketBehaviour>();

                        firearm.AudioSource.clip =  ModAPI.LoadSound("DSRLAUNC.wav");
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("LAUNA0.png", 1f);
                        Instance.FixColliders();
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rocket Launcher"),
                    NameOverride = "Doom BFG 9000",
                    NameToOrderByOverride = "Doom BFG 9000",
                    DescriptionOverride = "Big Fucking Gun 9000",
                    CategoryOverride = ModAPI.FindCategory("Firearms"),
                    ThumbnailOverride = ModAPI.LoadSprite("BFGIcon.png", 5f),
                    AfterSpawn = (Instance) =>
                    {

                       // UnityEngine.GameObject.Destroy(Instance.GetComponent<RocketLauncherBehaviour>());
                        //Instance.AddComponent<BFG9000Behaviour>();
                        var firearm = Instance.GetComponent<RocketLauncherBehaviour>();
                        

                        GameObject bfgball = UnityEngine.GameObject.Instantiate(firearm.Projectile); //Resources.Load("Assets/PrefabInstance/LaunchedRocket.prefab") as GameObject; //UnityEngine.GameObject.Instantiate(firearm.Projectile);
                        firearm.Projectile = bfgball;

                        bfgball.AddComponent<BFGProjectile>();

                        firearm.AudioSource.clip =  ModAPI.LoadSound("DSBFG.wav");
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("BFUGA0.png", 1f);
                        Instance.FixColliders();
                        UnityEngine.GameObject.Destroy(bfgball.GetComponent<LaunchedRocketBehaviour>());
                    }
                }
            );


          
            

           
        }
    }
}