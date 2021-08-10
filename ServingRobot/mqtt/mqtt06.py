from platform import dist
import RPi.GPIO as GPIO
import paho.mqtt.client as mqtt
import sys
import threading
import signal
import os
import time

event_stop = threading.Event()
event_pause = threading.Event()
event_stop.clear()
event_pause.clear()

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

triggerPin = 16 # 초음파 트리거핀
echoPin = 26    # 초음파 에코핀


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
GPIO.setup(triggerPin, GPIO.OUT)
GPIO.setup(echoPin, GPIO.IN)

pa = GPIO.PWM(ena, 100)
pb = GPIO.PWM(enb, 100)
pa.start(40)
pb.start(40)
pc = GPIO.PWM(enc, 100)
pd = GPIO.PWM(end, 100)
pc.start(40)
pd.start(40)

# GPIO.output(mpin1, False)
# GPIO.output(mpin2, False)
# GPIO.output(mpin3, False)
# GPIO.output(mpin4, False)
# GPIO.output(mpin5, False)
# GPIO.output(mpin6, False)
# GPIO.output(mpin7, False)
# GPIO.output(mpin8, False)

h = 100
r = 40
sec = 0.00001

def ultra():
    while True:
        GPIO.output(triggerPin, GPIO.LOW)
        time.sleep(0.00001)
        GPIO.output(triggerPin, GPIO.HIGH)

        while GPIO.input(echoPin) == 0: #초음파 전송이 끝나는 전송시간
            start = time.time()         #을 저장
        while GPIO.input(echoPin) == 1: #초음파 수신이 완료된 때 시간
            stop = time.time()          #을 저장

        rtTotime = stop - start
        distance = rtTotime * 34000 / 2
        print("distance : %.2fcm" % distance)

        time.sleep(0.1)
        return distance

def setOg():
    pa.ChangeDutyCycle(r)
    pb.ChangeDutyCycle(r)
    pc.ChangeDutyCycle(r)
    pd.ChangeDutyCycle(r)

def set_left():
    pa.ChangeDutyCycle(h)
    pb.ChangeDutyCycle(h)
    pd.ChangeDutyCycle(h)
    pc.ChangeDutyCycle(h)
    GPIO.output(mpin1, True)
    GPIO.output(mpin2, False)
    GPIO.output(mpin3, False)
    GPIO.output(mpin4, True)
    GPIO.output(mpin5, True)
    GPIO.output(mpin6, False)
    GPIO.output(mpin7, True)
    GPIO.output(mpin8, False)

def set_right():
    pa.ChangeDutyCycle(h)
    pb.ChangeDutyCycle(h)
    pc.ChangeDutyCycle(h)
    pd.ChangeDutyCycle(h)
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
        # if event_stop.is_set():
        #         event_stop.clear()
        #         break
        # elif event_pause.is_set():
        #     while(1):
        #         print('--pause--')
        #         if event_pause.is_set() == False:
        #             break
        #         time.sleep(1)
        distance = ultra()
        if distance < 60:
            stop()
        elif (GPIO.input(pin) == False) and (GPIO.input(pin2) == False):
            #print("no path")
            #setOg()
            stop()
            #time.sleep(0.00001)
            break
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
            set_right()
            time.sleep(sec)
        elif (GPIO.input(pin) == True) and (GPIO.input(pin2) == False):
            #print("left")
            set_left()
            time.sleep(sec)
        

def set_position():
    while True:
        # if event_stop.is_set():
        #         event_stop.clear()
        #         break
        if (GPIO.input(pin) == True) and (GPIO.input(pin2) == True):
            break
        elif (GPIO.input(pin) == False) or (GPIO.input(pin2) == False):
            set_left()
            time.sleep(0.001)
    stop()

def stop():
    #event_stop.set()
    GPIO.output(mpin1, False)
    GPIO.output(mpin2, False)
    GPIO.output(mpin3, False)
    GPIO.output(mpin4, False)
    GPIO.output(mpin5, False)
    GPIO.output(mpin6, False)
    GPIO.output(mpin7, False)
    GPIO.output(mpin8, False)

def pause():
	event_pause.set()
	for _ in range(3):
		time.sleep(1)
	event_pause.clear()

def on_message(client, userdata, message):
    topic=str(message.topic)
    message = str(message.payload.decode("utf-8"))
    print(topic+message)

    if message == 's':
        set_start()
        # time.sleep(3)
        # set_position()
        # set_start()
        # set_position()
    elif message == 'b':
        set_position()
        set_start()
        set_position()
    elif message == 't':
        stop()
    elif message == 'p':
        pause()
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