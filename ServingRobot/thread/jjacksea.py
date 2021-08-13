import paho.mqtt.client as mqtt #import the client1
import time
import signal
import os
import RPi.GPIO as GPIO
import threading

event_stop = threading.Event()
event_pause = threading.Event()
event_stop.clear()
event_pause.clear()
"""
-- threading.Event() -- 
# set() : 1
# clear() : 0
# wait() 1 : return / 0 : wait
# isSet() : flag status return 
"""

def setup():
	pin = 18
	GPIO.setmode(GPIO.BCM)
	GPIO.setup(pin, GPIO.OUT)
	global p
	p = GPIO.PWM(pin,50)

	
def set_0():
	print("set motor 0 degree")
	p.ChangeDutyCycle(2.5)
	time.sleep(1)

def set_90():
	print("set motor 90 degree")
	p.ChangeDutyCycle(7.5)
	time.sleep(1)

def set_180():
	print("set motor 180 degree")
	p.ChangeDutyCycle(12.5)
	time.sleep(1)

def start(event_stop, event_pause):
	print('--loop start--')
	# p = GPIO.PWM(18, 50)
	angle = 2.5
	print(angle)
	while(1):
		if event_stop.is_set():
			event_stop.clear()
			break
		if event_pause.is_set():
			while(1):
				print('--pause--')
				if event_pause.is_set() == False:
					break
				time.sleep(1)
		if angle == 12.5:
			angle = 2.5
		else:
			angle = 12.5
		p.ChangeDutyCycle(angle)
		print(angle)
		time.sleep(1)

		


def stop():
	event_stop.set()
    

def pause():
	event_pause.set()
	for _ in range(3):
		time.sleep(1)
	event_pause.clear()

def on_message(client, userdata, message):
	topic=str(message.topic)
	message = str(message.payload.decode("utf-8"))
	print(topic+message)
	if message == '0':
		set_0()
	elif message == '90':
		set_90()
	elif message == '180':
		set_180()
	elif message == 'p':
		# lotate()
		pause()
	elif message == 's':
		thread = threading.Thread(target=start, args=(event_stop, event_pause,))
		thread.start()
	elif message == 't':
		stop()
	else: pass
	
		

broker_address='210.119.12.96'
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
	setup()
	p.start(0)
	while(1):
		client.loop_forever()

except KeyboardInterrupt:
	GPIO.cleanup()
	client.disconnect()
	client.loop_stop()