import sys
import time
import paho.mqtt.client as mqtt

def on_message(client, userdata, message):
	print ('userdata : ', userdata)
	print ('message : ', message)
def on_connect(client, userdata, flags, rc):
	print ('userdata : ', userdata)
	print ('flags : ', flags)
	print ('rc : ', rc)
	if userdata is True:
		print ('userdata is True')
		print ('rc : ' + str(rc))


client = mqtt.Client()
client.on_message = on_message
client.on_connect = on_connect

connAddress = '210.119.12.96'
topic = 'TOMATO/'
client.connect(connAddress, 1883, 60)
client.subscribe(topic, 0)

print ('start loop()')
cnt = 0

tc = 0
while True:
	client.loop()
print ('end of loop()')

