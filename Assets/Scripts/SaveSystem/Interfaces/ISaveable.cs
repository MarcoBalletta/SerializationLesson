using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ISaveable
{
    public ReturnedSaveableData SaveAll();
    public void LoadAll();
}

public struct ReturnedSaveableData
{
    public string fileName;
    public GameData data;
}
