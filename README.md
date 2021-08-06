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



# 역할 : 주방 UI
- 기능 : 메뉴화면 가져와서 활성, 비활성 / 주문을 MQTT를 통해 메시지로 받고 linq를 통해 DB에서 가져오기 / 로봇 출발시키기


## 진행현황(최신순)  
ordercode, menucode, amount를 DB로 보내서 값 받아오기  
<kbd>![GOMCAM 20210805_1136270212](https://user-images.githubusercontent.com/73567433/128282450-f8da6211-973a-4bc8-ab30-672ee43c4fff.gif)</kbd>
  

ordercode 받아지는지 확인  
<kbd>![GOMCAM 20210805_1015580214 (1) (1)](https://user-images.githubusercontent.com/73567433/128276530-10f15f94-dfa1-4475-b19d-ef8333d31189.gif)</kbd>


