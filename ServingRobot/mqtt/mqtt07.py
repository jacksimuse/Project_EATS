### 라이브러리 불러오기
from platform import dist
import RPi.GPIO as GPIO
import paho.mqtt.client as mqtt
import sys
import threading
import signal
import os
import time

### 스레드 사용시 필요 변수
# event_stop = threading.Event()
# event_pause = threading.Event()
# event_stop.clear()
# event_pause.clear()

### 핀 할당
# 라인 근접 센서x2
pin = 19        # 라인 근접 센서1
pin2 = 4        # 라인 근접 센서2
# 바퀴 굴리기 위한 모터x4
ena = 22        # 앞 왼 바퀴(a) enable 입력 
mpin1 = 24      # 앞 왼 바퀴1(a)
mpin2 = 25      # 앞 왼 바퀴2(a)
enb = 23        # 앞 오 바퀴(b) enable 입력 
mpin3 = 5       # 앞 오 바퀴1(b)
mpin4 = 13      # 앞 오 바퀴2(b)
enc = 17        # 뒤 왼 바퀴(c) enable 입력
mpin5 = 20      # 뒤 왼 바퀴1(c)
mpin6 = 21      # 뒤 왼 바퀴2(c)
end = 18        # 뒤 오 바퀴(d) enable 입력
mpin7 = 6       # 뒤 오 바퀴1(d)
mpin8 = 12      # 뒤 오 바퀴2(d)
# 초음파 센서x1
triggerPin = 16 # 초음파 트리거핀
echoPin = 26    # 초음파 에코핀

### GPIO 모드 설정
GPIO.setmode(GPIO.BCM)
GPIO.setup(pin, GPIO.IN)
GPIO.setup(pin2, GPIO.IN)
GPIO.setup(ena, GPIO.OUT)
GPIO.setup(mpin1, GPIO.OUT)
GPIO.setup(mpin2, GPIO.OUT)
GPIO.setup(enb, GPIO.OUT)
GPIO.setup(mpin3, GPIO.OUT)
GPIO.setup(mpin4, GPIO.OUT)
GPIO.setup(enc, GPIO.OUT)
GPIO.setup(mpin5, GPIO.OUT)
GPIO.setup(mpin6, GPIO.OUT)
GPIO.setup(end, GPIO.OUT)
GPIO.setup(mpin7, GPIO.OUT)
GPIO.setup(mpin8, GPIO.OUT)
GPIO.setup(triggerPin, GPIO.OUT)
GPIO.setup(echoPin, GPIO.IN)

### 속도 조절 위한 PWM 설정
pa = GPIO.PWM(ena, 100)
pb = GPIO.PWM(enb, 100)
pa.start(40)
pb.start(40)
pc = GPIO.PWM(enc, 100)
pd = GPIO.PWM(end, 100)
pc.start(40)
pd.start(40)

### 구동 초기 정지 상태 설정(모터 드라이버의 출력 오류로 처음부터 모터가 작동될 수 있기 때문)
# GPIO.output(mpin1, False)
# GPIO.output(mpin2, False)
# GPIO.output(mpin3, False)
# GPIO.output(mpin4, False)
# GPIO.output(mpin5, False)
# GPIO.output(mpin6, False)
# GPIO.output(mpin7, False)
# GPIO.output(mpin8, False)

### PWM 값 및 time.sleep()의 시간 변수 설정
h = 100         # High
r = 40          # Low
sec = 0.00001   # second
flag = 0

### 초음파 센서 이용한 방해물 감지 메서드
def ultra():
    while True:
        # 트리거 핀을 통해 신호 발생
        GPIO.output(triggerPin, GPIO.LOW)
        time.sleep(0.00001)
        GPIO.output(triggerPin, GPIO.HIGH)

        # 에코 핀을 통해 신호 수신
        while GPIO.input(echoPin) == 0: # 초음파 전송이 끝나는 전송시간 저장
            start = time.time()
        while GPIO.input(echoPin) == 1: # 초음파 수신이 완료된 때 시간 저장
            stop = time.time()

        rtTotime = stop - start         # 초음파 송수신 완료 시간
        distance = rtTotime * 34000 / 2 # 탐지된 물체와의 거리
        print("distance : %.2fcm" % distance)

        time.sleep(0.1)
        return distance

### 코너링 후 다시 원래 속도로 돌아오기 위한 메서드
def setOg():
    pa.ChangeDutyCycle(r)       # 평상시 주행 PWM은 r(=40)로 고정
    pb.ChangeDutyCycle(r)
    pc.ChangeDutyCycle(r)
    pd.ChangeDutyCycle(r)

### 좌회전
def set_left():
    pa.ChangeDutyCycle(h)       # 코너링을 위해 더 높은 PWM인 h(=100)으로 설정
    pb.ChangeDutyCycle(h)
    pd.ChangeDutyCycle(h)
    pc.ChangeDutyCycle(h)
    GPIO.output(mpin1, True)    # 좌회전시 a와 c는 역방향 회전, b와 d는 정방향 회전
    GPIO.output(mpin2, False)
    GPIO.output(mpin3, False)
    GPIO.output(mpin4, True)
    GPIO.output(mpin5, True)
    GPIO.output(mpin6, False)
    GPIO.output(mpin7, True)
    GPIO.output(mpin8, False)

### 우회전
def set_right():
    pa.ChangeDutyCycle(h)
    pb.ChangeDutyCycle(h)
    pc.ChangeDutyCycle(h)
    pd.ChangeDutyCycle(h)
    GPIO.output(mpin1, False)    # 우회전시 a와 c는 정방향 회전, b와 d는 역방향 회전
    GPIO.output(mpin2, True)
    GPIO.output(mpin3, True)
    GPIO.output(mpin4, False)
    GPIO.output(mpin5, False)
    GPIO.output(mpin6, True)
    GPIO.output(mpin7, False)
    GPIO.output(mpin8, True)

### 짧은 후진
def set_temp_back():
    t_end = time.time() + 2
    setOg()
    while time.time() < t_end:
        GPIO.output(mpin1, True)                                       # 전진 운전
        GPIO.output(mpin2, False)
        GPIO.output(mpin3, True)
        GPIO.output(mpin4, False)
        GPIO.output(mpin5, True)
        GPIO.output(mpin6, False)
        GPIO.output(mpin7, False)
        GPIO.output(mpin8, True)
    stop()
	
### 짧은 전진
def set_temp_forward():
    setOg()
    while True:
        if (GPIO.input(pin) == True) and (GPIO.input(pin2) == True):
            break
        elif (GPIO.input(pin) == False) or (GPIO.input(pin2) == False):
            GPIO.output(mpin1, False)                                       # 전진 운전
            GPIO.output(mpin2, True)
            GPIO.output(mpin3, False)
            GPIO.output(mpin4, True)
            GPIO.output(mpin5, False)
            GPIO.output(mpin6, True)
            GPIO.output(mpin7, True)
            GPIO.output(mpin8, False)
            time.sleep(0.00001)
    stop()
	
### 짧은 좌회전
def set_temp_left():
    pa.ChangeDutyCycle(h)
    pb.ChangeDutyCycle(h)
    pc.ChangeDutyCycle(h)
    pd.ChangeDutyCycle(h)
    t_end = time.time() + 0.8
    while time.time() < t_end:
        GPIO.output(mpin1, True)    # 좌회전시 a와 c는 역방향 회전, b와 d는 정방향 회전
        GPIO.output(mpin2, False)
        GPIO.output(mpin3, False)
        GPIO.output(mpin4, True)
        GPIO.output(mpin5, True)
        GPIO.output(mpin6, False)
        GPIO.output(mpin7, True)
        GPIO.output(mpin8, False)

### 짧은 우회전
def set_temp_right():
    pa.ChangeDutyCycle(h)
    pb.ChangeDutyCycle(h)
    pc.ChangeDutyCycle(h)
    pd.ChangeDutyCycle(h)
    t_end = time.time() + 0.8
    while time.time() < t_end:
        GPIO.output(mpin1, False)    # 우회전시 a와 c는 정방향 회전, b와 d는 역방향 회전
        GPIO.output(mpin2, True)
        GPIO.output(mpin3, True)
        GPIO.output(mpin4, False)
        GPIO.output(mpin5, False)
        GPIO.output(mpin6, True)
        GPIO.output(mpin7, False)
        GPIO.output(mpin8, True)

### 라인트레이스를 통한 전진/좌회전/우회전
def set_start():
    while True:
        # 스레드 이용하여 멈춤 기능 구현시 필요한 제어문
        # if event_stop.is_set():
        #         event_stop.clear()
        #         break
        # elif event_pause.is_set():
        #     while(1):
        #         print('--pause--')
        #         if event_pause.is_set() == False:
        #             break
        #         time.sleep(1)

        # 초음파 센서로 방해물 감지
        # distance = ultra()
        # if distance < 60:
        #     stop()
        if (GPIO.input(pin) == False) and (GPIO.input(pin2) == False):    # 근접센서1 on, 근접센서2 on
            #print("no path")
            stop()                                                          # RC카 멈춘 후
            break                                                           # 라인트레이스 구동 종료
        elif (GPIO.input(pin) == True) and (GPIO.input(pin2) == True):      # 근접센서1 off, 근접센서2 off
            #print("path")
            setOg()
            GPIO.output(mpin1, False)                                       # 전진 운전
            GPIO.output(mpin2, True)
            GPIO.output(mpin3, False)
            GPIO.output(mpin4, True)
            GPIO.output(mpin5, False)
            GPIO.output(mpin6, True)
            GPIO.output(mpin7, True)
            GPIO.output(mpin8, False)
            time.sleep(0.00001)
        elif (GPIO.input(pin) == False) and (GPIO.input(pin2) == True):     # 근접센서1 on, 근접센서2 off
            #print("right")
            set_right()                                                     # 우회전 운전
            time.sleep(sec)
        elif (GPIO.input(pin) == True) and (GPIO.input(pin2) == False):     # 근접센서1 off, 근접센서2 on
            #print("left")
            set_left()                                                      # 좌회전 운전
            time.sleep(sec)
        
### 경로가 끝난 지점에서 다시 운전하기 위해 180도 회전
def set_position():
    while True:
        if (GPIO.input(pin) == True) and (GPIO.input(pin2) == True):        # 핀이 둘 다 off일 시 = 경로에 위치할 시
            break                                                           # 제자리 좌회전 종료
        elif (GPIO.input(pin) == False) or (GPIO.input(pin2) == False):     # 핀이 둘 중 하나라도 on일 시
            set_left()                                                      # 제자리 좌회전 운전
            time.sleep(0.001)
    stop()

### 정지
def stop():
    #event_stop.set()           # 스레드 활용한 종료 시 사용
    GPIO.output(mpin1, False)
    GPIO.output(mpin2, False)
    GPIO.output(mpin3, False)
    GPIO.output(mpin4, False)
    GPIO.output(mpin5, False)
    GPIO.output(mpin6, False)
    GPIO.output(mpin7, False)
    GPIO.output(mpin8, False)

### 일시정지
# def pause():
# 	event_pause.set()           # 스레드 활용한 일시 정지 시 사용
# 	for _ in range(3):
# 		time.sleep(1)
# 	event_pause.clear()

### 서빙 후 정위치로 세팅
def set_table_position():
    global flag
    set_position()
    set_start()

    if flag == 1:
        set_position()
        set_temp_back()
    elif flag == 2:
        set_temp_forward()
        set_temp_left()
    elif flag == 3:
        set_temp_forward()
        set_temp_right()
    elif flag == 4:
        pass

### mqtt이용한 통신 메서드(서버로부터 publish message를 받을 때 호출되는 콜백)
def on_message(client, userdata, message):
    global flag
    # Topic에 연결하여 메세지를 수신한다(Subscribe).
    topic=str(message.topic)                        
    message = str(message.payload.decode("utf-8"))
    print(topic+message)

    # 해당 Topic의 메세지에 대한 동작 수행
    if message == 's':          # 전진
        set_start()
    elif message == 'b':        # 복귀
        set_table_position()
        flag = 0
    elif message == 't':        # 정지
        stop()
    elif message == '1':        # 1번 테이블
        flag = 1
        set_start()
    elif message == '2':        # 2번 테이블
        flag = 2
        set_start()
    elif message == '3':        # 3번 테이블
        flag = 3
        set_start()
    # elif message == '4':        # 4번 테이블
    #     flag = 4
    #     set_start()
    else: pass

### mqtt 통신 위한 객체 생성 및 설정
broker_address='210.119.12.93'  # broker address
pub_topic = 'MOTOR/TEST/'       # topic
print("creating new instance")
client=mqtt.Client("P1")        # create new instance
print("connecting to broker")
client.connect(broker_address)  # connect to broker
client.subscribe(pub_topic)     # subscribe topic

# 콜백 설정
# client.on_connect = on_connect
# client.on_disconnect = on_disconnect
client.on_message = on_message

try:
    while True:
        client.loop_forever()   # 지속적으로 buffer 를 체크하고 이벤트를 발생한다.

except KeyboardInterrupt:
    GPIO.cleanup()
    sys.exit()