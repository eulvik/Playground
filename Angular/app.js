(function() {
	var app = angular.module('store', []);

	app.controller('StoreController', function() {
		this.products = gems;
	});

	app.controller('PanelController', function() {
		this.tab = 1;

		this.selectTab = function(setTab) {
			this.tab = setTab;
		};

		this.isSelected = function(checkTab) {
			return this.tab === checkTab;
		};
	});

	app.controller('ReviewController', function() {
		this.review = {};

		this.addReview = function(product) {
			product.reviews.push(this.review)
			this.review = {};
		};
	});

	var gems = [{
		name: 'Dodecahedron',
		price: 2,
		description: 'Some stuff in here',
		canPurchase: true,
		soldOut: false,
		reviews: [{
			stars: 1,
			body: 'Some shit here',
			author: "eiu@teleplan.no"
		}]
	}, {
		name: 'Pentagonal Fem',
		price: 5.95,
		description: 'Some other stuff in here',
		canPurchase: false,
		soldOut: false,
	}];
})();
