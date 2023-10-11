public interface IDamageable{
    public float MaxHealth { get;}
    public float Health { get; }
    public void TakeDamage(float value);
    public void TakeHeal(float value);
}
