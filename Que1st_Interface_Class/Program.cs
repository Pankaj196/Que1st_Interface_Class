//importing namespace to use some predefine methods and properties
using System;
namespace Class_Interface_Example
{
    //Taken interface AnimalEat which have 1 method
    interface AnimalEat
    {
        public void Eat();//Pure abstract method declaration

    }

    //Taken interface AnimalSleep which have 1 method
    interface AnimalSleep
    {
        public void sleep();//Pure Abstract method declaration
    }
    
    class Bird : AnimalEat, AnimalSleep//Bird class extend 2 interface 
    {
        public void Eat()//Overridden method of AnimaEat Interface
        {
            Console.WriteLine("Bird Can Eat");
        }

        public void sleep()//Overridden method of AnimalSleep interface
        {
            Console.WriteLine("Bird can sleep");
        }
        public void Fly()//Class method
        {
            Console.WriteLine("Bird can Fly");
        }
    }
    class Final
    {
        public static void Main(String[] ar)
        {
            Bird b = new Bird();
            b.Eat();
            b.sleep();
            b.Fly();
        }
    }
}
/*Explaination:
 In c# multiple inheritace cant support to overcome this proble we use Interface
In above program I have taken 2 interface to show the funtionalities of Animal
In first interface AnimalEat i have declare one method because In Interface we can only declare methods we cant define it
mothod should define where the class implements that interface
In Second interface AnimalSleep i have declare one method Sleep() 
After that i have one class which is implementing both interfaces and that class showing fuctionality of Bird

 */
