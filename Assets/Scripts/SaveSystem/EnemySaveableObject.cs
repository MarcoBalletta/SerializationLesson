using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class enemySaveableObject : SaveableObject<EnemyData>
{
    public int enemySaved = 0;

    public enemySaveableObject() : base()
    {

    }
}

