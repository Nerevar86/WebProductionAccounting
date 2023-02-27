// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//$('.menu-btn').on('click', function (e) {
//    e.preventDefault();
//    $(this).toggleClass('menu-btn_active');
//    $('.menu-nav').toggleClass('menu-nav_active');
//});

//animation body
VANTA.CELLS({
    el: "#intro",
    mouseControls: true,
    touchControls: true,
    gyroControls: false,
    minHeight: 200.00,
    minWidth: 200.00,
    scale: 1.00,
    color1: 0x0,
    color2: 0xb617ff,
    speed: 1.50
})

//animation logo
anime({
  targets: '.line-drawing-demo .lines path',
  strokeDashoffset: [anime.setDashoffset, 0],
  easing: 'easeInOutSine',
  duration: 1500,
  delay: function(el, i) { return i * 1250 },
  direction: 'alternate',
  loop: true
});

//animation btn
//anime({
//    targets: '.button_hola .btn-anim-ico path',
//    strokeDashoffset: [anime.setDashoffset, 0],
//    easing: 'easeInOutSine',
//    duration: 1500,
//    delay: function (el, i) { return i * 1250 },
//    direction: 'alternate',
//    loop: true
//});

// row
var trs = document.querySelectorAll("tbody tr");
var thead = document.getElementById("tr-hover");

for (var i = 0; i < trs.length; i++) {
    MakeRowHover(trs[i]);
//    //SelectRow(trs[i]);
}

function MakeRowHover(row) {
    row.addEventListener("mouseover", function () {
        //this.style.backgroundColor = 'rgb(0,0,0,0.5)';
        this.classList.add('background-color-tr-hover');
    });
    row.addEventListener("mouseout", function () {
        //this.style.backgroundColor = "";
        this.classList.remove('background-color-tr-hover');
    });
   
}

//function SelectRow(row) {
//    //row click
//    row.addEventListener('click', function () {
//        if (!this.classList.contains('tr-selected')) {
//            this.classList.add('tr-selected');
//        } else {
//            this.classList.remove('tr-selected');
//        }
//    });
//}


//$('.select2').select2({
//    //theme: 'bootstrap-5',
//    closeOnSelect: false
//});


