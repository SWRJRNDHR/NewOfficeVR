using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CommandController
{
    public List<Commands> Commands;
}

[Serializable]
public class Stats
{
    public int Volume;
    public int TelephoneFlag;
    public int SwatterFlag;
}

[Serializable]
public class Commands
{
    public string Name;
    public Stats Stats;
}
