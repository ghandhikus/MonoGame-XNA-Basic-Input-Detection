MonoGame and Xna Basic Input Detector
=========================

##What is it for and what does it do?
It detects Keyboard/GamePad states and launches coresponding events, like *Up/Down* && *Tick* && *Click/Hold* that are from *InputListener* class which you can see implementation of down below.

It is for *Keyboard/GamePad* only.

##Usage
* Instancinate *InputChecker*
* Create reaction for key/button using *InputListener* <sup>(see below)</sup>
* Add it to *InputChecker* using *.AddListener*(*InputListener*);
* Put *inputChecker*.*Update*(*GameTime*); into *Update*.

```C#
class Game
{
    [.............]

    InputChecker inputChecker;
    
    class Exit : InputListener { public override void Click(GameTime gameTime) { Game.Quit(); } }
    
    protected override void Initialize()
    {
        inputChecker = new InputChecker();
        Exit exitListener = new Exit();

        inputChecker.AddListener(Buttons.Back, exitListener);
        inputChecker.AddListener(Keys.Escape, exitListener);
        
        [.............]
    
    }
    
    [.............]
    
    protected void Update(GameTime gameTime)
    {
        inputListener.Update(gameTime);
        
    [.............]
}
```

###InputChecker class
* Detects State of Keyboard and all 4 Game Pads
* Launches Down, Up, Tick, Click and Hold events, for each Keys and Button enums
* Down and Up are launched everytime
* Click is launched if key/button is released in time of InputChecker.clickTime
* Hold is launched when is released after time of InputChecker.clickTime
* Tick is launched each time a button is pressed

###InputListener class
* Is Event holder class
```C#
class SomeKeyUsage : InputListener
{
    public override void Down(GameTime gameTime) { Console.WriteLine("Down has fired."); }

    public override void Up(GameTime gameTime) { Console.WriteLine("Up has fired."); }

    public override void Click(GameTime gameTime)
    {
        Console.WriteLine("Click has fired.");
        Meow.Nyaa ( );
    }

    public override void Hold(GameTime gameTime) { Console.WriteLine("Hold has fired."); }
    public override void Tick(GameTime gameTime) { Console.WriteLine("Tick has fired."); }
}
```


