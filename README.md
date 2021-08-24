<<<<<<< HEAD
# EATS (Enterprise Automation Table-serving System) 프로젝트 
- 개요 : 인건비 부담과 혼밥, 혼술이 유행하며 1인 소자본 소규모 창업이 증가함에 따라 1인 운영이 가능한 자동화 시스템 필요성 제시    
현재 상용화되고 있는 서빙 로봇과 연계하여 활용 가능한 키오스크와 주방용 UI 제작 
- 참여 인원 : 최재훈, 허재현, 김현수, 성홍렬, 안성주, 최연성 (윈도우플랫폼기반 IoT 개발자과정 4조)
- 기대 효과 : 인건비로 인한 식당 운영 부담 감소, 직원 실수로 인한 주문 누락 방지, 유연한 식당 업종 변경 가능
- 프로젝트 기간 : 2021-07-23 ~ 2021-08-20
- 사용 언어 및 기술 : C# / .NET WPF / MS-SQL / 



## 목차 
- 기획
- 설계
- 구현
- 발전 방향 및 개선 방안 

## 1. 기획 (2021-07-23 ~ 2021-07-30)
#### 요구사항 정의 
![요구사항 정의](https://user-images.githubusercontent.com/77951828/129823796-a3a3d659-bde2-412f-83bb-43d2955d5b67.png)
#### To-Be 프로세스 정의
![image](https://user-images.githubusercontent.com/77951828/129824051-ef0a3618-5754-415f-9ed0-abd38c06241c.png)

## 2. 설계 (2021-07-28 ~ 2021-08-03)
#### UI 설계 
![image](https://user-images.githubusercontent.com/77951828/129824130-f85665d5-226c-4b63-8a99-4f598544056d.png)
#### 테이블 기술서 작성
![image](https://user-images.githubusercontent.com/77951828/129824169-c7b0b9f1-1eef-45de-a90c-6634a9772298.png)

## 3. 구현 (2021-08-02 ~ 2021-08-20)
### 3-1. [주문용 키오스크](https://github.com/jacksimuse/Project_EATS/tree/main/kiosk1)
### 3-2. [주방UI](https://github.com/jacksimuse/Project_EATS/tree/main/%EC%A3%BC%EB%B0%A9/EATS_kitchen)
### 3-3. [서빙 로봇 제작](https://github.com/jacksimuse/Project_EATS/tree/hongryeol)

## 4. 발전 방향 및 개선 방안 
- DB 데이터 기반 통계 기능 추가
- 코드 흐름 분석 및 리팩토링 
- OpenCV를 활용한 시각 정보 활용 자율 주행 기능  

## 팀원 역할 (자기가 맡은 파트 업데이트 해주세요)  
🧓 최재훈 : 주방UI(MQTT로 주문 코드받기, DB연동, 로봇에 메세지보내기) MQTT서버를 통해 주문 메시지 받기, 서빙로봇 출발시키기  
👦 김현수 : EntityFramework DB 연동, Data Select/Insert 테스트 (8/2), [주문 테스트](https://github.com/jacksimuse/Project_EATS/tree/main/OrderTest) (8/3),    
            키오스크 / 주방UI 동작 로직 설계 및 구현    
🧑 허재현 : 자료 조사 및 프로젝트 방향 설정 ------ 취업 완료 (2021.07.2x)   
🧔 성홍렬 : Serving Robot 설계 및 구현   
👩‍🦰 안성주 :  메뉴UI (8/3) 손님UI(대기번호 전송, 주문확인 결제창) , 관리자 로그인창 (8/05)       
👩 최연성 :  opencv 움직임 감지 + 초음파 센서 장애물 거리 감지(8/5) LINQ 및 mqtt를 이용한 json 메세지 처리 및 전반적인 피드백 제공 ------ 취업 완료 (2021.08.3x)   
=======
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
<img src ="https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/refimg/moterset.png" width="800" height="280"/>
<br/>
<br/>

### 라인트레이서 센서
---
<img src ="https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/refimg/line.png" width="180" height="260"/>
<br/>
<br/>

### 초음파 센서
---
<img src ="https://github.com/jacksimuse/Project_EATS/blob/hongryeol/ServingRobot/refimg/ultra.png" width="200" height="150"/>
<br/>
>>>>>>> 880725db3da8cc8aadf95d78f2af0d66e443d7d3
<br/>
