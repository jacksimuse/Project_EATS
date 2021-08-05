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
