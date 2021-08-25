# 서빙 로봇 구현
EATS 프로젝트에서 서빙을 담당할 로봇에 대한 내용입니다.
<br/>
<br/>

## 1. 로봇의 동작 구현[.py 👈](https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/mqtt/mqtt06.py)
#### DC모터x4 및 모터드라이버 모듈x2을 이용한 기본 운전
---
<img src ="https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/refimg/moterset.png" width="600" height="200"/>
<br/>

![drive](https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/refimg/1.gif)
<br/>
###### 서빙로봇의 기본 운전인 전진, 후진, 좌회전, 우회전을 구현하였습니다.

<br/>
<br/>

#### 근접라인 센서를 이용한 라인트레이싱
---
<img src ="https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/refimg/line.png" width="180" height="260"/>
<br/>

![linetrace](https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/refimg/2.gif)
<br/>
###### 라인트레이스를 통해 로봇은 검은색 라인을 따라 운전하게 됩니다. <br/> 복귀 수행시 다시 라인을 따라 돌아오게 됩니다.

<br/>
<br/>

#### 초음파 센서를 이용한 방해물 감지
---
<img src ="https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/refimg/ultra.png" width="200" height="150"/>
<br/>

![ultra](https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/refimg/3.gif)
<br/>
###### 초음파 센서를 통해 로봇 전방에 방해물 or 사람이 있을 시 동작을 잠시 멈추게 됩니다.

<br/>

## 2. EATS 프로젝트 적용[.py 👈](https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/mqtt/mqtt07.py)
#### 원하는 테이블로 서빙 수행
---
이미지
<br/>

