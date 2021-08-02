import pigpio
import time

#servo.py가 잘 안되는 경우
pwm_pin = 18
pi = pigpio.pi()
angle = 0
pi.set_servo_pulsewidth(pwm_pin, angle * 100 + 500)
while True:
    cmd = input("Command, f/r: ")
    direction = cmd[0]
    if direction == "f":
        angle += 1
    else:
        angle -= 1
    if angle < 0:
        angle = 0
    elif angle > 18:
        angle = 18
    print("angle=", angle*10)
    pi.set_servo(pwm_pin, angle * 100 + 500)