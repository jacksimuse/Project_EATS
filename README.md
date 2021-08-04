# 역할 : 주방 UI
- 기능 : 메뉴화면 가져와서 활성, 비활성 / 주문을 MQTT를 통해 메시지로 받고 linq를 통해 DB에서 가져오기 / 로봇 출발시키기

=======
# 1.메인화면(손님UI)
![image](https://user-images.githubusercontent.com/77951833/128292847-bb93b225-cc8d-421c-ac6f-589ef8fb92df.png)
# 1-2.메뉴선택창
## 손님이 좌석선택을 하면 메뉴선택창으로 이동
![image](https://user-images.githubusercontent.com/77951833/128292940-f442b317-e420-46f9-984d-4d53804f81f4.png)
# 1-3. 선택한메뉴
## 각 항목에 해당하는 메뉴를 누르면 정보 (메뉴, 수량, 가격)이 뜸 
![image](https://user-images.githubusercontent.com/77951833/128293159-6945458f-0fea-4f9f-9117-2fc71016753b.png)
# 1-4. 결제
## 결제전 주문정보를 한번더 확인 
![image](https://user-images.githubusercontent.com/77951833/128293440-a0af0cc9-1f50-4c42-8619-f7d9ba9644cc.png)


## 진행현황(최신순)  
ordercode, menucode, amount를 DB로 보내서 값 받아오기  
<kbd>![GOMCAM 20210805_1136270212](https://user-images.githubusercontent.com/73567433/128282450-f8da6211-973a-4bc8-ab30-672ee43c4fff.gif)</kbd>
  

ordercode 받아지는지 확인  
<kbd>![GOMCAM 20210805_1015580214 (1) (1)](https://user-images.githubusercontent.com/73567433/128276530-10f15f94-dfa1-4475-b19d-ef8333d31189.gif)</kbd>

## 팀원 역할 (자기가 맡은 파트 업데이트 해주세요)  
🧓 최재훈 : 주방UI(기능 : 주문현황, 메뉴활성화) MQTT서버를 통해 주문 메시지 받기, 서빙로봇 출발시키기
🧑 허재현 : 취업 완료 (2021.07.2x)       
👦 김현수 : EntityFramework DB 연동, Data Select/Insert 테스트 (8/2), [주문 테스트](https://github.com/jacksimuse/Project_EATS/tree/main/OrderTest) (8/3)  
🧔 성홍렬 : Serving Robot 설계 및 구현   
👩‍🦰 안성주 :  [메뉴UI](https://github.com/jacksimuse/Project_EATS/tree/main/kiosk1) (8/3)    
👩 최연성 :     
