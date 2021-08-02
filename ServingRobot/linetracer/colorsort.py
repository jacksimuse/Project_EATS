import RPi.GPIO as GPIO
import sys
import time


pin = 18
mpin1 = 20
mpin2 = 21
mpin3 = 6
mpin4 = 12

GPIO.setmode(GPIO.BCM)
GPIO.setup(pin, GPIO.IN)
GPIO.setup(mpin1, GPIO.OUT)
GPIO.setup(mpin2, GPIO.OUT)
GPIO.setup(mpin3, GPIO.OUT)
GPIO.setup(mpin4, GPIO.OUT)

try:
    while True:
        if GPIO.input(pin) == True:
            #print("White")
            GPIO.output(mpin1, False)
            GPIO.output(mpin2, False)
            GPIO.output(mpin3, False)
            GPIO.output(mpin4, False)
            #time.sleep(0.3)
        elif GPIO.input(pin) == False:
            #print("Black")
            GPIO.output(mpin1, True)
            GPIO.output(mpin2, False)
            GPIO.output(mpin3, True)
            GPIO.output(mpin4, False)
            #time.sleep(0.3)

except KeyboardInterrupt:
    GPIO.cleanup()
    sys.exit()