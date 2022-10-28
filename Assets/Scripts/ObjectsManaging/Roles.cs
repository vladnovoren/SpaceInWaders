using UnityEngine;

namespace ObjectsManaging
{
    public static class GameRoles
    {
        public enum Roles
        {
            Player,
            Enemy
        }
        
        public static bool AreEnemies(Roles fstRole, GameObject sndGameObject)
        {
            switch (fstRole)
            {
                case Roles.Player:
                    if (sndGameObject.GetComponent<EnemyShip>() != null)
                        return true;
                    break;
                case Roles.Enemy:
                    if (sndGameObject.GetComponent<PlayerShip>() != null)
                        return true;
                    break;
            }

            return false;
        }
    }
}