# 서빙 로봇 구현
EATS 프로젝트에서 서빙을 담당할 로봇에 대한 내용입니다.
<br/>

#### 로봇동작코드[.py 👈](https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/mqtt/mqtt06.py)
#### 프로젝트적용코드[.py 👈](https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/mqtt/mqtt07.py)
<br/>
<br/>

## 사용된 장치 및 센서
### DC모터x4 및 모터드라이버 모듈x2
---
<img src ="https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/refimg/moterset.png" width="600" height="200"/>
<br/>

![drive](https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/refimg/1.gif)
<br/>
###### 서빙로봇의 기본 동작인 전진, 후진, 좌회전, 우회전을 구현하였습니다.

<br/>
<br/>

### 라인트레이서 센서
---
<img src ="https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/refimg/line.png" width="180" height="260"/>
<br/>

![linetrace](https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/refimg/2.gif)
<br/>
###### 라인트레이스를 통해 로봇은 검은색 라인을 따라 해당 테이블로 서빙하게 됩니다.

<br/>
<br/>

### 초음파 센서
---
<img src ="https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/refimg/ultra.png" width="200" height="150"/>
<br/>

![ultra](https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/refimg/3.gif)
<br/>
###### 초음파 센서를 통해 로봇 전방에 방해물 or 사람이 있을 시 동작을 잠시 멈추게 됩니다.

<br/>
