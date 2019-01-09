using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { STUDENT, DOCENT, NIET_INGELOGD };

public class Persoon
{
    public static string naam;
    public static Type typeUser { get; set; }
}
