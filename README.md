# [2D게임] <쿠키런:오븐브레이크> 모작
</br>

## :memo: 목차

- [프로젝트 개요](#프로젝트-개요)
- [핵심 기술 구현](#핵심-기술-구현)
- [게임 내 활용 디자인패턴](#게임-내-활용-디자인패턴)
- [시연 영상](#시연-영상)
- [회고록](#회고록)
- [참고자료](#참고자료)

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

### :ballot_box_with_check: UGUI 동적 구현
* EventManager를 활용한 UI 버튼 동적 이벤트 시스템 구축
* JSON을 활용한 DB 연동으로 UI 동적 구현
  - '내쿠키함' 내 쿠키 scroll view 동적 구현
  - 쿠키 ID를 key로 활용하여 선택 쿠키 및 보유 쿠키 등 쿠키 관리
### :ballot_box_with_check: Sprite Atlas 활용
### :ballot_box_with_check: SoundManager를 활용한 전체 사운드 관리
* Singleton으로 구현한 SoundManager로 적재적소에 필요한 BGM 및 효과음 출력
### :ballot_box_with_check: 파티클 시스템
* LOBBY에 있는 선택된 쿠키용 하트 파티클 효과
* 결과창의 컨페티 효과

</br>

# 게임 내 활용 디자인패턴
### :ballot_box_with_check: Singleton(싱글톤)
### :ballot_box_with_check: StatePattern(상태패턴)

</br>

# 기술 설명 PPT
- 링크:

</br>

# 시연 영상
- 영상 링크: https://www.youtube.com/watch?v=wNj_AiQ3rXE

</br>

# 회고록

</br>

## 참고자료
