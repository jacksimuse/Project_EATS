# 주방용 주문 관리 시스템 (.NET Framework WPF 기반, MS-SQL 연동, MQTT) 

## 주문 관리 화면 
- 우상단에 현재 시간을 표시  
- 주문 시간과 주문 목록이 표시
- MQTT 클라이언트 구독, 메시지 수신 이벤트를 통해 화면 갱신 (주문 키오스크로부터 메시지 수신)      
![image](https://user-images.githubusercontent.com/77951828/130383783-d6cb2f5f-8276-4628-9369-4ac62ab31153.png)   

- 조리가 완료된 음식을 서빙 로봇에 올리고 해당 테이블을 클릭하면 자동으로 서빙 
- 서빙 시작 신호 시 MQTT 메시지 발행 (서빙 로봇에서 메시지를 수신)     
![image](https://user-images.githubusercontent.com/77951828/130384005-89afbad4-4b27-4249-a37f-6173ff683a62.png)    
 
- 테이블 사용 완료 여부 설정   
- 테이블을 즉시 사용 가능 상태로 전환, 키오스크에 사용 가능 표시   
![image](https://user-images.githubusercontent.com/77951828/130384178-7f36bdbe-2e2c-491f-9931-cc5337614436.png)

## 메뉴 관리 화면 
- 메뉴 테이블로부터 전체 메뉴 리스트 출력 
![image](https://user-images.githubusercontent.com/77951828/130384326-742eb85d-3198-4fe5-a796-9b6e28b26e7e.png)   

- 클릭 이벤트 발생시 메뉴 활성/비활성 여부 전환 
![image](https://user-images.githubusercontent.com/77951828/130384389-7c575619-802c-44e6-a815-1f3754b65498.png)   

- 메뉴 비활성시 주문용 키오스크에는 메뉴가 표시되지 않음 
