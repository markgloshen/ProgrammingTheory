using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GameObject.Find("Text").GetComponent<Text>();
        ResetScene();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetClickedText(); // ABSTRACTION
        }
    }
    private void SetDefaultText()
    {
        _text.text = "OOP Theory\n\nCode illustrating Abstraction, " +
            "Inheritance, Polymorphism, and Encapsulation.\n\n" +
            "Click on an animal for details.";
    }

    // Find all animals and initialize state
    // Reset text to default
    private void ResetScene()
    {
        Animal[] _animals;
        _animals = FindObjectsOfType<Animal>();

        foreach (Animal _animal in _animals)
        {
            Animator _animator = _animal.GetComponent<Animator>();
            _animal.StopEating(_animator);
        }

        SetDefaultText();
    }

    // ABSTRACTION
    private void SetClickedText()
    {
        {
            // First reset the scene
            ResetScene();

            // Find GameObject the user clicked on by using a Raycast
            // Get variables from parent class of the object the user clicked
            // Update text with appropriate values
            // Make the clicked animal start eating or all animals stop eating

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;        

            if (Physics.Raycast(ray, out hit))
            {
                GameObject _target = hit.collider.gameObject;
                Animator _animator = _target.GetComponent<Animator>();
                string _name = _target.GetComponentInParent<Animal>().Name;
                float _speed = _target.GetComponentInParent<Animal>().Speed;
                int _numLegs = _target.GetComponentInParent<Animal>().NumLegs;

                _text.text = $"Hello, I am a {_name}.\n\n" +
                    $"My speed is {_speed}. I have {_numLegs} legs.\n\n" +
                    "I will eat while you read this, until you click elsewhere.";

                _target.GetComponentInParent<Animal>().StartEating(_animator);

            }
            else
            {
                // User clicked empty space, reset scene
                ResetScene();
            }
        }
    }
}