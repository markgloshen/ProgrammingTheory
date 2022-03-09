using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal // INHERITANCE
{
    private int _numLegs = 4;

    // Must override the abstract Properties from base class Animal.
    public override int NumLegs // POLYMORPHISM
    {
        get => _numLegs;
        protected set => _numLegs = value;
    }

    // Use protected setter from base class to set name.
    // Speed will be left at default value inherited from base class.
    private void Awake()
    {
        Name = "Dog";
    }
}
