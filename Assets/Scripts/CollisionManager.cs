using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public static void ResponseCollision(GameObject colSubject, GameObject colObject)
    {
        (Bullet, Health) tBulletHealth = DoTypesMatch<Bullet, Health>(colSubject, colObject);
        if (tBulletHealth != default((Bullet, Health))) {
            ResponseCollision(tBulletHealth.Item1, tBulletHealth.Item2);
            return;
        }
    }

    public static void ResponseCollision<TColSubjectComp>(TColSubjectComp colSubjectComp, GameObject colObject)
    {
        Health health = colObject.GetComponent<Health>();
        if (health != null)
        {
            ResponseCollision(colSubjectComp, health);
        }
    }
    
    private static void ResponseCollision(Bullet bullet, Health health)
    {
        health.TakeDamage(bullet.CreatureDamage);
    }



    public static (T, U) DoTypesMatch<T, U>(GameObject gameObj1, GameObject gameObj2)
    {
        T comp1 = gameObj1.GetComponent<T>();
        if (comp1 == null)
            return default((T, U));
        U comp2 = gameObj2.GetComponent<U>();
        if (comp2 == null)
            return default((T, U));
        return (comp1, comp2);
    }
    
    public static void ResponseBullet(Bullet bullet, GameObject colObject)
    {
        if (!TryResponseBulletHealth(bullet, colObject))
        {
            // other checks
        }
        Destroy(bullet);
    }

    private static bool TryResponseBulletHealth(Bullet bullet, GameObject colObject)
    {
        Health health = colObject.GetComponent<Health>();
        if (health == null)
            return false;
        ResponseBulletHealthImpl(bullet, health);
        return true;
    }


    private static bool TryResponseBulletTrip(Bullet bullet, GameObject colObject)
    {
        Trip trip = colObject.GetComponent<Trip>();
        if (trip == null)
            return false;
        ResponseBulletTripImpl(bullet, trip);
        return true;
    }

    private static void ResponseBulletTripImpl(Bullet bullet, Trip trip)
    {
        trip.MulScale(bullet.TripDamage);
    }
}
