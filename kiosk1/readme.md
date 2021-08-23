# 주문용 키오스크 (.NET Framework WPF 기반, RDBMS(MS-SQL) 연동, MQTT Protocol 활용 통신 기능) 

## 초기 화면
- 매장 내 사용 중인 테이블과 사용 가능한 테이블 표시 
![image](https://user-images.githubusercontent.com/77951828/130381657-972d4ffa-e78e-429f-8854-16ecf4a1dbe9.png)   

- 모든 테이블 만석 시 대기 문자 전송 화면과 (미구현) 테이블 별 추가 주문 기능 
![image](https://user-images.githubusercontent.com/77951828/130381765-d91a7eba-30b0-40d5-870c-eed00f61524c.png)


## 메뉴 선택 화면 
- DB에 저장된 메뉴를 카테고리 별로 표시   
- 선택한 메뉴를 주문 리스트에 추가   
- 결제창으로 이동 기능   
![image](https://user-images.githubusercontent.com/77951828/130381885-b09a4653-b982-42fe-aa40-2c98713aea11.png)

## 결제 화면 
- 이전 화면에서 선택한 주문 리스트 출력
- 결제할 가격 표시
- 결제 버튼을 누르면 MQTT Message를 주방용 UI에 전송   
- 주문 내역을 DB에 저장    
![image](https://user-images.githubusercontent.com/77951828/130382052-24b4748e-c6ef-4e59-a420-1ae4abf2b26f.png)

## 메시지 전송 내역 
- 전송 메시지 타입 : 직렬화된 Json 문자열 
- 메시지 타입, 주문 번호, 테이블 번호, 주문 시간    
- 메시지는 주방 UI로 전달되어 주문 여부를 확인할 수 있음   
![image](https://user-images.githubusercontent.com/77951828/130382317-565ddd41-8610-4afe-a2e6-79d7f7a00361.png)

## DB 연동 
- 1. 주문 내역    
- 주문코드 / 주문시간 / 테이블번호 / 결제 금액 / 테이블의 사용여부 / 특이사항   
![image](https://user-images.githubusercontent.com/77951828/130382639-cccded6c-a0aa-4685-b3c5-36c932d8bf05.png)
 
- 2. 주문 상세 내역   
- 주문코드 / 메뉴코드 (메뉴 테이블 Join으로 접근) / 수량 / 주문 완료여부    
![image](https://user-images.githubusercontent.com/77951828/130382741-ab51d064-6ed4-4d69-b7f1-4ccdf39ab66a.png)

