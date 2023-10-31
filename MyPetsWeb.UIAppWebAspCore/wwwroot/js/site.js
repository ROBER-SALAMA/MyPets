// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*Paginacion en la tablas */
//(function () {
//    var domPaginacion = document.querySelectorAll('.paginationjs');
//    if (domPaginacion.length > 0) {
//        var mostrarPaginacion = function (pNumPage) {
//            $("table.paginationjs tbody tr[data-page]").hide();
//            $("table.paginationjs tbody tr[data-page='" + pNumPage + "']").show();
//            $("ul.paginationjs").attr("data-pageactive", pNumPage);
//            $("ul.paginationjs li[data-typepage='Item']").removeClass("active");
//            $("ul.paginationjs li[data-typepage='Item'][data-page='" + pNumPage + "']").addClass("active");
//        }
//        mostrarPaginacion(1);
//        $("ul.paginationjs .page-item").click(function () {
//            if ($(this).attr("data-typepage") == "Item") {
//                var page = parseInt($(this).attr("data-page"));
//                if (isNaN(page)) {
//                    page = 1;
//                }
//                mostrarPaginacion(page);
//            }
//            else {
//                var pageActivo = parseInt($("ul.paginationjs").attr("data-pageactive"));
//                if (isNaN(pageActivo)) {
//                    pageActivo = 1;
//                }
//                var numPage = parseInt($("ul.paginationjs").attr("data-numpage"));
//                if (isNaN(numPage)) {
//                    numPage = 1;
//                }
//                if ($(this).attr("data-typepage") == "Previous") {
//                    if (pageActivo > 1) {
//                        var page = pageActivo - 1;
//                        mostrarPaginacion(page);
//                    }
//                }
//                else if ($(this).attr("data-typepage") == "Next") {
//                    if (pageActivo < numPage) {
//                        var page = pageActivo + 1;
//                        mostrarPaginacion(page);
//                    }
//                }
//            }
//        });
//    }
//})();


document.addEventListener("DOMContentLoaded", function(event) {
   
    const showNavbar = (toggleId, navId, bodyId, headerId) =>{
    const toggle = document.getElementById(toggleId),
    nav = document.getElementById(navId),
    bodypd = document.getElementById(bodyId),
    headerpd = document.getElementById(headerId)
    
    // Validate that all variables exist
    if(toggle && nav && bodypd && headerpd){
    toggle.addEventListener('click', ()=>{
    // show navbar
    nav.classList.toggle('show')
    // change icon
    toggle.classList.toggle('bx-x')
    // add padding to body
    bodypd.classList.toggle('body-pd')
    // add padding to header
    headerpd.classList.toggle('body-pd')
    })
    }
    }
    
    showNavbar('header-toggle','nav-bar','body-pd','header')
    
    /*===== LINK ACTIVE =====*/
    const linkColor = document.querySelectorAll('.nav_link')
    
    function colorLink(){
    if(linkColor){
    linkColor.forEach(l=> l.classList.remove('active'))
    this.classList.add('active')
    }
    }
    linkColor.forEach(l=> l.addEventListener('click', colorLink))
    
     // Your code to run since DOM is loaded and ready
    });
