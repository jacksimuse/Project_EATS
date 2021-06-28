import paho.mqtt.client as mqtt #import the client1
import time
import signal
import os

def handler(sig, frame):
	print (sig, frame)
	print("SIGINT Corrupted")
	for i in range(3):
		print(i)
		time.sleep(1)
	

def func1():
	print("do func1")
	signal.signal(signal.SIGINT, handler)
	for i in range(10):
		print(i)
		time.sleep(1)
def func2():
	print("do func2")

def on_message(client, userdata, message):
	topic=str(message.topic)
	message = str(message.payload.decode("utf-8"))
	print(topic+message)
	if message == 'msg1':
		func1()
	elif message == 'msg2':
		func2()
	elif message == 'msg3':
		pass

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
	while(1):
		client.loop_forever()
except KeyboardInterrupt:
	client.disconnect()
	client.loop_stop()

