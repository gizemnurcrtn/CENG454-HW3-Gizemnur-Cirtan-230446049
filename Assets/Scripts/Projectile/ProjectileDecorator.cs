public abstract class ProjectileDecorator : IProjectile
{
    protected IProjectile wrappedProjectile;

    public ProjectileDecorator(IProjectile projectile)
    {
        wrappedProjectile = projectile;
    }

    public virtual int GetDamage()
    {
        return wrappedProjectile.GetDamage();
    }
}
