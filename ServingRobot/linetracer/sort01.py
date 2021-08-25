import RPi.GPIO as GPIO
import time

# 라인 근접 센서x2
pin = 19        # 라인 근접 센서1
pin2 = 4        # 라인 근접 센서2

### GPIO 모드 설정
GPIO.setmode(GPIO.BCM)
GPIO.setup(pin, GPIO.IN)
GPIO.setup(pin2, GPIO.IN)

try:
    while True:
        print('{0}'.format(GPIO.input(pin)))
        time.sleep(0.5)
except:
    GPIO.cleanup()