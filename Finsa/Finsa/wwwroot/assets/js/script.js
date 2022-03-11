
$('.testimonial-slider').owlCarousel({
    loop:true,
    margin:10,
    nav:true,
    dots: false,
    autoplay: true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:1
        },
        1000:{
            items:1
        }
    }
});

$('.homebanner-slider').owlCarousel({
  loop:true,
  nav:false,
  dots: false,
  autoplay: true,
  responsive:{
      0:{
          items:1
      },
      600:{
          items:1
      },
      1000:{
          items:1
      }
  }
});

$('.featuredbyslider').owlCarousel({
    loop:true,
    margin:50,
    nav:false,
    dots:false,
    autoplay:true,
    responsive:{
        0:{
            items:2
        },
        768:{
            items:3
        },
        992:{
            items:5
        }
    }
  });

let pagetop = document.querySelector(".back-to-top");
pagetop.addEventListener("click", () => {
  window.scrollTo(0, 0);
});

window.addEventListener("scroll", (e) => {
    if (window.pageYOffset > 200) {
      document.getElementById("nav-all").classList.add("active"); 
     } 
     else if(window.pageYOffset == 0){
        document.getElementById("nav-all").classList.remove("active");
      }
  });


let accordionclick = document.querySelectorAll(".gettoknow-accordion ul li a")
let accordionicon = document.querySelectorAll(".gettoknow-accordion ul li a i")
let accordiontext = document.querySelectorAll(".gettoknow-accordion ul li")
for (let i = 0; i < accordionclick.length; i++) {
  accordionclick[i].addEventListener("click", e => {
    e.preventDefault();
    for (let j = 0; j < accordiontext.length; j++) {
      if (!accordiontext[i].classList.contains("accordion-active")) {
        accordiontext[j].classList.remove("accordion-active")
      }
      if (!accordionicon[i].classList.contains("fa-minus")) {
        accordionicon[j].classList.remove("fa-minus")
        accordionicon[j].classList.add("fa-plus")
      }
    }  
    accordiontext[i].classList.toggle("accordion-active");
    accordionicon[i].classList.toggle("fa-plus")
    accordionicon[i].classList.toggle("fa-minus")   
  })
};

$('#about-slider-2').owlCarousel({
  loop:true,
  dots: false,
  autoplay: true,
  nav:true,
  responsive:{
      0:{
        items:1
      },
      1000:{
          items:1
      }
  }
});



$(".youtube-link").grtyoutube({
    theme: "dark" // or dark
  });

  // $('.grid').isotope({

  //   // required
  //   itemSelector: '.grid-item',
  
  //   // fitRows
  //   // vertical
  //   // packery
  //   // cellsByRow
  //   // masonryHorizontal
  //   // fitColumns
  //   // cellsByColumn
  //   // horiz
  //   // masonry (default)
  //   layoutMode: 'masonry',
  
  //   // sets item positions in percent values, rather than pixel values.
  //   percentPosition: true,
  
  //   // stamp elements
  //   stamp: '.stamp',
  
  //   // the horizontal flow of the layout
  //   originLeft: true,
  
  //   // the vertical flow of the layout
  //   originTop: true,
  
  //   // filter function
  //   filter: null,
  
  //   // gets sort data
  //   getSortData: null,
  
  //   // sorts items according to which property of getSortData
  //   sortBy: 'number',
  
  //   // sorts items ascendingly 
  //   sortAscending: true,
  
  //   // staggers item transitions 30ms after one another
  //   stagger: 30,
  
  //   // transition in seconds
  //   transitionDuration: '0.4s',
  
  //   // disable any styles being set on container
  //   // useful if using absolute position on container
  //   containerStyle: null,
  
  //   // adjusts sizes and positions when window is resized
  //   resize: true
    
  // });

 // function projectIsotope() {
	//	var items = $('.project-isotope').isotope({
	//		itemSelector: '.isotope-item',
	//		percentPosition: true,
	//		masonry: {
	//			columnWidth: '.isotope-item',
	//		},
	//	});
	//	// items on button click
	//	$('.project-isotope-filter').on('click', 'li', function () {
	//		var filterValue = $(this).attr('data-filter');
	//		items.isotope({
	//			filter: filterValue
	//		});
	//	});
	//	// menu active class
	//	$('.project-isotope-filter li').on('click', function (event) {
	//		$(this).siblings('.active').removeClass('active');
	//		$(this).addClass('active');
	//		event.preventDefault();
	//	});
	//}

  function preloader() {
		if ($('#preloader').length) {
			$('#preloader').delay(100).fadeOut(500);      
      // document.getElementById("preloader").style.display = "none";
		}
	};

 // $(document).ready(function () {
	//	projectIsotope()
	//});
  $(window).on('load', function () {
		preloader();
	});

  let rnavbar = document.getElementsByClassName("navbar-responsive-pages")[0];
  let clicknav = document.getElementsByClassName("navbar-toggle")[0];
  let closebtn = document.getElementsByClassName("navbar-close")[0];

  clicknav.addEventListener("click", (e) => {
    e.preventDefault();
    rnavbar.classList.toggle("active");
    clicknav.classList.toggle("active");
  });
  closebtn.addEventListener("click", (e) => {
    e.preventDefault();
      rnavbar.classList.remove("active");
      clicknav.classList.remove("active");
  });



$(document).ready(function () {
    let submit = $("#sec-btn");
    let email = $("#subscribies input[name='email']");

    submit.click(function (e) {
        e.preventDefault();
        let isEmailTrue = function isEmail(email) {
            return /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$/i.test(email);
        }
        if (true) {
            $.ajax({
                url: "/Home/Subscribe",
                type: "get",
                dataType: "json",
                data: {
                    email: email.val()
                },
                success: function (response) {
                    console.log(response)
                    if (response.status1) {

                        swal("Good job!", "Thanks for subscribing!", "success");
                        $("#subscribies input[name='email']")[0].value = "";
                    }
                    else if (!response.status1 && !response.status2) {

                        swal("Hmmm!", "You are already subscribed!", "info");
                        $("#subscribies input[name='email']")[0].value = "";
                    }

                    if (response.status2) {

                    }
                },
                error: function (error) {
                    swal("Errrror!", "Warninng", "error");
                    $("#subscribies input[name='email']")[0].value = "";
                },
                complete: function () {

                }
            });
        } else {
            swal("Errooor!", "Please, write correct mail", "error");
            $("#subscribies input[name='email']")[0].value = "";
        }
    });
});