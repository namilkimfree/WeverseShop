Feature: PermissionConfirm
	Confirm Permission.


Scenario: grant some permissions accept 
	Given loading permission activity
	And confirm permission
	When navigated language choice activity
	And '한국어' language click
	And next click
	When naviagted artist & shop choice activity
	And 'BTS' artist click
	And 'GLOBAL' shop click
	And confirm artist click
	When naviagted currency choice activity
	And '₩ (KRW) - 대한민국 원' currency click
	And confirm curreny click
	Then loaded shop activity




