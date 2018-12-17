using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { STUDENT, DOCENT };

public class Persoon
{
    private string naam;
    public Type typeUser;

    public string getNaam()
    {
        return this.naam;
    }

    public void setNaam(string naam)
    {
        this.naam = naam;
    }

    public Type getType()
    {
        return typeUser;
    }

    public void setType(Type type)
    {
        typeUser = type;
    }
}
