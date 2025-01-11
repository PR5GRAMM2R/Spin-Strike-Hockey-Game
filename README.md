# Spin Strike Hockey Game

Strike Hockey Game 이며, 플레이어에 초록색과 빨간색 구역을 나누어 각 구역마다 튕겨나가는 힘이 다른 특성을 부여하였다.
( Unity 와 C# 으로 제작 )

![README_Image01](https://github.com/user-attachments/assets/1410b678-e120-4c38-ad24-f07225870990)



## 맴버 구성 및 역할

최세인 : 게임의 시작화면 제작, 게임 결과 공유 및 멀티플레이를 위한 네트워크 구성

배주환 : 게임 진행 화면 디자인, 게임 진행 구성, 게임 알고리즘 구현


## 게임의 규칙

1. 150 초 동안 게임이 진행된다
2. 공이 벽을 튕긴 횟수만큼 점수가 누적되며(분홍색 숫자), 골을 넣은 플레이어는 누적된 해당 점수를 가져간다.
3. 플레이어는 일정 방향, 속도로 회전하며, 초록색 부위는 공을 잘 튕겨내고 빨간색 부위는 공을 잘 튕겨내지 못한다.
4. 게임이 종료되면 최종 점수(하얀색 숫자)가 높은 쪽이 승리한다.
