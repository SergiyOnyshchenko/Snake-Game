using System;

public interface IDeath
{
    void Die();

    event Action IsDied;
}
