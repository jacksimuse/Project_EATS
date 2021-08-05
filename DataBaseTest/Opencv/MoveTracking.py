## 움직임 인식
# 현재 불러온 프레임과, 이전 프레임 사이의 RGB 또는 GRAY스케일 값을 비교

import cv2
import numpy as np

thresh = 25     # 움직임을 정의할 유의미한 픽셀 차이값
max_diff = 5    # 다른 픽셀이 5개 이상이면 움직임이 있다

a, b, c = None, None, None  # 프레임 3개로 움직임 인식

cap = cv2.VideoCapture(0)   # 기본 카메라
cap.set(cv2.CAP_PROP_FRAME_HEIGHT, 320) # 카메라 세팅
cap.set(cv2.CAP_PROP_FRAME_WIDTH, 480)

if cap.isOpened():
    ret, a  = cap.read()    # 첫번째 프레임
    ret, b  = cap.read()    # 두번째 프레임

    while ret:
        ret, c = cap.read() # 현재 프레임
        draw = c.copy()     # 프레임을 복사
        if not ret: # 현재 프레임이 존재하지 않으면
            break
            
        # 그레이 스케일로 변환
        a_gray = cv2.cvtColor(a, cv2.COLOR_BGR2GRAY)
        b_gray = cv2.cvtColor(b, cv2.COLOR_BGR2GRAY)
        c_gray = cv2.cvtColor(c, cv2.COLOR_BGR2GRAY)    

        diff1 = cv2.absdiff(a_gray, b_gray) # a, b 프레임의 차이값
        diff2 = cv2.absdiff(b_gray, c_gray) # b, c 프레임의 차이값

        # 이미지 이진화 - 스레스홀딩
        # ret : 스레스홀딩에 사용한 임계값
        # diff_t : 스레스홀딩된 바이너리 이미지
        ret, diff1_t = cv2.threshold(diff1, thresh, 255, cv2.THRESH_BINARY)
        ret, diff2_t = cv2.threshold(diff2, thresh, 255, cv2.THRESH_BINARY)

        # 두 그림에서 모두 차이점이 있으면 표시됨
        diff = cv2.bitwise_and(diff1_t, diff2_t)

        # 이미지 형태학적 변환(morphological Transformation)
        k = cv2.getStructuringElement(cv2.MORPH_CROSS, (3,3))   # 구조화 요소 커널 생성
        diff = cv2.morphologyEx(diff, cv2.MORPH_OPEN, k)      # opening 연산(침식후 팽창)

        diff_cnt = cv2.countNonZero(diff)   # 검은색이 아닌 픽셀의 개수
        if diff_cnt > max_diff:
            nzero = np.nonzero(diff)    # a, b 프레임의 차이 어레이
            cv2.rectangle(draw, 
                        (min(nzero[1]), min(nzero[0])), # pt1 : diff에서 0이 아닌 값 중 행, 열이 가장 작은 포인트
                        (max(nzero[1]), max(nzero[0])), # pt2 : diff에서 0이 아닌 값 중 행, 열이 가장 큰 포인트
                        (0, 255, 0),                    # 사각형을 그릴 색상 값
                        2)                              # 선 두께
            
            cv2.putText(b, "Motion detected!!", (10, 30),
                        cv2.FONT_HERSHEY_DUPLEX, 0.5, (0, 0, 255))

        # 두 프레임을 합침
        stacked = np.hstack((draw, cv2.cvtColor(diff, cv2.COLOR_GRAY2BGR))) 
        cv2.imshow('motion', stacked)

        a = b
        b = c

        if cv2.waitKey(1) & 0xFF == 27:
            break
