(function($) { 
	"use strict";  

	/*Preloader js */
		$('.preloader_wrap').delay(400).fadeOut('slow');
		$('.preloader').delay(350).fadeOut('slow'); 
	
	// Active Slick Nav 
	$(window).on('scroll', function () {
		if ($(this).scrollTop() > 100) {
			$('#header-area').addClass('sticky');
		} else {
			$('#header-area').removeClass('sticky');
		}
	});
		
		
	jQuery(document).ready(function($) {
					
		/*Mobile Menu Js Start*/
		$(".main-menu").meanmenu({
			meanMenuContainer: ".mobile-menu",
			meanScreenWidth: "1199",
			meanExpand: ['<i class="far fa-plus"></i>'],
		});

		// Sidebar Toggle Js Start //
		$(".offcanvas__close,.offcanvas__overlay").on("click", function () {
			$(".offcanvas__info").removeClass("info-open");
			$(".offcanvas__overlay").removeClass("overlay-open");
		});
		$(".sidebar__toggle").on("click", function () {
			$(".offcanvas__info").addClass("info-open");
			$(".offcanvas__overlay").addClass("overlay-open");
		});

		/*Counter */
		$('.counter_up').on('inview', function(event, visible, visiblePartX, visiblePartY) {
			if (visible) {
				$(this).find('span.count').each(function () {
					var $this = $(this);
					$({ Counter: 0 }).animate({ Counter: $this.text() }, {
						duration: 2000,
						easing: 'swing',
						step: function () {
							$this.text(Math.ceil(this.Counter));
						}
					});
				});
				$(this).unbind('inview');
			}
		});				
	});		

	// TR Slider
	const tr_slider = new Swiper('.tr_slider', {
		// Optional parameters
		slidesPerView: 1,
		spaceBetween: 30,
		loop: true,
		// Navigation arrows
		navigation: {
			nextEl: '.hs_next_arrow',
			prevEl: '.hs_prev_arrow',		
		},
		pagination: {
			el: ".hero_pagination",
			clickable: true,
		},
		effect: "fade",
		breakpoints: {
			1299: {
				slidesPerView: 1,
			},
			1199: {
				slidesPerView: 1,
			},					
			1024: {
				slidesPerView: 1,
			},
			991: {
				slidesPerView: 1,
			},			

			767: {
				slidesPerView: 1,
			},
			575: {
				slidesPerView: 1,
			},
			0: {
				slidesPerView: 1,
			},
		},
	});
	
	$('#tr_dpicker1, #tr_dpicker2').datepicker();

	//Category
	$('.trcategory_slider').owlCarousel({
		loop: true,
		item:6,
		margin: 25,
		navText: ["<i class='ph ph-arrow-left'></i>" ,"<i class='ph ph-arrow-right'></i>"],
		nav: true,
		dots: false,
		responsive: {
			0: {
				items: 1,
				nav: false,
			},			
			440: {
				items: 2,
				nav: false,
			},
			768: {
				items: 3
			},
			992: {
				items: 4
			},			
			1199: {
				items: 6
			}
		}
	});	
	
	// Testimonials
	const test_slider = new Swiper('.test_slider', {
		// Optional parameters
		slidesPerView: 1,
		spaceBetween: 30,
		loop: true,
		// Navigation arrows
		navigation: {
			nextEl: '.tarrow_right',
			prevEl: '.tarrow_left',		
		},

		effect: "slide",
		breakpoints: {
			1299: {
				slidesPerView: 1,
			},
			1199: {
				slidesPerView: 1,
			},					
			1024: {
				slidesPerView: 1,
			},
			991: {
				slidesPerView: 1,
			},			

			767: {
				slidesPerView: 1,
			},
			575: {
				slidesPerView: 1,
			},
			0: {
				slidesPerView: 1,
			},
		},
	});
	
	//Clients
	$('.clients_slider').owlCarousel({
		loop: true,
		item:6,
		margin: 100,
		navText: ["<i class='ph ph-arrow-up-left'></i>" ,"<i class='ph ph-arrow-up-right'></i>"],
		nav: false,
		dots: false,
		responsive: {
			0: {
				items: 1
			},			
			440: {
				items: 3
			},
			768: {
				items: 4
			},
			992: {
				items: 5
			},			
			1199: {
				items: 6
			}
		}
	});

	/* WOW */
	new WOW().init();
	
}(jQuery));


