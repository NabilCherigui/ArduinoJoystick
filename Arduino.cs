using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.IO.Ports;

public class Arduino : MonoBehaviour {
 SerialPort port;
 //com arduino that is being used
 public string COMPort;
 //The Numbers data
 string[] Numbers = new string[2];

 void Start () {
  //Sets up the serial port
  port = new SerialPort(COMPort, 9600);
  //This opens the port
  if (port.IsOpen)
  {
   port.Close();
   port.Open();
  }
  else
  {
   port.Open();
  }

 }

 void Update() {
  if (port.IsOpen)
  {
   //Puts data from arduino in a variable
   Numbers = port.ReadLine().Split(',');
  }

  //If the joystick moves to the left, it will print "left"
  if ((float)Int16.Parse(Numbers[1]) >= 600){
   print ("left");
  }
  //If the joystick moves to the right, it will print "right"
  if ((float)Int16.Parse(Numbers[1]) <= 400){
   print ("right");
  }
  //If you move the joystick down, it will print "down"
  if ((float)Int16.Parse(Numbers[0]) >= 600){
   print ("down");
  }
  //If you move the joystick up, it will print "up"
  if ((float)Int16.Parse(Numbers[0]) <= 400){
   print ("up");
  }


 }
}