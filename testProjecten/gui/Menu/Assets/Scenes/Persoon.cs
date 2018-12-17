using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { STUDENT, DOCENT };

public class Persoon
{
    private string naam;
    public Type typeUser { get; set; }
}
