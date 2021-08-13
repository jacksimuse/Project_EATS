# 역할 : 주방 UI
- 기능 : 메뉴화면 가져와서 활성, 비활성 / 주문을 MQTT를 통해 메시지로 받고 linq를 통해 DB에서 가져오기 / 로봇 출발시키기

=======
# 1.메인화면(손님UI)
![image](https://user-images.githubusercontent.com/77951833/128292847-bb93b225-cc8d-421c-ac6f-589ef8fb92df.png)
# 1-2-1.대기창
### 좌석이 다 차있을 경우, 대기하는 손님은 번호를 입력후 전송()()
![image](https://user-images.githubusercontent.com/77951833/128315581-6842f6d8-468d-4ae2-8359-8386d7db9a4b.png)
# 1-2.메뉴선택창
### 손님이 좌석선택을 하면 메뉴선택창으로 이동
![image](https://user-images.githubusercontent.com/77951833/128292940-f442b317-e420-46f9-984d-4d53804f81f4.png)
# 1-3. 선택한메뉴
### 각 항목에 해당하는 메뉴를 누르면 정보 (메뉴, 수량, 가격)이 뜸 
![image](https://user-images.githubusercontent.com/77951833/128293159-6945458f-0fea-4f9f-9117-2fc71016753b.png)
# 1-4. 결제
### 결제전 주문정보를 한번더 확인 
![image](https://user-images.githubusercontent.com/77951833/128316013-2ce1fe4f-1668-4870-8aa5-d8ab554c2ce5.png)

# 2.관리자로그인화면
### DB에 연결된 관리자 아이디와 비밀번호 입력
![image](https://user-images.githubusercontent.com/77951833/128316336-12909279-a61f-4a2e-9456-0683b2d2578f.png)

# 2-1. 아이디 비밀번호 오류,NULL
![image](https://user-images.githubusercontent.com/77951833/128316537-8127b79e-de2d-4268-8a9e-5f7aa3d33405.png)



## 진행현황(최신순)  
ordercode, menucode, amount를 DB로 보내서 값 받아오기  
<kbd>![GOMCAM 20210805_1136270212](https://user-images.githubusercontent.com/73567433/128282450-f8da6211-973a-4bc8-ab30-672ee43c4fff.gif)</kbd>


ordercode 받아지는지 확인  
<kbd>![GOMCAM 20210805_1015580214 (1) (1)](https://user-images.githubusercontent.com/73567433/128276530-10f15f94-dfa1-4475-b19d-ef8333d31189.gif)</kbd>

## 팀원 역할 (자기가 맡은 파트 업데이트 해주세요)  
🧓 최재훈 : 주방UI(기능 : MQTT로 주문 코드받기, DB연동, 로봇에 메세지보내기) MQTT서버를 통해 주문 메시지 받기, 서빙로봇 출발시키기
👦 김현수 : EntityFramework DB 연동, Data Select/Insert 테스트 (8/2), [주문 테스트](https://github.com/jacksimuse/Project_EATS/tree/main/OrderTest) (8/3)  
🧑 허재현 : 자료 조사 및 프로젝트 방향 설정 ------ 취업 완료 (2021.07.2x)   
🧔 성홍렬 : Serving Robot 설계 및 구현   
👩‍🦰 안성주 :  [메뉴UI](https://github.com/jacksimuse/Project_EATS/tree/main/kiosk1) (8/3) 손님UI(대기번호 전송, 주문확인 결제창) , 관리자 로그인창 (8/05)       
👩 최연성 :  opencv 움직임 감지 + 초음파 센서 장애물 거리 감지(8/5) LINQ 및 mqtt를 이용한 json 메세지 처리 및 전반적인 피드백 제공 ------ 취업 완료 (2021.08.3x)   
<br/>
