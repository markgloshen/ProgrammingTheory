using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make an abstract class to indicate it is an incomplete implementation.
// Animal is only intended to be used as a base class of other classes and not
// instantiated on its own.
abstract public class Animal : MonoBehaviour // INHERITANCE
{
    // Fields that are serialized will appear in the Editor inspector component.
    [SerializeField] private string _name = "Animal";
    [SerializeField] private float _speed = 5f;
    [SerializeField] private bool _isEating = false;

    private Animator _animator;

    // Properties that are abstract MUST be implemented in child classes.
    // All animals must have a number of legs and there is no sane default.
    public abstract int NumLegs { get; protected set; } // ENCAPSULATION

    // Properties that are virtual MAY be overridden in child classes.
    // No reason to make Speed virtual here, this is just done for example.
    // One reason to optionally override Speed in children is if we
    // wanted different input validation routines for different child classes.
    public virtual float Speed
    {
        get => _speed;
        protected set => _speed = value;

        // Alternative syntax:
        // get { return _speed; }
        // protected set { _speed = value; }
    }

    // A public property without other modifiers is accessible by any other class.
    // The protected keyword restricts get or set to derived classes only.
    public string Name
    {
        get => _name;
        protected set => _name = value;
    }

    public bool IsEating
    {
        get => _isEating;
        protected set => _isEating = value;
    }

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    // ABSTRACTION
    public void StartEating()
    {
        _isEating = true;
        _animator.SetFloat("Speed_f", 0f);
        _animator.SetBool("Eat_b", true);
    }

    public void StopEating()
    {
        _isEating = false;
        _animator.SetFloat("Speed_f", _speed);
        _animator.SetBool("Eat_b", false);
    }
}
