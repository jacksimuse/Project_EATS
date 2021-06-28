import paho.mqtt.client as mqtt #import the client1
import time


def on_message(client, userdata, message):
	topic=str(message.topic)
	message = str(message.payload.decode("utf-8"))
	print(topic+message)
	if message == 'msg1':
		pass # do something (def func)
	elif message == 'msg2':
		pass
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

if __name__ == '__main__':
	try:
		while(1):
			client.loop_forever()
	except KeyboardInterrupt:
		client.disconnect()
		client.loop_stop()

