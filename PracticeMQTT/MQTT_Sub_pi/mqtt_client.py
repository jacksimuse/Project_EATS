import paho.mqtt.client as mqtt #import the client1
import time
import signal
import os
import RPi.GPIO as GPIO

def setup():
	pin = 18
	GPIO.setmode(GPIO.BCM)
	GPIO.setup(pin, GPIO.OUT)
	global p
	p = GPIO.PWM(pin,50)
	

def handler(sig, frame):
	print (sig, frame)
	print("SIGINT Corrupted")
	for i in range(3):
		print(i)
		time.sleep(1)
	

def func1():
	print("set_0 degree")
	set_0()

		
def func2():
	print("set 90 degree")
	set_90()

def func3():
	print("set 180 degree")
	set_180()
	
def set_0():
	p.ChangeDutyCycle(2.5)
	time.sleep(1)

def set_90():
	p.ChangeDutyCycle(7.5)
	time.sleep(1)

def set_180():
	p.ChangeDutyCycle(12.5)
	time.sleep(1)

def lotate():
	p.ChangeDutyCycle(2.5)
	for i in range(180):
		p.ChangeDutyCycle(2.5 + 10/180 * i)
		time.sleep(0.01)

def start():
	angle = 2.5
	tmp = 1/18
	
	while True:
		if angle > 12.5:
			tmp = -1/18
		if angle < 2.5:
			tmp = 1/18
		angle += tmp
		p.ChangeDutyCycle(angle)
		time.sleep(0.01)

def stop():
	print("stop message")
	

			

def on_message(client, userdata, message):
	topic=str(message.topic)
	message = str(message.payload.decode("utf-8"))
	print(topic+message)
	if message == '0':
		func1()
	elif message == '90':
		func2()
	elif message == '180':
		func3()
	elif message == 'r':
		lotate()
	elif message == 's':
		start()
	elif message == 'p':
		stop()
	else: pass
	
		

broker_address='210.119.12.96'
pub_topic = 'TOMATO/'
print("creating new instance")
client=mqtt.Client("P1") #create new instance

print("connecting to broker")
client.connect(broker_address) #connect to broker
client.subscribe(pub_topic)

# client.on_connect = on_connect
client.on_message = on_message



try:
	setup()
	p.start(0)
	while(1):
		client.loop_forever()
except KeyboardInterrupt:
	client.disconnect()
	client.loop_stop()

