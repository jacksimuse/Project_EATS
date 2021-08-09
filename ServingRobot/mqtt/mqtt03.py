import RPi.GPIO as GPIO
import paho.mqtt.client as mqtt
import sys
import threading
import signal
import os
import time

pin = 19        # 라인 근접 센서
pin2 = 4        # 라인 근접 센서
mpin1 = 24      # 앞 왼 바퀴1
mpin2 = 25      # 앞 왼 바퀴2
mpin3 = 5       # 앞 오 바퀴1
mpin4 = 13      # 앞 오 바퀴2
ena = 22        # 앞 오 바퀴 enable 입력 
enb = 23        # 앞 오 바퀴 enable 입력 
mpin5 = 20      # 뒤 왼 바퀴1
mpin6 = 21      # 뒤 왼 바퀴2
mpin7 = 6       # 뒤 오 바퀴1
mpin8 = 12      # 뒤 오 바퀴2
enc = 17        # 뒤 왼 바퀴 enable 입력
end = 18        # 뒤 오 바퀴 enable 입력 

GPIO.setmode(GPIO.BCM)
GPIO.setup(pin, GPIO.IN)
GPIO.setup(pin2, GPIO.IN)
GPIO.setup(mpin1, GPIO.OUT)
GPIO.setup(mpin2, GPIO.OUT)
GPIO.setup(mpin3, GPIO.OUT)
GPIO.setup(mpin4, GPIO.OUT)
GPIO.setup(ena, GPIO.OUT)
GPIO.setup(enb, GPIO.OUT)
GPIO.setup(mpin5, GPIO.OUT)
GPIO.setup(mpin6, GPIO.OUT)
GPIO.setup(mpin7, GPIO.OUT)
GPIO.setup(mpin8, GPIO.OUT)
GPIO.setup(enc, GPIO.OUT)
GPIO.setup(end, GPIO.OUT)

pa = GPIO.PWM(ena, 100)
pb = GPIO.PWM(enb, 100)
pa.start(40)
pb.start(40)
pc = GPIO.PWM(enc, 100)
pd = GPIO.PWM(end, 100)
pc.start(40)
pd.start(40)

GPIO.output(mpin1, False)
GPIO.output(mpin2, False)
GPIO.output(mpin3, False)
GPIO.output(mpin4, False)
GPIO.output(mpin5, False)
GPIO.output(mpin6, False)
GPIO.output(mpin7, False)
GPIO.output(mpin8, False)

def setOg():
    pa.ChangeDutyCycle(40)
    pb.ChangeDutyCycle(40)
    pc.ChangeDutyCycle(40)
    pd.ChangeDutyCycle(40)

def set_left():
    pa.ChangeDutyCycle(100)
    pb.ChangeDutyCycle(100)
    pd.ChangeDutyCycle(100)
    pc.ChangeDutyCycle(100)
    GPIO.output(mpin1, True)
    GPIO.output(mpin2, False)
    GPIO.output(mpin3, False)
    GPIO.output(mpin4, True)
    GPIO.output(mpin5, True)
    GPIO.output(mpin6, False)
    GPIO.output(mpin7, True)
    GPIO.output(mpin8, False)

def set_right():
    pa.ChangeDutyCycle(100)
    pb.ChangeDutyCycle(100)
    pc.ChangeDutyCycle(100)
    pd.ChangeDutyCycle(100)
    GPIO.output(mpin1, False)
    GPIO.output(mpin2, True)
    GPIO.output(mpin3, True)
    GPIO.output(mpin4, False)
    GPIO.output(mpin5, False)
    GPIO.output(mpin6, True)
    GPIO.output(mpin7, False)
    GPIO.output(mpin8, True)

def set_start():
    while True:
        if (GPIO.input(pin) == False) and (GPIO.input(pin2) == False):
            #print("no path")
            setOg()
            GPIO.output(mpin1, False)
            GPIO.output(mpin2, False)
            GPIO.output(mpin3, False)
            GPIO.output(mpin4, False)
            GPIO.output(mpin5, False)
            GPIO.output(mpin6, False)
            GPIO.output(mpin7, False)
            GPIO.output(mpin8, False)
            time.sleep(0.00001)
        elif (GPIO.input(pin) == True) and (GPIO.input(pin2) == True):
            #print("path")
            setOg()
            GPIO.output(mpin1, False)
            GPIO.output(mpin2, True)
            GPIO.output(mpin3, False)
            GPIO.output(mpin4, True)
            GPIO.output(mpin5, False)
            GPIO.output(mpin6, True)
            GPIO.output(mpin7, True)
            GPIO.output(mpin8, False)
            time.sleep(0.00001)
        elif (GPIO.input(pin) == False) and (GPIO.input(pin2) == True):
            #print("right")
            pa.ChangeDutyCycle(100)
            pb.ChangeDutyCycle(100)
            pc.ChangeDutyCycle(100)
            pd.ChangeDutyCycle(100)
            GPIO.output(mpin1, False)
            GPIO.output(mpin2, True)
            GPIO.output(mpin3, True)
            GPIO.output(mpin4, False)
            GPIO.output(mpin5, False)
            GPIO.output(mpin6, True)
            GPIO.output(mpin7, False)
            GPIO.output(mpin8, True)
            time.sleep(0.00001)
        elif (GPIO.input(pin) == True) and (GPIO.input(pin2) == False):
            #print("left")
            pa.ChangeDutyCycle(100)
            pb.ChangeDutyCycle(100)
            pd.ChangeDutyCycle(100)
            pc.ChangeDutyCycle(100)
            GPIO.output(mpin1, True)
            GPIO.output(mpin2, False)
            GPIO.output(mpin3, False)
            GPIO.output(mpin4, True)
            GPIO.output(mpin5, True)
            GPIO.output(mpin6, False)
            GPIO.output(mpin7, True)
            GPIO.output(mpin8, False)
            time.sleep(0.00001)

def set_back():
    setOg()
    GPIO.output(mpin1, True)
    GPIO.output(mpin2, False)
    GPIO.output(mpin3, True)
    GPIO.output(mpin4, False)
    GPIO.output(mpin5, True)
    GPIO.output(mpin6, False)
    GPIO.output(mpin7, False)
    GPIO.output(mpin8, True)

def stop():
    setOg()
    GPIO.output(mpin1, False)
    GPIO.output(mpin2, False)
    GPIO.output(mpin3, False)
    GPIO.output(mpin4, False)
    GPIO.output(mpin5, False)
    GPIO.output(mpin6, False)
    GPIO.output(mpin7, False)
    GPIO.output(mpin8, False)

def on_message(client, userdata, message):
    topic=str(message.topic)
    message = str(message.payload.decode("utf-8"))
    print(topic+message)

    if message == 's':
        set_start()
    elif message == 'b':
        set_back()
    elif message == 't':
        stop()
    elif message == 'l':
        set_left()
    elif message == 'r':
        set_right()
    else: pass

broker_address='210.119.12.93'
pub_topic = 'MOTOR/TEST/'
print("creating new instance")
client=mqtt.Client("P1") #create new instance
print("connecting to broker")
client.connect(broker_address) #connect to broker
client.subscribe(pub_topic)

# client.on_connect = on_connect
# client.on_disconnect = on_disconnect
client.on_message = on_message


try:
    while True:
        client.loop_forever()

except KeyboardInterrupt:
    GPIO.cleanup()
    sys.exit()