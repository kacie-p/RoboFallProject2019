using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Team_Ravioli
{
    public class Program
    {
        public static void Main()
        {
            /* simple counter to print and watch using the debugger */
            //int counter = 0;

            // Controller Object
            CTRE.Phoenix.Controller.GameController myGamepad = new CTRE.Phoenix.Controller.GameController(new CTRE.Phoenix.UsbHostDevice(0));

            // Talon Object
            CTRE.Phoenix.MotorControl.CAN.TalonSRX myTalon = new CTRE.Phoenix.MotorControl.CAN.TalonSRX(55);


            /* loop forever */
            while (true)
            {
                if (myGamepad.GetConnectionStatus() == CTRE.Phoenix.UsbDeviceConnection.Connected)
                {
                    Debug.Print("Axis 0:" + myGamepad.GetAxis(0));
                    Debug.Print("Axis 1:" + myGamepad.GetAxis(1));
                    Debug.Print("Axis 2:" + myGamepad.GetAxis(2));
                    Debug.Print("Axis 5:" + myGamepad.GetAxis(5));

                    // pass axis value to talon
                    myTalon.Set(CTRE.Phoenix.MotorControl.ControlMode.PercentOutput, myGamepad.GetAxis(1));

                    CTRE.Phoenix.Watchdog.Feed();
                }


                /* print the three analog inputs as three columns */
                //Debug.Print("Counter Value: " + counter);

                /* increment counter */
                //++counter; /* try to land a breakpoint here and hover over 'counter' to see it's current value.  Or add it to the Watch Tab */

             
                /* wait a bit */
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
