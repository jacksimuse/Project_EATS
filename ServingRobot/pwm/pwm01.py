import RPi.GPIO as GPIO
import sys
import time


pin1 = 20
pin2 = 21
pin3 = 6
pin4 = 12
ena = 17
enb = 18

GPIO.setmode(GPIO.BCM)
GPIO.setup(pin1, GPIO.OUT)
GPIO.setup(pin2, GPIO.OUT)
GPIO.setup(pin3, GPIO.OUT)
GPIO.setup(pin4, GPIO.OUT)
GPIO.setup(ena, GPIO.OUT)
GPIO.setup(enb, GPIO.OUT)

# def setPinConfig(EN, INA, INB):        
#     GPIO.setup(EN, GPIO.OUT)
#     GPIO.setup(INA, GPIO.OUT)
#     GPIO.setup(INB, GPIO.OUT)
#     # 100khz 로 PWM 동작 시킴 
#     pwm = GPIO.PWM(EN, 100) 
#     # 우선 PWM 멈춤.   
#     pwm.start(0) 
#     return pwm

try:
    pa = GPIO.PWM(ena, 100)
    pb = GPIO.PWM(enb, 100)
    pa.start(20)
    pb.start(100)

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