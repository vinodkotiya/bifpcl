<%@ Page Language="VB" AutoEventWireup="false" CodeFile="quiz.aspx.vb" Inherits="_quiz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!-- The above 4 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <!-- Title -->
     <title>BIFPCL</title>
    <meta name="description" content="BIFPCL Official Website" />
    <meta name="author" content="Vinod Kotiya" />
    <meta name="keywords" content="NTPC, BIFPCL, Maitree Thermal Power Project, Khulna, Bangladesh India Friendship Power Corporation Limited" />
    <link href='favicon.ico' rel='icon' type='image/x-icon'/>
 

    <!-- Favicon -->


    <!-- Core Stylesheet -->
    <link href="customHome/style.css" rel="stylesheet" />

    <!-- Responsive CSS -->
    <link href="customHome/css/responsive.css" rel="stylesheet" />

      <!-- Flying Bird Pure CSS with Divs-->
    <link href="customHome/css/flybird.css" rel="stylesheet" />

    <style>
        .navbar-nav li:hover > ul.dropdown-menu {
    display: block;
      margin-top: -20px;
     
      background-color:#6610f2;
}
.dropdown-submenu {
    position:relative;
   color:white!important;
}
.dropdown-submenu>.dropdown-menu {
    top:0;
    left:100%;
    margin-top:-6px;
    background-color:#6610f2;
}

/* rotate caret on hover */
.dropdown-menu > li > a:hover:after {
    text-decoration: underline;
    transform: rotate(-90deg);
    background-color:#6610f2;
} 

    </style>
</head>
<body>
    <form id="form1" runat="server">
       <!-- Preloader Start -->
    <div id="preloader">
        <div class="colorlib-load"></div>
    </div>

    
    <!-- ***** Wellcome Area Start ***** -->
    <section class="wellcome_area clearfix" id="home">
      
        <div class="container h-100" style="overflow:hidden;position: relative;">
            <%--  <div class="birdcontainer">--%>
              <div class="bird-container bird-container--one">
      <div class="bird bird--one"></div>
    </div>
    <div class="bird-container bird-container--two">
      <div class="bird bird--two"></div>
    </div>
    <div class="bird-container bird-container--three">
      <div class="bird bird--three"></div>
    </div>
    <div class="bird-container bird-container--four">
      <div class="bird bird--four"></div>
    </div> 
            <div class="row h-100 align-items-center">
                <div class="col-12 col-md">
                    <div class="wellcome-heading" style="margin-bottom: 200px;">
                        <h2>BIFPCL</h2>
                        <h3>&#9055;</h3>
                        <p>Bangladesh India Friendship Power Company (P) Ltd</p>
                        <div class="get-start-area">
                        <!-- Form Start -->
                      <%--  <form action="#" method="post" class="form-inline">
                            <input type="email" class="form-control email" placeholder="name@company.com">
                      --%>    <a  href="#start"  class="submit" >Start Quiz</a>   <br /><br /><br /><br /><br /><br />
                       <%-- </form>--%>
                        <!-- Form End -->
                    </div>
                    </div>
                    
                </div>
            </div>
                 <%-- </div>--%>
        </div>
        <!-- Welcome thumb -->
        <div class="welcome-thumb wow fadeInDown" style="bottom:200px" data-wow-delay="0.5s">
            <img src="customHome/img/bg-img/welcome-img.png" alt="">
        </div>
    </section>
    <!-- ***** Wellcome Area End ***** -->
        <a name="start" />
    <!-- ***** Special Area Start ***** -->
    <section class="special-area bg-white section_padding_100" id="about">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <!-- Section Heading Area --> 
                    <div class="section-heading text-center">
                     <h2>Interactive Quiz</h2>
                        <div class="line-shape"></div>
                    </div>
                      <a name="start" /> 
                </div>
            </div>

            <div class="row">
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                <!-- Single Special Area -->
                <div class="col-12">
                 <div class="spacer"></div>

<div id="navContent">

<div id="game1"></div>
<div id="game2"></div>
</div>
                </div>
              
            </div>
        </div>
   

    <!-- ***** Footer Area Start ***** -->
    <footer class="footer-social-icon text-center section_padding_70 clearfix">
        <!-- footer logo -->
        <div class="footer-text">
           <img src="images/icon/logo5.png" alt="BIFPCL Logo" />
        </div>
        <!-- social icon-->
        <div class="footer-social-icon">
            <a href="http://www.chiptune.com/kaleidoscope/index.html"><i class="fa fa-facebook" aria-hidden="true"></i></a>
            <a href="https://codepen.io/gxash/pen/YqmxWg"><i class="active fa fa-twitter" aria-hidden="true"></i></a>
            <a href="https://codepen.io/jjperezaguinaga/pen/yuBdq"> <i class="fa fa-instagram" aria-hidden="true"></i></a>
            <a href="#"><i class="fa fa-google-plus" aria-hidden="true"></i></a>
        </div>
        <div class="footer-menu">
            <nav>
                <ul>
                    <li><a href="#">About</a></li>
                    <li><a href="#">Terms &amp; Conditions</a></li>
                    <li><a href="#">Privacy Policy</a></li>
                    <li><a href="#">Contact</a></li>
                </ul>
            </nav>
        </div>
        <!-- Foooter Text-->
        <div class="copyright-text">
            <p>Copyright ©2018 Website Designed and Maintained by <a href="www.bifpcl.com" target="_blank">BIFPCL IT</a></p>
        </div>
    </footer>
    <!-- ***** Footer Area Start ***** -->

  
    </form>
      <!-- Jquery-2.2.4 JS -->
    <script src="customHome/js/jquery-2.2.4.min.js"></script>
    <!-- Popper js -->
    <script src="customHome/js/popper.min.js"></script>
    <!-- Bootstrap-4 Beta JS -->
    <script src="customHome/js/bootstrap.min.js"></script>
    <!-- All Plugins JS -->
    <script src="customHome/js/plugins.js"></script>
    <!-- Slick Slider Js-->
    <script src="customHome/js/slick.min.js"></script>
    <!-- Footer Reveal JS -->
    <script src="customHome/js/footer-reveal.min.js"></script>
    <!-- Active JS -->
    <script src="customHome/js/active.js"></script>
    <link href="pages/quiz/main.css"rel="stylesheet"type="text/css"/>
 <%--  <script src="pages/quiz/jquery.js"></script>
    <script src="pages/quiz/controller.js"></script>--%>
    <script>
        $(document).ready(function () {
	
var questionNumber=0;
var questionBank=new Array();
var stage="#game1";
var stage2=new Object;
var questionLock=false;
var numberOfQuestions;
var score=0;
		 

		 
		 
		 

 
    $.getJSON('pages/quiz/activity.json', function(data) {

		for(i=0;i<data.quizlist.length;i++){ 
			questionBank[i]=new Array;
			questionBank[i][0]=data.quizlist[i].q;
			questionBank[i][1]=data.quizlist[i].a;
			questionBank[i][2]=data.quizlist[i].b;
            questionBank[i][3] = data.quizlist[i].c;
            questionBank[i][4] = data.quizlist[i].d;
              questionBank[i][5]=data.quizlist[i].ans;
		}
		 numberOfQuestions=questionBank.length; 
		
		 
		displayQuestion();
		})//gtjson
 
 



function displayQuestion(){
 var rnd=Math.random()*4;
rnd=Math.ceil(rnd);
 var q1;
 var q2;
 var q3;
    var q4;
//if(rnd==1){q1=questionBank[questionNumber][1];q2=questionBank[questionNumber][2];q3=questionBank[questionNumber][3];q4=questionBank[questionNumber][4];}
//if(rnd==2){q2=questionBank[questionNumber][1];q3=questionBank[questionNumber][2];q4=questionBank[questionNumber][3];q1=questionBank[questionNumber][4];}
//    if (rnd == 3) { q3 = questionBank[questionNumber][1]; q4 = questionBank[questionNumber][2]; q1 = questionBank[questionNumber][3];q2=questionBank[questionNumber][4]; }
//      if (rnd == 4) { q4 = questionBank[questionNumber][1]; q1 = questionBank[questionNumber][2]; q2 = questionBank[questionNumber][3];q3=questionBank[questionNumber][4]; }
    q1 = questionBank[questionNumber][1];
    q2 = questionBank[questionNumber][2];
    q3 = questionBank[questionNumber][3];
    q4=questionBank[questionNumber][4];
    var ans = questionBank[questionNumber][5];
$(stage).append('<div class="questionText" >'+questionBank[questionNumber][0]+'</div><div id="A" class="option">'+q1+'</div><div id="B" class="option">'+q2+'</div><div id="C" class="option">'+q3+'</div><div id="D" class="option">'+q4+'</div>');

 $('.option').click(function(){
  if(questionLock==false){questionLock=true;	
  //correct answer
  if(this.id==ans){
   $(stage).append('<div class="feedback1"><img src=pages/quiz/correct.gif />CORRECT</div>');
   score++;
   }
  //wrong answer	
  if(this.id!=ans){
   $(stage).append('<div class="feedback2"><img src=pages/quiz/wrong.gif />WRONG</div>');
  }
  setTimeout(function(){changeQuestion()},1000);
 }})
}//display question

	
	
	
	
	
	function changeQuestion(){
		
		questionNumber++;
	
	if(stage=="#game1"){stage2="#game1";stage="#game2";}
		else{stage2="#game2";stage="#game1";}
	
	if(questionNumber<numberOfQuestions){displayQuestion();}else{displayFinalSlide();}
	
	 $(stage2).animate({"right": "+=800px"},"slow", function() {$(stage2).css('right','-800px');$(stage2).empty();});
	 $(stage).animate({"right": "+=800px"},"slow", function() {questionLock=false;});
	}//change question
	

	
	
	function displayFinalSlide(){
		
		$(stage).append('<div class="questionText">You have finished the quiz!<a href=quiz.aspx>Click here to restart</a><br><br>Total questions: '+numberOfQuestions+'<br>Correct answers: '+score+'<br/><br/><img src=pages/quiz/GameOver.gif /></div>');
		
	}//display final slide
	
	
	
	
	
	
	
	});//doc ready
    </script>
</body>
</html>
