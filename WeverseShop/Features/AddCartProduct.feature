Feature: AddCartProduct
	

Scenario: Add to cart for products in category
	Given click cateogry 'TinyTAN'
	When click any product
	And add to cart for product
	And add to cart click
	When click move to cart after open popup 
	Then check the items added to the shopping cart