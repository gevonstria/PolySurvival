using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    public bool isFiring = false;
    public ParticleSystem muzzleFlash;
    public ParticleSystem hitEffect;
    public TrailRenderer tracerEffect;
    public Transform rayCastOrigin;
    public Transform rayCastDestination;

    Ray ray;
    RaycastHit hitInfo;
    public void StartFiring(){
        isFiring = true;
        muzzleFlash.Emit(1);

        ray.origin = rayCastOrigin.position;
        ray.direction = rayCastDestination.position - rayCastOrigin.position;

        var tracer = Instantiate(tracerEffect, ray.origin, Quaternion.identity);
        tracer.AddPosition(ray.origin);

        if(Physics.Raycast(ray, out hitInfo)){
            hitEffect.transform.position = hitInfo.point;
            hitEffect.transform.forward = hitInfo.normal;
            hitEffect.Emit(1);

            tracer.transform.position = hitInfo.point;
        }
    }

    public void StopFiring(){
        isFiring = false;
    }
}
