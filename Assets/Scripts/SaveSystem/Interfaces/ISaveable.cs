using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ISaveable
{
    public void SaveAll(GameData data);
    public void LoadAll();
}
