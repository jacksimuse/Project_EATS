import RPi.GPIO as GPIO
import paho.mqtt.client as mqtt
import sys
import threading
import signal
import os
import time

pin = 4        # 라인 근접 센서
mpin1 = 20      # 앞 왼 바퀴1
mpin2 = 21      # 앞 왼 바퀴2
mpin3 = 6       # 앞 오 바퀴1
mpin4 = 12      # 앞 오 바퀴2
ena = 17        # 앞 왼 바퀴 enable 입력
enb = 18        # 앞 오 바퀴 enable 입력 

GPIO.setmode(GPIO.BCM)
GPIO.setup(pin, GPIO.IN)
GPIO.setup(mpin1, GPIO.OUT)
GPIO.setup(mpin2, GPIO.OUT)
GPIO.setup(mpin3, GPIO.OUT)
GPIO.setup(mpin4, GPIO.OUT)
GPIO.setup(ena, GPIO.OUT)
GPIO.setup(enb, GPIO.OUT)

pa = GPIO.PWM(ena, 100)
pb = GPIO.PWM(enb, 100)
pa.start(100)
pb.start(100)

GPIO.output(mpin1, False)
GPIO.output(mpin2, False)
GPIO.output(mpin3, False)
GPIO.output(mpin4, False)

def setOg():
    pa.ChangeDutyCycle(100)
    pb.ChangeDutyCycle(100)

def set_left():
    pa.ChangeDutyCycle(40)
    GPIO.output(mpin1, True)
    GPIO.output(mpin2, False)
    GPIO.output(mpin3, False)
    GPIO.output(mpin4, True)

def set_right():
    pb.ChangeDutyCycle(40)
    GPIO.output(mpin1, False)
    GPIO.output(mpin2, True)
    GPIO.output(mpin3, True)
    GPIO.output(mpin4, False)

def set_start():
    setOg()
    GPIO.output(mpin1, False)
    GPIO.output(mpin2, True)
    GPIO.output(mpin3, False)
    GPIO.output(mpin4, True)

def set_back():
    setOg()
    GPIO.output(mpin1, True)
    GPIO.output(mpin2, False)
    GPIO.output(mpin3, True)
    GPIO.output(mpin4, False)

def stop():
    setOg()
    GPIO.output(mpin1, False)
    GPIO.output(mpin2, False)
    GPIO.output(mpin3, False)
    GPIO.output(mpin4, False)

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
    #GPIO.add_event_detect(pin, GPIO.FALLING, callback=client.loop_forever())
    # while True:
    #     if GPIO.input(pin) == False:
    #         print('path')
    #         if GPIO.input(pin) == True:
    #             break
    #         client.loop_forever()
    #     elif GPIO.input(pin) == True:
    #         print('no path')
    #         stop()


except KeyboardInterrupt:
    GPIO.cleanup()
    sys.exit()