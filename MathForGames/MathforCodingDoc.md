

| Jeremy Flowers|
| :---          	|
| s208044    
| Math for Games |
| MathforCoding Documentation |


## I. Requirements

1. Description of Project

	- **Name**: MathforGames Assessment

	- **Project Instruction**:
	Create an application or a game program that demostrates the techinques of raylib in C# and a math library.

	- **Problem Specification**:
    An interactive application that highlights the usefulness of your maths
classes by performing transformations within a graphical Test Application. This graphical application
must make use of your math classes to transform and display items using a matrix hierarchy to correctly
display visual elements, such as icons on the screen or sprite characters.

2. Input Information
- Up Arrow Key - Allows the player to move upwards
- Down Arrow Key - Allows the player to move downwards
- Right Arrow Key - Allows the player to move towards the right
- Left Arrow Key - Allows the player to move towards the left
- Spacebar Key - Enables the player to shoot

### II. Object Information

   **File**: Actor.cs

     
  **Attributes**

         Name: _icon
             Description: Displays a chararcter that represents a GameObject.
             Type:char
        Name: _velocity
             Description: A variable that refers the math of the Vector2 class.
             Type:Vector2
        Name: _globalTransform
             Description: A variable that uses and references the math of the Matrix3 class to display movement on screen.
             Type:Matrix3
        Name: _localTransform
             Description: A variable that uses and references the math of the Matrix3 class to display movement on screen.
             Type:Matrix3
        Name: _translation
             Description: A variable that uses and references the of the Matrix3 class to calculate translation movement.
             Type:Matrix3
        Name: _rotation
             Description: A variable that uses and references the math of the Matrix3 class to calculate rotation movement.
             Type:Matrix3
        Name: _scale
             Description: A variable that uses and references the math of the Matrix3 class to calculate scaling movement.
             Type:Matrix3
        Name: _color
             Description: A variable that represents and displays the chosen color in the console window.
             Type:ConsoleColor
        Name: _rayColor
             Description: A variable that represents and displays the chosen color in the raylib window.
             Type:Raylib_cs
        Name: _parent
             Description: A variable that represents the parent object.
             Type:Actor
        Name: _children
             Description: An array of strings that represent the amount of children parented to a object.
             Type:float
        Name: AddChild(Actor child)
             Description: A function that allows you to add a child to an exsisting GameObject.
             Type:void
        Name: RemoveChild(Actor child)
             Description: A function that allows you to remove a chidl from an exsisting GameObject.
             Type:void
        Name: SetTranslate(Vector2 position)
             Description: A function that uses the Matrix3 and Vector2 classes to calculate the translation of the actor's position.
             Type:void
        Name: SetRotate(float radians)
             Description: A function that uses the Matrix3 class and radians to calculate the rotation of the actor.
             Type:void
        Name: SetScale(float x, float y)
             Description: A function that uses the Matrix3 class and the x and y coordinates to increase the size of the actor.
             Type:void
        Name: UpdateGobalTransform()
             Description: A function that updates the localTransform as well as the trasnform for the parent and child actors.
             Type:void
        Name: CheckCollision(Actor other)
             Description: A function that determines if an actor has collided with any GameObject, including another actor.
             Type:bool
        Name: OnCollision(Actor other)
             Description: A function that decides what happens on collision with the GameObjects.
             Type:virtual void
        Name: Actor(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Yellow)
             Description: The base constructor for the actor class.
             Type:constructor
        Name: Actor(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Yellow)
             Description: The overloaded constructor for the actor class.
             Type:constructor
        Name: Start()
             Description: A function that initializes things of the actor class
             Type:void
        Name: Update(float deltaTime)
             Description: A function that continues to loop until the application ends.
             Type:void
        Name: Draw()
             Description: A function that is used to draw GameObjects onto the window.
             Type:void
        Name: End()
             Description: A function used to end things called in the actor class.
             Type:void


   **File**: Enemy.cs


  **Atrributes**

        Name: _laser
             Description: A reference to the Laser class for Enemy.
             Type:Laser.cs
        Name: _sprite
             Description: A reference to the Sprite class for Enemy.
             Type:Sprite
        Name: 
             Description: 
             Type:
        Name: 
             Description: 
             Type:
        Name: 
             Description: 
             Type:
        Name: 
             Description: 
             Type:
