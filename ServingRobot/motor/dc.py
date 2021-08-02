import RPi.GPIO as GPIO
import sys
import time


pin1 = 20
pin2 = 21
pin3 = 6
pin4 = 12

GPIO.setmode(GPIO.BCM)
GPIO.setup(pin1, GPIO.OUT)
GPIO.setup(pin2, GPIO.OUT)
GPIO.setup(pin3, GPIO.OUT)
GPIO.setup(pin4, GPIO.OUT)

try:
    while True:
        GPIO.output(pin1, True)
        GPIO.output(pin2, False)
        GPIO.output(pin3, True)
        GPIO.output(pin4, False)
        #print('Motor 1')
        #time.sleep(2)

except KeyboardInterrupt:
    GPIO.cleanup()
    sys.exit()