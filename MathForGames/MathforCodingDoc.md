

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
             Description: A reference to the Laser class for Enemy variable.
             Type:Laser.cs
        Name: _sprite
             Description: A reference to the Sprite class for Enemy sprite.
             Type:Sprite
        Name: _target
             Description: A reference to the Actor class for using a variable
             Type:Actor
        Name: Enemy(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Blue) : base(x, y, icon, color)
             Description: The base constructor of Enemy with the inheritance of the Actor class.
             Type:constructor
        Name: Enemy(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Blue) : base(x, y, icon, color)
             Description: The overloaded constructor for Enemy with the inheritance of the Actor class.
             Type:constructor
        Name: CheckTargetInSight(float maxAngle, float maxDistance)
             Description: A function that calculates if the the player is in range of the enemy's sights.
             Type:constructor
        Name: Update(float deltaTime)
             Description: The update function called for the Enemy class.
             Type:void
        Name: Draw()
             Description: The draw function called for the Enmey.
             Type:void


   **File**: Laser.cs


   **Attributes**:

        Name: _sprite
             Description: A reference to the Sprite class for Laser.
             Type:Sprite.cs
        Name: _speed
             Description: A variable used to calculate the speed of the Laser class. 
             Type:float
        Name: Laser(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Red) : base(x, y, icon, color)
             Description: The base constructor for Laser using the inheritance of Actor.
             Type:constructor
        Name: Laser(float x, float y Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Red) : base(x, y, icon, color)
             Description: The overloaded constructor for Laser using the inheritance of Actor.
             Type:constructor
        Name: Draw()
             Description: The draw fucntion called for Laser.
             Type:void


  **File**: Tank.cs


  **Attributes**:

        Name: _speed
             Description: A variable that holds a value of movement for the Tank class.
             Type:float
        Name: _sprite
             Description: A reference to the Sprite class for Tank.
             Type:Sprite.cs
        Name: OnCollision(Actor other)
             Description: A function that determines what happens when the GameObject collide with another GameObject.
             Type:void
        Name: Tank(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Cyan) : base(x, y, icon, color)
             Description: The base constructor for Tank using the inheritance of Actor.
             Type:constructor
        Name: Tank(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Cyan) : base(x, y, icon, color)
             Description: The overloaded constructor for Tank using the inheritance of Actor.
             Type:constructor
        Name: Update(float deltaTime)
             Description: The update function called for Tank.
             Type:void
        Name: Draw()
             Description: The draw function called for Tank.
             Type:void


   **File**: Turret


   **Attributes**:

        Name: _sprite
             Description: A reference to the Sprite class for Turret.
             Type:Sprite.cs
        Name: Turret(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Gray) : base(x, y, icon, color)
             Description: The base constructor for Turret using the inheritance of Actor.
             Type:constructor
        Name: Turret(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Gray) : base(x, y, icon, color)
             Description: The overloaded constructor for Turret using the inheritance of Actor.
             Type:constructor
        Name: Update(float deltaTime)
             Description: The update function called for Turret.
             Type:void
        Name: Draw()
             Description: The draw function called for Turret.
             Type:void


   **File**: Scene.cs


   **Attributes**:

        Name: _actors
             Description: A variable that holds the value of an array.
             Type:Actor[]
        Name: AddActor(Actor actor)
             Description: A function that adds GameObjects onto the screen.
             Type:void
        Name: RemoveActor(int index)
             Description: A function that removes GameObjects from the screen using an index.
             Type:void
        Name: RemoveActor(Actor actor)
             Description: A function that removes GameObjects from the screen using the Actor array.
             Type:void
        Name: CheckCollision(Actor other)
             Description: A function that checks to see if any actor has collied with anything.
             Type:void
        Name: Start()
             Description: The start function called for Scene.
             Type:void
        Name: Update(flaot detlaTime)
             Description: The update function called for Scene.
             Type:void
        Name: Draw()
             Description: The draw function called for Scene.
             Type:void
        Name: End()
             Description: The end function called for Scene.
             Type:void


  **File**: Game.cs


  **Attributes**:

        Name: _gameOver
             Description: A variable that defines if the application has ended or not.
             Type:bool
        Name: _scenes
             Description: A variable that holds a value for an array.
             Type:Scene[]
        Name: _currentSceneIndex
             Description: A variable that defines the current secene in an index.
             Type:int
        Name: CurrentSceneIndex
             Description: A function that gets and returns the _currentSceneIndex.
             Type:int
        Name: SetGameOver(bool value)
             Description: A function that turns _gameOver into a value.
             Type:void
        Name: GetScene(int index)
             Description: A function that returns the index of the _scenes array.
             Type:Scene
        Name: AddScene(Scene scene)
             Description: A function that adds a scene to the application using the _scene array.
             Type:int
        Name: RemoveScene(Scene scene)
             Description: A function that removes a scene from the application using the _scene array.
             Type:int
        Name: SetCurrentScene(int index)
             Description: A function that sets the current scene using an index.
             Type:void
        Name: GetKeyDown(int key)
             Description: A funtion that returns the output of a key is held down.
             Type:bool
        Name: GetKeyPressed
             Description: A function that returns the output of a key being pressed once.
             Type:bool
        Name: Start()
             Description: A function called when the application begins. Used for intialization
             Type:void
        Name: Update(float deltaTime)
             Description: A function called during the application's runtime. Constanly loops until application ends.
             Type:void
        Name: Draw()
             Description: A function called during the application's runtime. Drawing the GameObjects on the screen.
             Type:void
        Name: End()
             Description: A function called when the application ends.
             Type:void
        Name: Run()
             Description: A function that handles all of the main application logic including the main loop.
             Type:void


  **File**: Matrix3.cs


  **Attributes**:

        Name: m11, m12, m13, m21, m22, m23, m31, m32, m33
             Description: 
             Type:float
        Name: Matrix3()
             Description: The base constructor for the Matrix3 class.
             Type:constructor
        Name: Matrix3(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
             Description: The overloaded constructor for the Matrix3 class.
             Type:constructor
        Name: CreateRotation(float radians)
             Description: Creates a new matrix that has been rotated by the given value.
             Type:Matrix3
        Name: CreateTranslation(Vector2 position)
             Description: Creates a new matrix that has been translated by the given value.
             Type:Matrix3
        Name: CreateScale(Vector2 scale)
             Description: Creates a new matrix that has been scaled by the given value.
             Type:Matrix3
        Name: operator +(Matrix3 lhs, Matrix3 rhs)
             Description: Craetes a new matrix that has been added by both sides.
             Type:Matrix3
        Name: operator -(Matrix3 lhs, Matrix3 rhs)
             Description: Creates a new matrix that been subtracted by both sides.
             Type:Matrix3
        Name: operator *(Matrix3 lhs, Matrix3 rhs)
             Description: Creates a new matrix that has been multiplied by both sides.
             Type:Matrix3
        Name: operator *(Matrix3 lhs, Vector3 rhs)
             Description: Creates a new vector by multiplying Matrix3 with Vector3.
             Type:Vector3


   **File**: Matrix4.cs


   **Attributes**:

        Name: m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44 
             Description: 
             Type:float
        Name: Matrix4()
             Description: The base constructor for the Matrix4 class.
             Type:constructor
        Name: Matrix4(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44)
             Description: The overloaded constructor for the Matrix4 class.
             Type:constructor
        Name: CreateRotationX(float radians)
             Description: Creates a new matrix that is rotated by the given value on the X-axis.
             Type:Matrix4
        Name: CreateRotationY(float radians)
             Description: Creates a new matrix this is rotated by the given value on the Y-axis.
             Type:Matrix4
        Name: CreateRotationZ(float radians)
             Description: Craetes a new matrix that is rotated by the given value on the Z-axis. 
             Type:Matrix4
        Name: CreateTranslation(Vector2 position)
             Description: Creates a new matrix that has been translated by the given value.
             Type:Matrix4
        Name: CreateScale(Vector2 scale)
             Description: Creates a new matrix that has been scaled by the given value.
             Type:Matrix4
        Name: operator +(Matrix4 lhs, Matrix4 rhs)
             Description: Creates a new matrix that has been added by both sides.
             Type:Matrix4
        Name: operator -(Matrix4 lhs, Matrix4 rhs)
             Description: Creates a new matrix that has been subtracted by both sides.
             Type:Matrix4
        Name: operator *(Matrix4 lhs, Matrix4 rhs)
             Description: Creates a new matrix that has been multiplied by both sides.
             Type:Matrix4
        Name: operator *(Matrix4 lhs, Vector4 rhs)
             Description: Craetes a new vector that has been multiplied by Matrix4 and Vector4.
             Type:Vector4


   **File**: Vector2.cs


   **Attributes**:

        Name: _x
             Description: A variable that can hold a value.
             Type:float
        Name: _y
             Description: A variable that can hold a value
             Type:float
        Name: X
             Description: A function that returns the _x variable and gives it value.
             Type:float
        Name: Y
             Description: A function that returns the _y variable and gives it a value.
             Type:float
        Name: Magnitude
             Description: A function that calculates the magnitude of a GameObject.
             Type:float



   **File**: Vector3.cs


   **Attributes**:

        Name: 
             Description: 
             Type:


   **File**: Vector4.cs


   **Attributes**:

        Name: 
             Description: 
             Type: