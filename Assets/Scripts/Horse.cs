using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : Animal // INHERITANCE
{
    private int _numLegs = 4;

    // Must override the abstract Properties from base class Animal.
    public override int NumLegs // POLYMORPHISM
    {
        get => _numLegs;
        protected set => _numLegs = value;
    }

    // Use protected setter from base class to set name and speed.
    private void Awake()
    {
        Name = "Horse";
        Speed = 10f;
    }
}
