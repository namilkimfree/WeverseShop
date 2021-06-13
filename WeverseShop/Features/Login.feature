Feature: Login
	just user login

Scenario: weverse user login
	Given my tab click in main activity
	When with email click
	And input the email 'benx.auto.interview@gmail.com'
	And next button click 
	And input the password 'benxQAaut0*'
	And login click
	Then check login id 'benx.auto.interview@gmail.com'