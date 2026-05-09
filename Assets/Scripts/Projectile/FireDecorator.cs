using UnityEngine;

public class FireDecorator : ProjectileDecorator
{
    public FireDecorator(IProjectile projectile) : base(projectile)
    {
    }

    public override int GetDamage()
    {
        return wrappedProjectile.GetDamage() + 5;
    }
}
