# 역할 : 주방 UI
- 기능 : 메뉴화면 가져와서 활성, 비활성 / 주문을 MQTT를 통해 메시지로 받고 linq를 통해 DB에서 가져오기 / 로봇 출발시키기


## 진행현황(최신순)
메뉴 활성 비활성화 시키고 DB에 커밋, 다음 화면이 켜질때 반영하기  
<kbd>![GOMCAM 20210805_2155400233 (2)](https://user-images.githubusercontent.com/73567433/128355018-554b7b6f-e380-439e-b24e-85dba4a1e7c7.gif)</kbd>

ordercode, menucode, amount를 DB로 보내서 값 받아오기  
<kbd>![GOMCAM 20210805_1136270212](https://user-images.githubusercontent.com/73567433/128282450-f8da6211-973a-4bc8-ab30-672ee43c4fff.gif)</kbd>
  

ordercode 받아지는지 확인  
<kbd>![GOMCAM 20210805_1015580214 (1) (1)](https://user-images.githubusercontent.com/73567433/128276530-10f15f94-dfa1-4475-b19d-ef8333d31189.gif)</kbd>

