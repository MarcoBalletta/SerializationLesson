using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public interface ISaveableComponent
{
    public void Save(GameData data);
    public void Load();
}
