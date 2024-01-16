# [2D게임] <쿠키런:오븐브레이크> 모작
</br>

## :memo: 목차

- [프로젝트 개요](#프로젝트-개요)
- [핵심 기술 구현](#핵심-기술-구현)
- [게임 내 활용 디자인패턴](#게임-내-활용-디자인패턴)
- [시연 영상](#시연-영상)

</br>

# 프로젝트 개요

|제목|<쿠키런: 오븐브레이크> 모작|
|:------:|---|
|장르|사이드 스크롤 러닝 액션 게임|
|개발 기간|3주|
|개발 도구|Unity (2022.3.2f1)|
|사용 언어|C#|
|플랫폼|모바일|
|팀원|4명|
|모작 목표| - 모바일 맞춤 UGUI 최적화 게임의 구현 <br> - State Pattern 구현 <br> ㄴ '쿠키런 캐릭터의 다양한 상태 전이(달리기, 점프, 슬라이드, 보너스 타임 등) 구현의 단순화 <br> ㄴ 쿠키별 상태 추가의 확장성 부여

</br>

# 핵심 기술 구현

![Honeycam 2023-09-07 15-24-48](https://github.com/eun457/Team_CookieRun2D/assets/140386045/8ba1dc78-3158-4e0b-9ee1-042c93eebdef)
### :ballot_box_with_check: UGUI 동적 구현
* EventManager를 활용한 UI 버튼 동적 이벤트 시스템 구축
* JSON을 활용한 DB 연동으로 UI 동적 구현
  - '내쿠키함' 내 쿠키 scroll view 동적 구현
  - 쿠키 ID를 key로 활용하여 선택 쿠키 및 보유 쿠키 등 쿠키 관리

![Untitled](https://github.com/eun457/Team_CookieRun2D/assets/140386045/26f15a3a-fd11-42e5-b256-7707046cae54)

### :ballot_box_with_check: Sprite Atlas 활용
* 다양한 Sprite의 쿠키가 필요한 게임 특성에 맞춰, 쿠키 Sprite를 Atlas로 관리하여 성능 최적화 도모
  
### :ballot_box_with_check: SoundManager를 활용한 전체 사운드 관리
* Singleton으로 구현한 SoundManager로 게임 전체의 사운드를 관리
* AudioSource를 BGM/Effect를 따로 생성하여 개별 조작
  
### :ballot_box_with_check: 파티클 시스템
* 결과창의 컨페티 효과
* LOBBY에 있는 선택된 쿠키용 하트 파티클 효과
![Honeycam 2023-09-07 15-17-33](https://github.com/eun457/Team_CookieRun2D/assets/140386045/56528dd1-35ce-4004-8e98-0d5c13cab0b8)
![Honeycam 2023-09-07 15-16-03](https://github.com/eun457/Team_CookieRun2D/assets/140386045/ab8cc65d-75e9-4601-9735-0d50ff6d2ca8)


</br>

# 게임 내 활용 디자인패턴
### :ballot_box_with_check: Singleton(싱글톤)
- 모든 씬에서 사용되는 Resources들을 SingletonManager를 통해 관리
  - 한 개의 인스턴스만을 고정 메모리에 생성하고 추가 생성하지 않아 추후 해당 메모리에 접근할 때 메모리 낭비를 방지함
  - 중복 코드를 줄이고 유지 보수를 용이하게 함

### :ballot_box_with_check: State Pattern(상태패턴)
- Idle, Jump, DoubleJump, Dash, Hit 등 기존 상태에서 다른 상태로 분기되는 동작이 많은 게임 특성에 맞춰 State Pattern 활용
  - player.cs, playerState.cs, playerStateMachine.cs를 직접 구현하여 Unity의 statemachineBehaviour의 흐름 이해
  - State Pattern을 적용하여 Player의 상태에 따른 기능들을 구현하기 보다 용이함


</br>

# 시연 영상
- 영상 링크: https://www.youtube.com/watch?v=wNj_AiQ3rXE
