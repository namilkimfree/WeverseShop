# WeverseShop
WeverseShop 


#Folder Structure
----Base
Parent: Base(Manager 관련 변수)
Child: TestStep(CurrnetPage 변수), BasePage(PageFactory 사용)


----Config
ConfigBinder: Config, Appium 인스턴스화 및 싱글턴 service 보관
GlobalConfig: appium 설정 관련 json 파싱

----Features
*.feature: 자연어 기반 테스트 케이스 

----Steps
*.step: TestFixture, feature의 각 Test Step 별 Test 구현

----Hooks
HookInitialize: BeforeTestRun, AfterTestRun (appium server 실행, driver 실행, 드라이버 및 서버 종료)

----Pages
WeverseShop 스크린 별로 PageClass 생성

----Model
Data Model

----Manager
AppiumHelper: AppiumDriver의 (Scroll, WaitHelper) 구현
AppiumManager: Driver 실행, Server 실행 등 구현
AppiumService: Appium Server 실행, 종료 


