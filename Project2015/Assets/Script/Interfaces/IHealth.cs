using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IHealth
{
    int getHealth();
    void TakeDamage(int damageAmount);
    //void TakeDamage(Bullet bullet);
    //void TakeDamage(Explosion explosion);
}