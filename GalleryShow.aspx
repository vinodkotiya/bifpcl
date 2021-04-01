﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GalleryShow.aspx.vb" Inherits="_GalleryShow" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BIFPCL</title>
     <!-- Required meta tags-->
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="BIFPCL Official Website" />
    <meta name="author" content="Vinod Kotiya" />
    <meta name="keywords" content="NTPC, BIFPCL, Maitree Thermal Power Project, Khulna, Bangladesh India Friendship Power Corporation Limited" />
    <link href='favicon.ico' rel='icon' type='image/x-icon'/>
 
    <!-- Fontfaces CSS-->
    <link href="css/font-face.css" rel="stylesheet" media="all" />
    <link href="vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all" />
    <link href="vendor/font-awesome-5/css/fontawesome-all.min.css" rel="stylesheet" media="all" />
    <link href="vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all" />

    <!-- Bootstrap CSS-->
    <link href="vendor/bootstrap-4.1/bootstrap.min.css" rel="stylesheet" media="all" />

    <!-- Vendor CSS-->
    <link href="vendor/animsition/animsition.min.css" rel="stylesheet" media="all" />
    <link href="vendor/bootstrap-progressbar/bootstrap-progressbar-3.3.4.min.css" rel="stylesheet" media="all" />
    <link href="vendor/wow/animate.css" rel="stylesheet" media="all" />
    <link href="vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" media="all" />
    <link href="vendor/slick/slick.css" rel="stylesheet" media="all" />
    <link href="vendor/select2/select2.min.css" rel="stylesheet" media="all" />
    <link href="vendor/perfect-scrollbar/perfect-scrollbar.css" rel="stylesheet" media="all" />

    <!-- Main CSS-->
    <link href="css/theme.css" rel="stylesheet" media="all" />

    <!-- Jquery JS-->
    <script src="vendor/jquery-3.2.1.min.js"></script>
     <%-- Highchart plugin--%>
        <%-- <script src="js/highcharts.js"></script>
<script src="js/highcharts-more.js"></script>
<script src="js/exporting.js"></script>--%>

   <%-- Image    Slider--%>
    <!-- #region Jssor Slider Begin -->
<!-- Generator: Jssor Slider Maker -->

<!-- This is deep minimized code which works independently. -->
<script type="text/javascript">
!function(h,i,m,g,e,k,f){new(function(){});var c={J:m.PI,A:m.max,D:m.min,cb:m.ceil,db:m.floor,Hb:m.abs,Jb:m.sin,Pb:m.cos,Td:m.tan,zf:m.atan,xc:m.sqrt,E:m.pow,Wd:m.random,z:m.round},d={uf:function(a){return-c.Pb(a*c.J)/2+.5},n:function(a){return a},H:function(a){return a*a},Zd:function(a){return-a*(a-2)},cd:function(a){return(a*=2)<1?1/2*a*a:-1/2*(--a*(a-2)-1)},Rb:function(a){return a*a*a},pf:function(a){return(a-=1)*a*a+1},ae:function(a){return(a*=2)<1?1/2*a*a*a:1/2*((a-=2)*a*a+2)},Mf:function(a){return a*a*a*a},hg:function(a){return-((a-=1)*a*a*a-1)},jb:function(a){return(a*=2)<1?1/2*a*a*a*a:-1/2*((a-=2)*a*a*a-2)},gg:function(a){return a*a*a*a*a},fg:function(a){return(a-=1)*a*a*a*a+1},eg:function(a){return(a*=2)<1?1/2*a*a*a*a*a:1/2*((a-=2)*a*a*a*a+2)},dg:function(a){return 1-c.Pb(c.J/2*a)},cg:function(a){return c.Jb(c.J/2*a)},ag:function(a){return-1/2*(c.Pb(c.J*a)-1)},Zf:function(a){return a==0?0:c.E(2,10*(a-1))},Yf:function(a){return a==1?1:-c.E(2,-10*a)+1},Wc:function(a){return a==0||a==1?a:(a*=2)<1?1/2*c.E(2,10*(a-1)):1/2*(-c.E(2,-10*--a)+2)},Vf:function(a){return-(c.xc(1-a*a)-1)},Uf:function(a){return c.xc(1-(a-=1)*a)},Sf:function(a){return(a*=2)<1?-1/2*(c.xc(1-a*a)-1):1/2*(c.xc(1-(a-=2)*a)+1)},Ug:function(a){if(!a||a==1)return a;var b=.3,d=.075;return-(c.E(2,10*(a-=1))*c.Jb((a-d)*2*c.J/b))},Kf:function(a){if(!a||a==1)return a;var b=.3,d=.075;return c.E(2,-10*a)*c.Jb((a-d)*2*c.J/b)+1},Nf:function(a){if(!a||a==1)return a;var b=.45,d=.1125;return(a*=2)<1?-.5*c.E(2,10*(a-=1))*c.Jb((a-d)*2*c.J/b):c.E(2,-10*(a-=1))*c.Jb((a-d)*2*c.J/b)*.5+1},Of:function(a){var b=1.70158;return a*a*((b+1)*a-b)},Pf:function(a){var b=1.70158;return(a-=1)*a*((b+1)*a+b)+1},Qf:function(a){var b=1.70158;return(a*=2)<1?1/2*a*a*(((b*=1.525)+1)*a-b):1/2*((a-=2)*a*(((b*=1.525)+1)*a+b)+2)},yd:function(a){return 1-d.wd(1-a)},wd:function(a){return a<1/2.75?7.5625*a*a:a<2/2.75?7.5625*(a-=1.5/2.75)*a+.75:a<2.5/2.75?7.5625*(a-=2.25/2.75)*a+.9375:7.5625*(a-=2.625/2.75)*a+.984375},Rf:function(a){return a<1/2?d.yd(a*2)*.5:d.wd(a*2-1)*.5+.5},zd:function(a){return 1-c.Pb(a*c.J*2)},Wf:c.cb,Xf:c.db};var b=new function(){var j=this,vb=/\S+/g,G=1,pb=2,sb=3,rb=4,Z=5,H,r=0,n=0,B=0,A=navigator,fb=A.appName,p=A.userAgent,q=parseFloat;function Eb(){if(!H){H={gd:"ontouchstart"in h||"createTouch"in i};var a;if(A.pointerEnabled||(a=A.msPointerEnabled))H.ie=a?"msTouchAction":"touchAction"}return H}function u(g){if(!r){r=-1;if(fb=="Microsoft Internet Explorer"&&!!h.attachEvent&&!!h.ActiveXObject){var e=p.indexOf("MSIE");r=G;n=q(p.substring(e+5,p.indexOf(";",e)));/*@cc_on@*/}else if(fb=="Netscape"&&!!h.addEventListener){var d=p.indexOf("Firefox"),b=p.indexOf("Safari"),f=p.indexOf("Chrome"),c=p.indexOf("AppleWebKit");if(d>=0){r=pb;n=q(p.substring(d+8))}else if(b>=0){var i=p.substring(0,b).lastIndexOf("/");r=f>=0?rb:sb;n=q(p.substring(i+1,b))}else{var a=/Trident\/.*rv:([0-9]{1,}[\.0-9]{0,})/i.exec(p);if(a){r=G;n=q(a[1])}}if(c>=0)B=q(p.substring(c+12))}else{var a=/(opera)(?:.*version|)[ \/]([\w.]+)/i.exec(p);if(a){r=Z;n=q(a[2])}}}return g==r}function v(){return u(G)}function qb(){return u(sb)}function ub(){return u(Z)}function mb(){return qb()&&B>534&&B<535}function I(){u();return B>537||n>42||r==G&&n>=11}function nb(a){var b,c;return function(g){if(!b){b=e;var d=a.substr(0,1).toUpperCase()+a.substr(1);l([a].concat(["WebKit","ms","Moz","O","webkit"]),function(h,e){var b=a;if(e)b=h+d;if(g.style[b]!=f)return c=b})}return c}}function lb(b){var a;return function(c){a=a||nb(b)(c)||b;return a}}var L=lb("transform");function eb(a){return{}.toString.call(a)}var bb={};l(["Boolean","Number","String","Function","Array","Date","RegExp","Object"],function(a){bb["[object "+a+"]"]=a.toLowerCase()});function l(b,d){var a,c;if(eb(b)=="[object Array]"){for(a=0;a<b.length;a++)if(c=d(b[a],a,b))return c}else for(a in b)if(c=d(b[a],a,b))return c}function F(a){return a==g?String(a):bb[eb(a)]||"object"}function cb(a){for(var b in a)return e}function C(a){try{return F(a)=="object"&&!a.nodeType&&a!=a.window&&(!a.constructor||{}.hasOwnProperty.call(a.constructor.prototype,"isPrototypeOf"))}catch(b){}}function jb(b,a){setTimeout(b,a||0)}function ab(b,d,c){var a=!b||b=="inherit"?"":b;l(d,function(c){var b=c.exec(a);if(b){var d=a.substr(0,b.index),e=a.substr(b.index+b[0].length+1,a.length-1);a=d+e}});a&&(c+=(!a.indexOf(" ")?"":" ")+a);return c}function gb(a,b){if(a===f)a=b;return a}j.jd=Eb;j.ve=v;j.If=qb;j.Hg=I;nb("transform");j.qd=function(){return n};j.Kg=function(){u();return B};j.nb=jb;j.Y=gb;j.qb=function(a,b){b.call(a);return z({},a)};function U(a){a.constructor===U.caller&&a.F&&a.F.apply(a,U.caller.arguments)}j.F=U;j.Ub=function(a){if(j.Lg(a))a=i.getElementById(a);return a};function t(a){return a||h.event}j.Mg=t;j.Wb=function(b){b=t(b);var a=b.target||b.srcElement||i;if(a.nodeType==3)a=j.pd(a);return a};j.de=function(a){a=t(a);return a.relatedTarget||a.toElement};j.He=function(a){a=t(a);return a.which||([0,1,3,0,2])[a.button]||a.charCode||a.keyCode};j.nd=function(a){a=t(a);return{x:a.clientX||0,y:a.clientY||0}};j.Ng=function(b,a){return b.x>=a.x&&b.x<=a.x+a.w&&b.y>=a.y&&b.y<=a.y+a.h};j.be=function(c,e){var a=b.Og(e),d=b.nd(c);return j.Ng(d,a)};function w(c,d,a){if(a!==f)c.style[d]=a==f?"":a;else{var b=c.currentStyle||c.style;a=b[d];if(a==""&&h.getComputedStyle){b=c.ownerDocument.defaultView.getComputedStyle(c,g);b&&(a=b.getPropertyValue(d)||b[d])}return a}}function X(b,c,a,d){if(a===f){a=q(w(b,c));isNaN(a)&&(a=g);return a}if(a==g)a="";else d&&(a+="px");w(b,c,a)}function m(c,a){var d=a?X:w,b;if(a&4)b=lb(c);return function(e,f){return d(e,b?b(e):c,f,a&2)}}function zb(a){return q(a.style.opacity||"1")}function Bb(b,a){b.style.opacity=a==1||a==g?"":c.z(a*100)/100}var N={o:["rotate"],yb:["rotateX"],wb:["rotateY"],qc:["skewX"],nc:["skewY"]};if(!I())N=z(N,{hb:["scaleX",2],eb:["scaleY",2],tb:["translateZ",1]});function M(c,a){var b="";if(a){if(v()&&n&&n<10){delete a.yb;delete a.wb;delete a.tb}l(a,function(d,c){var a=N[c];if(a){var e=a[1]||0;if(O[c]!=d)b+=" "+a[0]+"("+d+(["deg","px",""])[e]+")"}});if(I()){if(a.Sb||a.Zb||a.tb!=f)b+=" translate3d("+(a.Sb||0)+"px,"+(a.Zb||0)+"px,"+(a.tb||0)+"px)";if(a.hb==f)a.hb=1;if(a.eb==f)a.eb=1;if(a.hb!=1||a.eb!=1)b+=" scale3d("+a.hb+", "+a.eb+", 1)"}}c.style[L(c)]=b}j.Rg=m("transformOrigin",4);j.Tg=m("backfaceVisibility",4);j.vc=m("transformStyle",4);j.dh=m("perspective",6);j.Vg=m("perspectiveOrigin",4);j.we=function(b,a){if(v()&&n<9)b.style.zoom=a==1?"":a;else{var c=L(b),f=a==1?"":"scale("+a+")",e=b.style[c],g=new RegExp(/[\s]*scale\(.*?\)/g),d=ab(e,[g],f);b.style[c]=d}};j.xb=function(a,d,b,c){a=j.Ub(a);if(a.addEventListener){d=="mousewheel"&&a.addEventListener("DOMMouseScroll",b,c);a.addEventListener(d,b,c)}else if(a.attachEvent){a.attachEvent("on"+d,b);c&&a.setCapture&&a.setCapture()}};j.Nb=function(a,c,d,b){a=j.Ub(a);if(a.removeEventListener){c=="mousewheel"&&a.removeEventListener("DOMMouseScroll",d,b);a.removeEventListener(c,d,b)}else if(a.detachEvent){a.detachEvent("on"+c,d);b&&a.releaseCapture&&a.releaseCapture()}};j.Mb=function(a){a=t(a);a.preventDefault&&a.preventDefault();a.cancel=e;a.returnValue=k};j.Xg=function(a){a=t(a);a.stopPropagation&&a.stopPropagation();a.cancelBubble=e};j.mb=function(d,c){var a=[].slice.call(arguments,2),b=function(){var b=a.concat([].slice.call(arguments,0));return c.apply(d,b)};return b};j.Yg=function(a,b){if(b==f)return a.textContent||a.innerText;var c=i.createTextNode(b);j.Cc(a);a.appendChild(c)};j.Og=function(b){var a=b.getBoundingClientRect();return{x:a.left,y:a.top,w:a.right-a.left,h:a.bottom-a.top}};j.ec=function(d,c){for(var b=[],a=d.firstChild;a;a=a.nextSibling)(c||a.nodeType==1)&&b.push(a);return b};function db(a,c,e,b){b=b||"u";for(a=a?a.firstChild:g;a;a=a.nextSibling)if(a.nodeType==1){if(D(a,b)==c)return a;if(!e){var d=db(a,c,e,b);if(d)return d}}}j.me=db;function S(a,d,f,b){b=b||"u";var c=[];for(a=a?a.firstChild:g;a;a=a.nextSibling)if(a.nodeType==1){D(a,b)==d&&c.push(a);if(!f){var e=S(a,d,f,b);if(e.length)c=c.concat(e)}}return c}j.Ig=function(b,a){return b.getElementsByTagName(a)};j.ob=function(a,f,d,g){d=d||"u";var e;do{if(a.nodeType==1){var c;d&&(c=D(a,d));if(c&&c==gb(f,c)||g==a.tagName){e=a;break}}a=b.pd(a)}while(a&&a!=i.body);return e};j.vg=function(a){return W(["INPUT","TEXTAREA","SELECT"])[a.tagName]};function z(){var e=arguments,d,c,b,a,h=1&e[0],g=1+h;d=e[g-1]||{};for(;g<e.length;g++)if(c=e[g])for(b in c){a=c[b];if(a!==f){a=c[b];var i=d[b];d[b]=h&&(C(i)||C(a))?z(h,{},i,a):a}}return d}j.W=z;function V(f,g){var d={},c,a,b;for(c in f){a=f[c];b=g[c];if(a!==b){var e;if(C(a)&&C(b)){a=V(a,b);e=!cb(a)}!e&&(d[c]=a)}}return d}j.ke=function(a){return F(a)=="function"};j.ng=function(a){return F(a)=="array"};j.Lg=function(a){return F(a)=="string"};j.lc=function(a){return!isNaN(q(a))&&isFinite(a)};j.i=l;j.Od=C;function Q(a){return i.createElement(a)}j.Hc=function(){return Q("DIV")};j.qg=function(){return Q("SPAN")};j.rg=function(){};function E(b,c,a){if(a==f)return b.getAttribute(c);b.setAttribute(c,a)}function D(a,b){return E(a,b)||E(a,"data-"+b)}j.p=E;j.bb=D;j.s=function(d,b,c){var a=j.sg(D(d,b));if(isNaN(a))a=c;return a};function x(b,a){return E(b,"class",a)||""}function W(b){var a={};l(b,function(b){if(b!=f)a[b]=b});return a}function kb(b,a){return b.match(a||vb)}function P(b,a){return W(kb(b||"",a))}j.Fe=W;j.mf=kb;j.ug=function(a){a&&(a=a.toLowerCase());return a};function Y(b,c){var a="";l(c,function(c){a&&(a+=b);a+=c});return a}function J(a,c,b){x(a,Y(" ",z(V(P(x(a)),P(c)),P(b))))}j.pd=function(a){return a.parentNode};j.Fb=function(a){j.Cb(a,"none")};j.lb=function(a,b){j.Cb(a,b?"none":"")};j.xg=function(b,a){b.removeAttribute(a)};j.zg=function(d,a){if(a)d.style.clip="rect("+c.z(a.f||a.N||0)+"px "+c.z(a.v)+"px "+c.z(a.B)+"px "+c.z(a.c||a.M||0)+"px)";else if(a!==f){var h=d.style.cssText,g=[new RegExp(/[\s]*clip: rect\(.*?\)[;]?/i),new RegExp(/[\s]*cliptop: .*?[;]?/i),new RegExp(/[\s]*clipright: .*?[;]?/i),new RegExp(/[\s]*clipbottom: .*?[;]?/i),new RegExp(/[\s]*clipleft: .*?[;]?/i)],e=ab(h,g,"");b.Fd(d,e)}};j.Ag=function(b,a){if(a)b.style.backgroundColor="rgba("+c.z(a.xd)+","+c.z(a.Hd)+","+c.z(a.Bd)+","+a.a+")"};j.gc=function(){return+new Date};j.kb=function(b,a){b.appendChild(a)};j.Db=function(b,a,c){(c||a.parentNode).insertBefore(b,a)};j.cc=function(b,a){a=a||b.parentNode;a&&a.removeChild(b)};j.Bg=function(a,b){l(a,function(a){j.cc(a,b)})};j.Cc=function(a){j.Bg(j.ec(a,e),a)};function hb(){l([].slice.call(arguments,0),function(a){if(j.ng(a))hb.apply(g,a);else a&&a.q()})}j.q=hb;j.Jd=function(a,b){var c=j.pd(a);if(b&1){j.gb(a,(j.P(c)-j.P(a))/2);j.Id(a,g)}if(b&2){j.ib(a,(j.Q(c)-j.Q(a))/2);j.Yd(a,g)}};var R={f:g,v:g,B:g,c:g,L:g,I:g};j.Cg=function(a){var b=j.Hc();s(b,{Vd:"block",Ob:j.Ib(a),f:0,c:0,L:0,I:0});var d=j.Sd(a,R);j.Db(b,a);j.kb(b,a);var e=j.Sd(a,R),c={};l(d,function(b,a){if(b==e[a])c[a]=b});s(b,R);s(b,c);s(a,{f:0,c:0});return c};j.Dg=function(b,a){return parseInt(b,a||10)};j.sg=q;j.De=function(b,a){var c=i.body;while(a&&b!==a&&c!==a)a=a.parentNode;return b===a};function T(d,c,b){var a=d.cloneNode(!c);!b&&j.xg(a,"id");return a}j.Gb=T;j.Tb=function(d,f){var a=new Image;function b(e,d){j.Nb(a,"load",b);j.Nb(a,"abort",c);j.Nb(a,"error",c);f&&f(a,d)}function c(a){b(a,e)}if(ub()&&n<11.6||!d)b(!d);else{j.xb(a,"load",b);j.xb(a,"abort",c);j.xb(a,"error",c);a.src=d}};j.Eg=function(e,a,d){var b=1;function c(c){b--;if(a&&c&&c.src==a.src)a=c;!b&&d&&d(a)}l(e,function(a){if(a.src){b++;j.Tb(a.src,c)}});c()};j.Fg=function(a,g,i,h){if(h)a=T(a);var c=S(a,g);if(!c.length)c=b.Ig(a,g);for(var f=c.length-1;f>-1;f--){var d=c[f],e=T(i);x(e,x(d));b.Fd(e,d.style.cssText);b.Db(e,d);b.cc(d)}return a};function Cb(){var a=this;b.qb(a,o);var d,q="",s=["av","pv","ds","dn"],e=[],r,n=0,k=0,g=0;function m(){J(d,r,(e[g||k&2||k]||"")+" "+(e[n]||""));j.kc(d,g?"none":"")}function c(){n=0;a.Z(h,"mouseup",c);a.Z(i,"mouseup",c);a.Z(i,"touchend",c);a.Z(i,"touchcancel",c);a.Z(h,"blur",c);m()}function p(b){if(g)j.Mb(b);else{n=4;m();a.g(h,"mouseup",c);a.g(i,"mouseup",c);a.g(i,"touchend",c);a.g(i,"touchcancel",c);a.g(h,"blur",c)}}a.nf=function(a){if(a===f)return k;k=a&2||a&1;m()};a.Lc=function(a){if(a===f)return!g;g=a?0:3;m()};a.F=function(f){a.fb=d=j.Ub(f);E(d,"data-jssor-button","1");var c=b.mf(x(d));if(c)q=c.shift();l(s,function(a){e.push(q+a)});r=Y(" ",e);e.unshift("");a.g(d,"mousedown",p);a.g(d,"touchstart",p)};b.F(a)}j.Jc=function(a){return new Cb(a)};j.T=w;m("backgroundColor");j.uc=m("overflow");j.kc=m("pointerEvents");j.ib=m("top",2);j.Id=m("right",2);j.Yd=m("bottom",2);j.gb=m("left",2);j.P=m("width",2);j.Q=m("height",2);m("marginLeft",2);m("marginTop",2);j.Ib=m("position");j.Cb=m("display");j.ab=m("zIndex",1);j.Ne=function(b,a,c){if(a!==f)Bb(b,a,c);else return zb(b)};j.Fd=function(a,b){if(b!=f)a.style.cssText=b;else return a.style.cssText};j.jf=function(b,a){if(a===f){a=w(b,"backgroundImage")||"";var c=/\burl\s*\(\s*["']?([^"'\r\n,]+)["']?\s*\)/gi.exec(a)||[];return c[1]}w(b,"backgroundImage",a?"url('"+a+"')":"")};var K;j.hf=K={a:j.Ne,f:j.ib,v:j.Id,B:j.Yd,c:j.gb,L:j.P,I:j.Q,Ob:j.Ib,Vd:j.Cb,U:j.ab};j.Sd=function(c,b){var a={};l(b,function(d,b){if(K[b])a[b]=K[b](c)});return a};function s(b,h){var a=I(),d=mb(),e=L(b);function c(l,a){a=a||{};var h=a.tb||0,i=(a.yb||0)%360,j=(a.wb||0)%360,k=(a.o||0)%360,c=a.hb,d=a.eb,g=a.kh;if(c==f)c=1;if(d==f)d=1;if(g==f)g=1;var b=new yb(a.Sb,a.Zb,h);b.Rc(c,d,g);b.Te(a.qc,a.nc);b.yb(i);b.wb(j);b.Se(k);b.Qb(a.M,a.N);l.style[e]=b.lf()}s=function(e,b){b=b||{};var i=b.M,k=b.N,h;l(K,function(a,c){h=b[c];h!==f&&a(e,h)});j.zg(e,b.j);j.Ag(e,b.Bb);if(!a){i!=f&&j.gb(e,(b.Be||0)+i);k!=f&&j.ib(e,(b.xe||0)+k)}if(b.af)if(d)jb(j.mb(g,M,e,b));else if(a)c(e,b);else M(e,b)};j.V=s;s(b,h)}j.V=s;function yb(j,k,n){var d=this,b=[1,0,0,0,0,1,0,0,0,0,1,0,j||0,k||0,n||0,1],i=c.Jb,h=c.Pb,l=c.Td;function f(a){return a*c.J/180}function m(c,e,l,m,o,r,t,u,w,z,A,C,E,b,f,k,a,g,i,n,p,q,s,v,x,y,B,D,F,d,h,j){return[c*a+e*p+l*x+m*F,c*g+e*q+l*y+m*d,c*i+e*s+l*B+m*h,c*n+e*v+l*D+m*j,o*a+r*p+t*x+u*F,o*g+r*q+t*y+u*d,o*i+r*s+t*B+u*h,o*n+r*v+t*D+u*j,w*a+z*p+A*x+C*F,w*g+z*q+A*y+C*d,w*i+z*s+A*B+C*h,w*n+z*v+A*D+C*j,E*a+b*p+f*x+k*F,E*g+b*q+f*y+k*d,E*i+b*s+f*B+k*h,E*n+b*v+f*D+k*j]}function e(c,a){return m.apply(g,(a||b).concat(c))}d.Rc=function(a,c,d){if(a!=1||c!=1||d!=1)b=e([a,0,0,0,0,c,0,0,0,0,d,0,0,0,0,1])};d.Qb=function(a,c,d){b[12]+=a||0;b[13]+=c||0;b[14]+=d||0};d.yb=function(c){if(c){a=f(c);var d=h(a),g=i(a);b=e([1,0,0,0,0,d,g,0,0,-g,d,0,0,0,0,1])}};d.wb=function(c){if(c){a=f(c);var d=h(a),g=i(a);b=e([d,0,-g,0,0,1,0,0,g,0,d,0,0,0,0,1])}};d.Se=function(c){if(c){a=f(c);var d=h(a),g=i(a);b=e([d,g,0,0,-g,d,0,0,0,0,1,0,0,0,0,1])}};d.Te=function(a,c){if(a||c){j=f(a);k=f(c);b=e([1,l(k),0,0,l(j),1,0,0,0,0,1,0,0,0,0,1])}};d.lf=function(){return"matrix3d("+b.join(",")+")"}}var O={Be:0,xe:0,M:0,N:0,K:1,hb:1,eb:1,o:0,yb:0,wb:0,Sb:0,Zb:0,tb:0,qc:0,nc:0};j.Kc=function(c,d){var a=c||{};if(c)if(b.ke(c))a={Y:a};else if(b.ke(c.j))a.j={Y:c.j};a.Y=a.Y||d;if(a.j)a.j.Y=a.j.Y||d;if(a.Bb)a.Bb.Y=a.Bb.Y||d;return a};function ib(c,a){var b={};l(c,function(c,d){var e=c;if(a[d]!=f)if(j.lc(c))e=c+a[d];else e=ib(c,a[d]);b[d]=e});return b}j.ff=ib;j.je=function(o,j,s,t,E,F,p){var a=j;if(o){a={};for(var i in j){var G=F[i]||1,B=E[i]||[0,1],h=(s-B[0])/B[1];h=c.D(c.A(h,0),1);h=h*G;var y=c.db(h);if(h!=y)h-=y;var k=t.Y||d.n,m,C=o[i],r=j[i];if(b.lc(r)){k=t[i]||k;var D=k(h);m=C+r*D}else{m=z({Dc:{}},o[i]);var A=t[i]||{};l(r.Dc||r,function(d,a){k=A[a]||A.Y||k;var c=k(h),b=d*c;m.Dc[a]=b;m[a]+=b})}a[i]=m}var x=l(j,function(b,a){return O[a]!=f});x&&l(O,function(c,b){if(a[b]==f&&o[b]!==f)a[b]=o[b]});if(x){if(a.K)a.hb=a.eb=a.K;a.ac=p.ac;a.Kb=p.Kb;if(v()&&n>=11&&(j.M||j.N)&&s!=0&&s!=1)a.o=a.o||1e-8;a.af=e}}if(j.j&&p.Qb){var q=a.j.Dc,w=(q.f||0)+(q.B||0),u=(q.c||0)+(q.v||0);a.c=(a.c||0)+u;a.f=(a.f||0)+w;a.j.c-=u;a.j.v-=u;a.j.f-=w;a.j.B-=w}if(a.j&&!a.j.f&&!a.j.c&&!a.j.N&&!a.j.M&&a.j.v==p.ac&&a.j.B==p.Kb)a.j=g;return a}};function o(){var a=this,f,d=[],c=[];function k(a,b){d.push({Lb:a,bc:b})}function j(a,c){b.i(d,function(b,e){b.Lb==a&&b.bc===c&&d.splice(e,1)})}function i(){d=[]}function g(){b.i(c,function(a){b.Nb(a.le,a.Lb,a.bc,a.he)});c=[]}a.Qc=function(){return f};a.g=function(e,a,d,f){b.xb(e,a,d,f);c.push({le:e,Lb:a,bc:d,he:f})};a.Z=function(e,a,d,f){b.i(c,function(g,h){if(g.le===e&&g.Lb==a&&g.bc===d&&g.he==f){b.Nb(e,a,d,f);c.splice(h,1)}})};a.ze=g;a.Nc=a.addEventListener=k;a.removeEventListener=j;a.m=function(a){var c=[].slice.call(arguments,1);b.i(d,function(b){b.Lb==a&&b.bc.apply(h,c)})};a.q=function(){if(!f){f=e;g();i()}}}var l=function(C,D,i,m,R,Q){C=C||0;var a=this,p,n,o,s,F=0,O=1,L,M,K,G,B=0,j=0,r=0,A,l,d,g,q,z,u=[],y,I=k,J,H=k;function T(a){d+=a;g+=a;l+=a;j+=a;r+=a;B+=a}function x(C){var k=C;if(q)if(!z&&(k>=g||k<d)||z&&k>=d)k=((k-d)%q+q)%q+d;if(!A||s||j!=k){var h=c.D(k,g);h=c.A(h,d);if(i.rc)h=g-h+d;if(!A||s||h!=r){if(Q){var x=(h-l)/(D||1),o=b.je(R,Q,x,L,K,M,i);if(y)b.i(o,function(b,a){y[a]&&y[a](m,b)});else b.V(m,o);var n;if(J){var p=h>d&&h<g;if(p!=H)n=H=p}if(!n&&o.a!=f){var t=o.a<.001;if(t!=I)n=I=t}if(n!=f){n&&b.kc(m,"none");!n&&b.kc(m,b.p(m,"data-events"))}}var w=r,v=r=h;b.i(u,function(b,c){var a=!A&&z||k<=j?u[u.length-c-1]:b;a.R(h-B)});j=k;A=e;a.md(w-l,v-l);a.Vb(w,v)}}}function E(a,b,e){b&&a.Ab(g);if(!e){d=c.D(d,a.oc()+B);g=c.A(g,a.ub()+B)}u.push(a)}var v=h.requestAnimationFrame||h.webkitRequestAnimationFrame||h.mozRequestAnimationFrame||h.msRequestAnimationFrame;if(b.If()&&b.qd()<7||!v)v=function(a){b.nb(a,i.vb)};function N(){if(p){var d=b.gc(),e=c.D(d-F,i.Ae),a=j+e*o*O;F=d;if(a*o>=n*o)a=n;x(a);if(!s&&a*o>=n*o)P(G);else v(N)}}function w(f,h,i){if(!p){p=e;s=i;G=h;f=c.A(f,d);f=c.D(f,g);n=f;o=n<j?-1:1;a.rd();F=b.gc();v(N)}}function P(b){if(p){s=p=G=k;a.td();b&&b()}}a.ye=function(a,b,c){w(a?j+a:g,b,c)};a.Bc=w;a.Le=function(a,b){w(g,a,b)};a.S=P;a.ue=function(){return j};a.se=function(){return n};a.u=function(){return r};a.R=x;a.Ze=function(){x(g,e)};a.ad=function(){return p};a.ne=function(a){O=a};a.Ab=T;a.X=function(a,b){E(a,0,b)};a.Vc=function(a){E(a,1)};a.sd=function(a){g+=a};a.oc=function(){return d};a.ub=function(){return g};a.Vb=a.rd=a.td=a.md=b.rg;a.fd=b.gc();i=b.W({vb:16,Ae:50},i);m&&(J=b.p(m,"data-inactive"));q=i.pc;z=i.Ye;y=i.Xe;d=l=C;g=C+D;M=i.z||{};K=i.fc||{};L=b.Kc(i.k)};var n={Re:"data-scale",ic:"data-autocenter",Uc:"data-nofreeze",ce:"data-nodrag"},q=new function(){var a=this;a.bd=function(c,a,e,d){(d||!b.p(c,a))&&b.p(c,a,e)};a.od=function(a){var c=b.s(a,n.ic);b.Jd(a,c)}},s=new function(){var h=this,t=1,q=2,r=4,s=8,w=256,x=512,v=1024,u=2048,j=u+t,i=u+q,o=x+t,m=x+q,n=w+r,k=w+s,l=v+r;function g(b,a,c){c.push(a);b[a]=b[a]||[];b[a].push(c)}h.Ad=function(f){for(var d=f.C,e=f.O,s=f.ud,t=f.Ve,r=[],a=0,b=0,p=d-1,q=e-1,h=t-1,c,b=0;b<e;b++)for(a=0;a<d;a++){switch(s){case j:c=h-(a*e+(q-b));break;case l:c=h-(b*d+(p-a));break;case o:c=h-(a*e+b);case n:c=h-(b*d+a);break;case i:c=a*e+b;break;case k:c=b*d+(p-a);break;case m:c=a*e+(q-b);break;default:c=b*d+a}g(r,c,[b,a])}return r};h.kf=function(d){for(var e=[],a,b=0;b<d.O;b++)for(a=0;a<d.C;a++)g(e,c.cb(1e5*c.Wd())%13,[b,a]);return e}},u=function(m,r,p,u,z,A){var a=this,v,h,f,y=0,x=u.gf,q,i=8;function t(a){if(a.f)a.N=a.f;if(a.c)a.M=a.c;b.i(a,function(a){b.Od(a)&&t(a)})}function j(h,f,g){var a={vb:f,l:1,nb:0,C:1,O:1,a:0,K:0,j:0,Qb:k,tc:k,rc:k,Xc:s.kf,ud:1032,rb:{zc:0,Yc:0},k:d.n,z:{},Fc:[],fc:{}};b.W(a,h);if(a.O==0)a.O=c.z(a.C*g);t(a);a.Ve=a.C*a.O;a.k=b.Kc(a.k,d.n);a.Pe=c.cb(a.l/a.vb);a.Qe=function(c,b){c/=a.C;b/=a.O;var f=c+"x"+b;if(!a.Fc[f]){a.Fc[f]={L:c,I:b};for(var d=0;d<a.C;d++)for(var e=0;e<a.O;e++)a.Fc[f][e+","+d]={f:e*b,v:d*c+c,B:e*b+b,c:d*c}}return a.Fc[f]};if(a.G){a.G=j(a.G,f,g);a.tc=e}return a}function n(z,i,a,v,n,l){var y=this,t,u={},h={},m=[],f,d,r,p=a.rb.zc||0,q=a.rb.Yc||0,g=a.Qe(n,l),o=B(a),C=o.length-1,s=a.l+a.nb*C,w=v+s,j=a.tc,x;w+=50;function B(a){var b=a.Xc(a);return a.rc?b.reverse():b}y.Xd=w;y.Ac=function(d){d-=v;var e=d<s;if(e||x){x=e;if(!j)d=s-d;var f=c.cb(d/a.vb);b.i(h,function(a,e){var d=c.A(f,a.D);d=c.D(d,a.length-1);if(a.Ud!=d){if(!a.Ud&&!j)b.lb(m[e]);else d==a.A&&j&&b.Fb(m[e]);a.Ud=d;b.V(m[e],a[d])}})}};i=b.Gb(i);A(i,0,0);b.i(o,function(i,m){b.i(i,function(G){var I=G[0],H=G[1],v=I+","+H,o=k,s=k,x=k;if(p&&H%2){if(p&3)o=!o;if(p&12)s=!s;if(p&16)x=!x}if(q&&I%2){if(q&3)o=!o;if(q&12)s=!s;if(q&16)x=!x}a.f=a.f||a.j&4;a.B=a.B||a.j&8;a.c=a.c||a.j&1;a.v=a.v||a.j&2;var E=s?a.B:a.f,B=s?a.f:a.B,D=o?a.v:a.c,C=o?a.c:a.v;a.j=E||B||D||C;r={};d={N:0,M:0,a:1,L:n,I:l};f=b.W({},d);t=b.W({},g[v]);if(a.a)d.a=2-a.a;if(a.U){d.U=a.U;f.U=0}var K=a.C*a.O>1||a.j;if(a.K||a.o){var J=e;if(J){d.K=a.K?a.K-1:1;f.K=1;var N=a.o||0;d.o=N*360*(x?-1:1);f.o=0}}if(K){var i=t.Dc={};if(a.j){var w=a.jh||1;if(E&&B){i.f=g.I/2*w;i.B=-i.f}else if(E)i.B=-g.I*w;else if(B)i.f=g.I*w;if(D&&C){i.c=g.L/2*w;i.v=-i.c}else if(D)i.v=-g.L*w;else if(C)i.c=g.L*w}r.j=t;f.j=g[v]}var L=o?1:-1,M=s?1:-1;if(a.x)d.M+=n*a.x*L;if(a.y)d.N+=l*a.y*M;b.i(d,function(a,c){if(b.lc(a))if(a!=f[c])r[c]=a-f[c]});u[v]=j?f:d;var F=a.Pe,A=c.z(m*a.nb/a.vb);h[v]=new Array(A);h[v].D=A;h[v].A=A+F-1;for(var z=0;z<=F;z++){var y=b.je(f,r,z/F,a.k,a.fc,a.z,{Qb:a.Qb,ac:n,Kb:l});y.U=y.U||1;h[v].push(y)}})});o.reverse();b.i(o,function(a){b.i(a,function(c){var f=c[0],e=c[1],d=f+","+e,a=i;if(e||f)a=b.Gb(i);b.V(a,u[d]);b.uc(a,"hidden");b.Ib(a,"absolute");z.Oe(a);m[d]=a;b.lb(a,!j)})})}function w(){var a=this,b=0;l.call(a,0,v);a.Vb=function(c,a){if(a-b>i){b=a;f&&f.Ac(a);h&&h.Ac(a)}};a.ld=q}a.Me=function(){var a=0,b=u.jc,d=b.length;if(x)a=y++%d;else a=c.db(c.Wd()*d);b[a]&&(b[a].Xb=a);return b[a]};a.Ke=function(x,y,k,l,b,t){a.Eb();q=b;b=j(b,i,t);var g=l.Ld,e=k.Ld;g["no-image"]=!l.Kd;e["no-image"]=!k.Kd;var o=g,s=e,w=b,d=b.G||j({},i,t);if(!b.tc){o=e;s=g}var u=d.Ab||0;h=new n(m,s,d,c.A(u-d.vb,0),r,p);f=new n(m,o,w,c.A(d.vb-u,0),r,p);h.Ac(0);f.Ac(0);v=c.A(h.Xd,f.Xd);a.Xb=x};a.Eb=function(){m.Eb();h=g;f=g};a.Je=function(){var a=g;if(f)a=new w;return a};if(z&&b.Kg()<537)i=16;o.call(a);l.call(a,-1e7,1e7)},r={Mc:1},t=function(){var a=this,D=b.qb(a,o),h,v,C,B,m,l=0,d,s,p,z,A,i,k,u,t,x,j;function y(a){j[a]&&j[a].nf(a==l)}function w(b){a.m(r.Mc,b*s)}a.id=function(a){if(a!=m){var d=l,b=c.db(a/s);l=b;m=a;y(d);y(b)}};a.Zc=function(a){b.lb(h,a)};a.dd=function(I){b.q(j);m=f;a.ze();x=[];j=[];b.Cc(h);v=c.cb(I/s);l=0;var H=u+z,y=t+A,r=c.cb(v/p)-1;C=u+H*(!i?r:p-1);B=t+y*(i?r:p-1);b.P(h,C);b.Q(h,B);for(var n=0;n<v;n++){var D=b.qg();b.Yg(D,n+1);var o=b.Fg(k,"numbertemplate",D,e);b.Ib(o,"absolute");var G=n%(r+1),E=c.db(n/(r+1)),F=d.mc&&!i?r-G:G;b.gb(o,(!i?F:E)*H);b.ib(o,(i?F:E)*y);b.kb(h,o);x[n]=o;d.hd&1&&a.g(o,"click",b.mb(g,w,n));d.hd&2&&a.g(o,"mouseenter",b.mb(g,w,n));j[n]=b.Jc(o)}q.od(h)};a.F=function(e,c){a.fb=h=b.Ub(e);a.kd=d=b.W({Ed:10,Dd:10,hd:1},c);k=b.me(h,"prototype");u=b.P(k);t=b.Q(k);b.cc(k,h);s=d.Ee||1;p=d.O||1;z=d.Ed;A=d.Dd;i=d.We&2;d.sb&&q.bd(h,n.ic,d.sb)};a.q=function(){b.q(j,D)};b.F(a)},v=function(){var a=this,v=b.qb(a,o),d,c,f,l,s,k,h,m,j,i;function p(b){a.m(r.Mc,b,e)}function u(a){b.lb(d,a);b.lb(c,a)}function t(){j.Lc((f.dc||!l.df(h))&&k>1);i.Lc((f.dc||!l.ef(h))&&k>1)}a.id=function(c,a,b){h=a;!b&&t()};a.Zc=u;a.dd=function(f){k=f;h=0;if(!s){a.g(d,"click",b.mb(g,p,-m));a.g(c,"click",b.mb(g,p,m));j=b.Jc(d);i=b.Jc(c);b.p(d,n.Uc,1);b.p(c,n.Uc,1);s=e}};a.F=function(g,e,h,i){a.kd=f=b.W({Ee:1},h);d=g;c=e;if(f.mc){d=e;c=g}m=f.Ee;l=i;if(f.sb){q.bd(d,n.ic,f.sb);q.bd(c,n.ic,f.sb)}q.od(d);q.od(c)};a.q=function(){b.q(j,i,v)};b.F(a)};function p(e,d,c){var a=this;b.qb(a,o);l.call(a,0,c.Yb);a.yc=0;a.Pc=c.Yb}p.Oc=21;p.sc=24;var w=function(){var a=this,hb=b.qb(a,o);l.call(a,0,0);var f,s,gb=[d.n,d.uf,d.H,d.Zd,d.cd,d.Rb,d.pf,d.ae,d.Mf,d.hg,d.jb,d.gg,d.fg,d.eg,d.dg,d.cg,d.ag,d.Zf,d.Yf,d.Wc,d.Vf,d.Uf,d.Sf,d.Ug,d.Kf,d.Nf,d.Of,d.Pf,d.Qf,d.yd,d.wd,d.Rf,d.Wf,d.Xf],P={},S,C,t=new l(0,0),T=[],x=[],E,q=0;function G(d,c){var a={};b.i(d,function(d,f){var e=P[f];if(e){if(b.Od(d))d=G(d,c||f=="e");else if(c)if(b.lc(d))d=gb[d];a[e]=d}});return a}function I(c,f){var e=[],d=b.s(c,"play");if(f&&d){var g=new w(c,s,{Gg:d});N.push(g);a.g(g,p.Oc,Z);a.g(g,p.sc,U)}else b.i(b.ec(c),function(a){e=e.concat(I(a,f+1))});if(!f&&(!j||j&16)||f&&(!d||!(d&16))){var h=S[b.s(c,"t")];h&&e.push({fb:c,ld:h})}return e}function O(c,e){var a=T[c];if(a==g){a=T[c]={zb:c,Ic:[],Ge:[]};var d=0;!b.i(x,function(a,b){d=b;return a.zb>c})&&d++;x.splice(d,0,a)}return a}function db(o,p,f){var a,d;if(C){var k=C[b.s(o,"c")];if(k){a=O(k.r,0);a.tg=k.e||0}}b.i(p,function(h){var g=b.W(e,{},G(h)),i=b.Kc(g.k);delete g.k;if(g.c){g.M=g.c;i.M=i.c;delete g.c}if(g.f){g.N=g.f;i.N=i.f;delete g.f}var m={k:i,ac:f.L,Kb:f.I},j=new l(h.b,h.d,m,o,f,g);q=c.A(q,h.b+h.d);if(a){if(!d)d=new l(h.b,0);d.X(j)}else{var k=O(h.b,h.b+h.d);k.Ic.push(j)}if(g.Bb)f.Bb={xd:0,Hd:0,Bd:0,a:0};f=b.ff(f,g)});if(a&&d){d.Ze();var h=d,i,j=d.oc(),m=d.ub(),n=c.A(m,a.tg);if(a.zb<m){if(a.zb>j){h=new l(j,a.zb-j);h.X(d,e)}else h=g;i=new l(a.zb,n-j,{pc:n-a.zb,Ye:e});i.X(d,e)}h&&a.Ic.push(h);i&&a.Ge.push(i)}return f}function cb(a){b.i(a,function(d){var a=d.fb,f=b.P(a),e=b.Q(a),c={c:b.gb(a),f:b.ib(a),M:0,N:0,a:1,U:b.ab(a)||0,o:0,yb:0,wb:0,hb:1,eb:1,Sb:0,Zb:0,tb:0,qc:0,nc:0,L:f,I:e,j:{f:0,v:f,B:e,c:0}};c.Be=c.c;c.xe=c.f;db(a,d.ld,c)})}function fb(f,d,g){var c=f.b-d;if(c){var b=new l(d,c);b.X(t,e);b.Ab(g);a.X(b)}a.sd(f.d);return c}function eb(e){var c=t.oc(),d=0;b.i(e,function(e,f){e=b.W({d:3e3},e);fb(e,c,d);c=e.b;d+=e.d;if(!f||e.t==2){a.yc=c;a.Pc=c+e.d}})}function B(g,e,d){var f=e.length;if(f>4)for(var j=c.cb(f/4),a=0;a<j;a++){var h=e.slice(a*4,c.D(a*4+4,f)),i=new l(h[0].zb,0);B(i,h,d);g.X(i)}else b.i(e,function(a){b.i(d?a.Ge:a.Ic,function(a){d&&a.sd(q-a.ub());g.X(a)})})}var j,F,u=0,h,z,K,J,A,N=[],H=[],r,D,m;function y(a){return a&2||a&4&&b.jd().gd}function ab(){if(!A){h&8&&a.g(i,"keydown",Q);if(h&32){a.g(i,"mousedown",v);a.g(i,"touchstart",v)}A=e}}function Y(){a.Z(i,"keydown",Q);a.Z(i,"mousedown",v);a.Z(i,"touchstart",v);A=k}function L(b){if(!r||b){r=e;a.S();b&&u&&a.R(0);a.ne(1);a.Le();ab();a.m(p.Oc,a)}}function n(){if(!D&&(r||a.u())){D=e;a.S();a.ue()>a.yc&&a.R(a.yc);a.ne(K||1);a.Bc(0)}}function V(){!m&&n()}function M(c){var b=c;if(c<0&&a.u())b=1;if(b!=u){u=b;F&&a.m(p.sc,a,u)}}function Q(a){h&8&&b.He(a)==27&&n()}function X(a){if(m&&b.de(a)!==g){m=k;h&16&&b.nb(V,160)}}function v(a){h&32&&!b.De(f,b.Wb(a))&&n()}function W(a){if(!m){m=e;if(j&1)b.be(a,f)&&L()}}function bb(i){var d=b.Wb(i),a=b.ob(d,g,g,"A"),c=a&&(b.vg(a)||a===f||b.De(f,a));if(r&&y(h))!c&&n();else if(y(j))!c&&L(e)}function Z(b){var c=b.pg(),a=H[c];a!==b&&a&&a.og();H[c]=b}function U(b,c){a.m(p.sc,b,c)}a.pg=function(){return J||""};a.og=n;a.rd=function(){M(1)};a.td=function(){r=k;D=k;M(-1);!a.u()&&Y()};a.Vb=function(){!m&&z&&a.ue()>a.Pc&&n()};a.F=function(m,i,d){f=m;s=i;j=d.Gg;E=d.mg;S=s.jc;C=s.fh;var l={f:"y",c:"x",B:"m",v:"t",o:"r",yb:"rX",wb:"rY",hb:"sX",eb:"sY",Sb:"tX",Zb:"tY",tb:"tZ",qc:"kX",nc:"kY",a:"o",k:"e",U:"i",j:"c",Bb:"bc",xd:"re",Hd:"gr",Bd:"bl"};b.i(l,function(b,a){P[b]=a});cb(I(f,0));B(t,x);if(j){a.X(t);E=e;z=b.s(f,"idle");h=b.s(f,"rollback");K=b.s(f,"speed",1);J=b.bb(f,"group");(y(j)||y(h))&&a.g(f,"click",bb);if((j&1||z)&&!b.jd().gd){a.g(f,"mouseenter",W);a.g(f,"mouseleave",X)}F=b.s(f,"pause")}var k=s.gh||[],c=k[b.s(f,"b")]||[],g={b:q,d:c.length?0:d.Yb||z||0};c=c.concat([g]);eb(c);a.ub();E&&a.sd(1e8);q=a.ub();B(a,x,e);a.R(-1);a.R(b.s(f,"initial")||0)};a.q=function(){b.q(hb,N);a.S();a.R(-1)};b.F(a)},j=(h.module||{}).exports=function(){var a=this,xc=b.qb(a,o),Kb="data-jssor-slider",Cc="data-jssor-thumb",t,m,R,Hb,cb,tb,Z,M,K,P,Ub,zc=1,qc=1,Gc=1,hc=1,cc={},w,U,Vb,Zb,Yb,Ib,Gb,Fb,gb,E=[],fc,u=-1,jc,q,I,H,L,kb,lb,F,J,hb,S,A,W,jb,Y=[],lc,nc,dc,s,sb,Cb,nb,eb,X,ic,Bb,Mb,Nb,G,ac=0,bb=0,Q=Number.MAX_VALUE,N=Number.MIN_VALUE,C,ib,db,T=1,Sb=0,mb,B,Ab,zb,O,xb,yb,z,V,ob,y,Jb,Xb=b.jd(),Qb=Xb.gd,x=[],D,ub,ab,bc,Ac,Ic,vb;function Eb(){return!T&&X&12}function Bc(){return Sb||!T&&X&3}function Db(){return!B&&!Eb()&&!y.ad()}function Rc(){return!Bc()&&Db()}function Ec(){return A||R}function Kc(){return Ec()&2?lb:kb}function Hc(a,c,d){b.gb(a,c);b.ib(a,d)}function vc(c,b){var a=Ec(),d=(kb*b+ac)*(a&1),e=(lb*b+ac)*(a&2)/2;Hc(c,d,e)}function sc(b,f){if(B&&!(C&1)){var e=b,d;if(b<N){e=N;d=-1}if(b>Q){e=Q;d=1}if(d){var a=b-e;if(f){a=c.zf(a)*2/c.J;a=c.E(a*d,1.6)}else{a=c.E(a*d,.625);a=c.Td(a*c.J/2)}b=e+a*d}}return b}function Mc(a){return sc(a,e)}function dd(a){return sc(a)}function wb(a,b){if(!(C&1)){var c=a-Q+(b||0),d=N-a+(b||0);if(c>0&&c>d)a=Q;else if(d>0)a=N}return a}function oc(a){return!(C&1)&&a-N<.0001}function mc(a){return!(C&1)&&Q-a<.0001}function pb(a){return!(C&1)&&(a-N<.0001||Q-a<.0001)}function Ob(c,a,d){!vb&&b.i(Y,function(b){b.id(c,a,d)})}function uc(b){var a=b,d=pb(b);if(d)a=wb(a);else{b=v(b);a=b}a=c.db(a);a=c.A(a,0);return a}function ad(a){x[u];fc=u;u=a;jc=x[u]}function Pc(){A=0;var b=z.u(),d=uc(b);Ob(d,b);if(pb(b)||b==c.db(b)){if(s&2&&(eb>0&&d==q-1||eb<0&&!d))s=0;ad(d);a.m(j.bh,u,fc)}}function ec(a,b){if(q&&(!b||!y.ad())){y.S();y.Sc(a,a)}}function rb(a){if(q){a=v(a);a=wb(a);ec(a)}else Ob(0,0)}function Uc(){var b=j.pe||0,a=ib;j.pe|=a;return W=a&~b}function Qc(){if(W){j.pe&=~ib;W=0}}function Tb(c){var a=b.Hc();b.V(a,gb);c&&b.uc(a,"hidden");return a}function v(b,a){a=a||q||1;return(b%a+a)%a}function wc(c,a,b){s&8&&(s=0);qb(c,Bb,a,b)}function Pb(){b.i(Y,function(a){a.Zc(a.kd.hh<=T)})}function cd(c){if(!T&&(b.de(c)||!b.be(c,t))){T=1;Pb();if(!B){X&12&&Dc();x[u]&&x[u].Gc()}a.m(j.Zg)}}function bd(){if(T){T=0;Pb();B||!(X&12)||Fc()}a.m(j.Wg)}function Jc(){b.V(U,gb)}function Rb(b,a){qb(b,a,e)}function qb(g,h,l,p){if(q&&(!B||m.te)&&!Eb()&&!isNaN(g)){var d=z.u(),a=g;if(l){a=d+g;if(C&2){if(oc(d)&&g<0)a=Q;if(mc(d)&&g>0)a=N}}if(!(C&1))if(p)a=v(a);else a=wb(a,.5);if(l&&!pb(a))a=c.z(a);var j=(a-d)%q;a=d+j;if(h==f)h=Bb;var b=c.Hb(j),i=0;if(b){if(b<1)b=c.E(b,.5);if(b>1){var o=Kc(),n=(R&1?Gb:Fb)/o;b=c.D(b,n*1.5)}i=h*b}vb=e;y.S();vb=k;y.Sc(d,a,i)}}function Nc(d,h,o){var l=this,i={f:2,v:1,B:2,c:1},m={f:"top",v:"right",B:"bottom",c:"left"},g,a,f,j,k={};l.fb=d;l.wc=function(q,l,u){var p,s=q,r=l;if(!f){f=b.Cg(d);g=d.parentNode;j={Rc:b.s(d,n.Re,1),sb:b.s(d,n.ic)};b.i(m,function(c,a){k[a]=b.s(d,"data-scale-"+c,1)});a=d;if(h){a=b.Gb(g,e);b.V(a,{f:0,c:0});b.kb(a,d);b.kb(g,a)}}if(o){p=c.A(q,l);if(h)if(u>=0&&u<1){var w=c.D(q,l);p=c.D(p/w,1/(1-u))*w}}else s=r=p=c.E(K<P?l:q,j.Rc);var x=h?1.001:1,t=p*x;h&&(hc=t);b.we(a,t);b.P(g,f.L*s);b.Q(g,f.I*r);var v=b.ve()&&b.qd()<9?t:1,y=(s-v)*f.L/2,z=(r-v)*f.I/2;b.gb(a,y);b.ib(a,z);b.i(f,function(d,a){if(i[a]&&d){var e=(i[a]&1)*c.E(q,k[a])*d+(i[a]&2)*c.E(l,k[a])*d/2;b.hf[a](g,e)}});b.Jd(g,j.sb)}}function Yc(){var a=this;l.call(a,0,0,{pc:q});b.i(x,function(b){a.Vc(b);b.Ab(G/F)})}function Xc(){var a=this,b=Jb.fb;l.call(a,-1,2,{k:d.n,Xe:{Ob:vc},pc:q,rc:Cb},b,{Ob:1},{Ob:-2})}function Zc(){var b=this;l.call(b,-1e8,2e8);b.Vb=function(d,b){if(c.Hb(b-d)>1e-5){var g=b,f=b;if(c.db(b)!=b&&b>d&&(C&1||b>bb))f++;var h=uc(f);Ob(h,g,e);a.m(j.Qg,v(g),v(d),b,d)}}}function Oc(o,n){var b=this,f,i,d,c,h;l.call(b,-1e8,2e8,{Ae:100});b.rd=function(){mb=e;a.m(j.Pg,v(z.u()),V.u())};b.td=function(){mb=k;c=k;a.m(j.lg,v(z.u()),V.u());!B&&Pc()};b.Vb=function(g,b){var a=b;if(c)a=h;else if(d){var e=b/d;a=m.Ce(e)*(i-f)+f}a=Mc(a);V.R(a)};b.Sc=function(a,c,h,g){B=k;d=h||1;f=a;i=c;vb=e;V.R(a);vb=k;b.R(0);b.Bc(d,g)};b.jg=function(){c=e;c&&b.ye(g,g,e)};b.kg=function(a){h=a};V=new Zc;V.X(o);Nb&&V.X(n)}function Lc(){var c=this,a=Tb();b.ab(a,0);c.fb=a;c.Oe=function(c){b.kb(a,c);b.lb(a)};c.Eb=function(){b.Fb(a);b.Cc(a)}}function Wc(w,h){var d=this,ib=b.qb(d,o),y,G=0,P,t,F,B,K,i,E=[],V,N,R,n,r,A,S;l.call(d,-J,J+1,{pc:C&1?q:f,rc:Cb});function L(){y&&y.q();Sb-=G;G=0;y=new cb.pb(t,cb,{Yb:b.s(t,"idle",ic),mg:!s});y.Nc(p.sc,Y)}function Z(){y.fd<cb.fd&&L()}function Y(b,a){G+=a;Sb+=a;if(h==u)!G&&d.Gc()}function Q(p,s,o){if(!N){N=e;if(i&&o){var q=b.s(i,"data-expand",0)*2,g=o.width,f=o.height,m=g,l=f;if(g&&f){if(B){if(B&3&&(!(B&4)||g>I||f>H)){var n=k,r=I/H*f/g;if(B&1)n=r>1;else if(B&2)n=r<1;m=n?g*H/f:I;l=n?H:f*I/g}b.P(i,m);b.Q(i,l);b.ib(i,(H-l)/2);b.gb(i,(I-m)/2)}b.we(i,c.A((m+q)/m,(l+q)/l))}b.Ib(i,"absolute")}a.m(j.Hf,h)}s.ee(k);p&&p(d)}function X(g,b,c,f){if(f==A&&u==h&&s&&Db()&&!d.Qc()){var a=v(g);D.Ke(a,h,b,d,c,H/I);b.Gf();ob.Ab(a-ob.oc()-1);ob.R(a);ec(a,e)}}function bb(b){if(b==A&&u==h&&Db()&&!d.Qc()){if(!n){var a=g;if(D)if(D.Xb==h)a=D.Je();else D.Eb();Z();n=new Vc(w,h,a,y);n.Ff(r)}!n.ad()&&n.ed()}}function M(a,e,j){if(a==h){if(a!=e)x[e]&&x[e].oe();else!j&&n&&n.Ef();r&&r.Lc();A=b.gc();d.Tb(b.mb(g,bb,A))}else{var i=c.D(h,a),f=c.A(h,a),l=c.D(f-i,i+q-f),k=J+m.Df-1;(!R||l<=k)&&d.Tb()}}function fb(){if(u==h&&n){n.S();r&&r.Cf();r&&r.Bf();n.qe()}}function hb(){u==h&&n&&n.S()}function ab(b){!db&&a.m(j.Af,h,b)}d.ee=function(a){if(S!=a){S=a;a&&b.kb(w,K);!a&&b.cc(K)}};d.Tb=function(f,c){c=c||d;if(E.length&&!N){c.ee(e);if(!V){V=e;a.m(j.yf,h);b.i(E,function(a){if(!b.p(a,"src")){var c=b.bb(a,"src")||b.bb(a,"src2")||"";if(c){a.src=c;b.Cb(a,b.p(a,"data-display"))}}})}b.Eg(E,i,b.mb(g,Q,f,c))}else Q(f,c)};d.wf=function(){if(Rc())if(q==1){d.oe();M(h,h)}else{var a;if(D)a=D.Me(q);if(a){A=b.gc();var c=h+eb,e=x[v(c)];return e.Tb(b.mb(g,X,c,e,a,A),d)}else(C||!pb(z.u())||!pb(z.u()+eb))&&Rb(eb)}};d.Gc=function(){M(h,h,e)};d.oe=function(){r&&r.Cf();r&&r.Bf();d.re();n&&n.vf();n=g;L()};d.Gf=function(){b.Fb(w)};d.re=function(){b.lb(w)};function T(a,k,d){if(b.p(a,Kb))return;if(d){if(!t){t=a;F=Tb(e);var c="background";b.T(F,c+"Color",b.T(t,c+"Color"));b.T(F,c+"Image",b.T(t,c+"Image"));b.T(t,c,g);b.Db(F,t)}b.p(a,"data-events",b.kc(a));b.p(a,"data-display",b.Cb(a));b.Rg(a,b.bb(a,"data-to"));b.Tg(a,b.bb(a,"data-bf"));d>1&&b.vc(a,b.p(a,"data-ts"));b.dh(a,b.s(a,"data-p"));b.Vg(a,b.bb(a,"po"));if(a.tagName=="IMG"){E.push(a);if(!b.p(a,"src")){R=e;b.Fb(a)}}var f=b.jf(a);if(f){var h=new Image;b.p(h,"src",f);E.push(h)}d&&b.ab(a,(b.ab(a)||0)+1)}var j=b.ec(a);b.i(j,function(c){if(d<3&&!i)if(b.bb(c,"u")=="image"){i=c;i.border=0;b.V(i,gb);b.V(a,gb);b.T(i,"maxWidth","10000px");b.kb(F,i)}T(c,k,d+1)})}d.md=function(c,b){var a=J-b;vc(P,a)};d.Xb=h;T(w,e,0);B=b.s(t,"data-fillmode",m.ge);var O=b.me(t,"thumb",e);if(O){b.Gb(O);b.Fb(O)}b.lb(w);K=b.Gb(U);b.ab(K,1e3);d.g(w,"click",ab);L(e);d.Kd=i;d.Ld=w;P=w;d.g(a,203,M);d.g(a,28,hb);d.g(a,24,fb);d.q=function(){b.q(ib,y,n)}}function Vc(F,h,q,r){var c=this,E=b.qb(c,o),i=0,t=0,g,m,f,d,n,w,v,y=x[h];l.call(c,0,0);function A(){c.ed()}function C(a){v=a;c.S();c.ed()}function z(){}c.ed=function(){if(!B&&!mb&&!v&&u==h&&!c.Qc()){var k=c.u();if(!k)if(g&&!n){n=e;c.qe(e);a.m(j.tf,h,t,i,t,g,d)}a.m(j.fe,h,k,i,m,f,d);if(!Eb()){var l;if(k==d)s&&b.nb(y.wf,20);else{if(k==f)l=d;else if(!k)l=f;else l=c.se();(k!=f||!Bc())&&c.Bc(l,A)}}}};c.Ef=function(){f==d&&f==c.u()&&c.R(m)};c.vf=function(){D&&D.Xb==h&&D.Eb();var b=c.u();b<d&&a.m(j.fe,h,-b-1,i,m,f,d)};c.qe=function(a){q&&b.uc(S,a&&q.ld.sf?"":"hidden")};c.md=function(c,b){if(n&&b>=g){n=k;y.re();D.Eb();a.m(j.rf,h,g,i,t,g,d)}a.m(j.qf,h,b,i,m,f,d)};c.Ff=function(a){if(a&&!w){w=a;a.Nc($JssorPlayer$.Ue,C)}};c.g(r,p.Oc,z);q&&c.Vc(q);g=c.ub();c.Vc(r);m=g+r.yc;d=c.ub();f=s?g+r.Pc:d;c.q=function(){E.q();c.S()}}function gc(){bc=mb;Ac=y.se();ab=z.u();ub=dd(ab)}function Fc(){gc();if(B||Eb()){y.S();a.m(j.of)}}function Dc(g){if(Db()){var b=z.u(),a=ub,f=0;if(g&&c.Hb(O)>=m.Rd){a=b;f=yb}a=c.cb(a);a=wb(a+f,.5);var e=c.Hb(a-b);if(e<1&&m.Ce!=d.n)e=c.E(e,.5);if((!db||!g)&&bc)y.Bc(Ac);else if(b==a)jc.Gc();else y.Sc(b,a,e*Bb)}}function yc(a){!b.ob(b.Wb(a),f,n.ce)&&b.Mb(a)}function pc(b){Ab=k;B=e;Fc();if(!bc)A=0;a.m(j.Jf,v(ab),ab,b)}function Tc(a){tc(a,1)}function tc(c,d){O=0;xb=0;yb=0;Gc=hc;if(d){var h=c.touches[0];zb={x:h.clientX,y:h.clientY}}else zb=b.nd(c);var e=b.Wb(c),g=b.ob(e,"1",Cc);if((!g||g===t)&&!W&&(!d||c.touches.length==1)){jb=b.ob(e,f,n.ce)||!ib||!Uc();a.g(i,d?"touchmove":"mousemove",Wb);Ab=!jb&&b.ob(e,f,n.Uc);!Ab&&!jb&&pc(c,d)}}function Wb(a){var d,f;a=b.Mg(a);if(a.type!="mousemove")if(a.touches.length==1){f=a.touches[0];d={x:f.clientX,y:f.clientY}}else fb();else d=b.nd(a);if(d){var i=d.x-zb.x,j=d.y-zb.y,g=c.Hb(i),h=c.Hb(j);if(A||g>1.5||h>1.5)if(Ab)pc(a,f);else{if(c.db(ub)!=ub)A=A||R&W;if((i||j)&&!A){if(W==3)if(h>g)A=2;else A=1;else A=W;if(Qb&&A==1&&h>g*2.4)jb=e}var l=i,k=kb;if(A==2){l=j;k=lb}(O-xb)*nb<-1.5&&(yb=0);(O-xb)*nb>1.5&&(yb=-1);xb=O;O=l;Ic=ub-O*nb/k/Gc*m.Lf;if(O&&A&&!jb){b.Mb(a);y.jg(e);y.kg(Ic)}}}}function fb(){Qc();a.Z(i,"mousemove",Wb);a.Z(i,"touchmove",Wb);db=O;if(B){db&&s&8&&(s=0);y.S();B=k;var b=z.u();a.m(j.ig,v(b),b,v(ab),ab);X&12&&gc();Dc(e)}}function ed(c){var d=b.Wb(c),a=b.ob(d,"1",Kb);if(t===a)if(db){b.Xg(c);a=b.ob(d,f,"data-jssor-button","A");a&&b.Mb(c)}else{s&4&&(s=0);a=b.ob(d,f,"data-jssor-click");if(a){b.Mb(c);hitValues=(b.p(a,"data-jssor-click")||"").split(":");var g=b.Dg(hitValues[1]);hitValues[0]=="to"&&qb(g-1);hitValues[0]=="next"&&qb(g,f,e)}}}a.hc=function(a){if(a==f)return s;if(a!=s){s=a;s&&x[u]&&x[u].Gc()}};a.ac=function(){return K};a.Kb=function(){return P};a.bg=function(b){if(b==f)return Ub||K;a.wc(b,b/K*P)};a.wc=function(c,a,d){b.P(t,c);b.Q(t,a);zc=c/K;qc=a/P;b.i(cc,function(a){a.wc(zc,qc,d)});if(!Ub){b.Db(S,w);b.ib(S,0);b.gb(S,0)}Ub=c};a.df=oc;a.ef=mc;a.ye=function(){a.hc(s||1)};function Sc(){Xb.ie&&b.T(w,Xb.ie,([g,"pan-y","pan-x","auto"])[ib]||"");a.g(t,"click",ed,e);a.g(t,"mouseleave",cd);a.g(t,"mouseenter",bd);a.g(t,"mousedown",tc);a.g(t,"touchstart",Tc);a.g(t,"dragstart",yc);a.g(t,"selectstart",yc);a.g(h,"mouseup",fb);a.g(i,"mouseup",fb);a.g(i,"touchend",fb);a.g(i,"touchcancel",fb);a.g(h,"blur",fb);m.Ec&&a.g(i,"keydown",function(c){var a=b.He(c);if(a==37||a==39){s&8&&(s=0);wc(m.Ec*(a-38)*nb,e)}})}function kc(g){xc.ze();E=[];x=[];var h=b.ec(w),k=b.Fe(["DIV","A","LI"]);b.i(h,function(a){var c=a;if(k[a.tagName.toUpperCase()]&&!b.bb(a,"u")&&b.Cb(a)!="none"){var c=Tb(e);b.V(a,gb);b.Db(c,a);b.kb(c,a);b.vc(c,"flat");b.vc(a,"preserve-3d");b.Fb(c);E.push(c)}b.ab(c,(b.ab(c)||0)+1)});q=E.length;if(q){var a=R&1?Gb:Fb;Jc();G=m.xf;if(G==f)G=(a-F+L)/2;hb=a/F;J=c.D(q,m.C||q,c.cb(hb));C=J<q?m.dc:0;if(q*F-L<=a){hb=q-L/F;G=(a-F+L)/2;ac=(a-F*q+L)/2}if(Hb){Mb=Hb.pb;Nb=!G&&J==1&&q>1&&Mb&&(!b.ve()||b.qd()>=9)}if(!(C&1)){bb=G/F;if(bb>q-1){bb=q-1;G=bb*F}N=bb;Q=N+q-hb-L/F}ib=(J>1||G?R:-1)&m.Tc;if(Nb)D=new Mb(Jb,I,H,Hb,Qb,Hc);for(var d=0;d<E.length;d++){var i=E[d],j=new Wc(i,d);x.push(j)}ob=new Xc;z=new Yc;y=new Oc(z,ob);Sc()}b.i(Y,function(a){a.dd(q,x);g&&a.Nc(r.Mc,wc)})}a.F=function(c,h){a.fb=t=b.Ub(c);K=b.P(t);P=b.Q(t);m=b.W({ge:0,Df:1,Ec:1,vd:0,hc:0,dc:1,Pd:e,te:e,ah:1,Md:3e3,Nd:1,Qd:500,Ce:d.Zd,Rd:20,Lf:1,Cd:0,ch:1,Ie:1,Tc:1},h);m.Pd=m.Pd&&b.Hg();if(m.Yb!=f)m.Md=m.Yb;if(m.Jg!=f)m.C=m.Jg;if(m.Sg!=f)m.xf=m.Sg;s=m.hc&63;!m.ch;eb=m.ah;X=m.Nd;X&=Qb?10:5;ic=m.Md;Bb=m.Qd;R=m.Ie&3;sb=b.ug(b.p(t,"dir"))=="rtl";Cb=sb&&(R==1||m.Tc&1);nb=Cb?-1:1;Hb=m.Tf;cb=b.W({pb:p},m.eh);tb=m.wg;Z=m.yg;M=m.lh;var g=b.ec(t);b.i(g,function(a,d){var c=b.bb(a,"u");if(c=="loading")U=a;else{if(c=="slides"){w=a;b.T(w,"margin",0);b.T(w,"padding",0);b.vc(w,"flat")}if(c=="navigator")Vb=a;if(c=="arrowleft")Zb=a;if(c=="arrowright")Yb=a;if(c=="thumbnavigator")Ib=a;if(a.tagName!="STYLE"&&a.tagName!="SCRIPT")cc[c||d]=new Nc(a,c=="slides",b.Fe(["slides","thumbnavigator"])[c])}});U&&b.cc(U);U=U||b.Hc(i);Gb=b.P(w);Fb=b.Q(w);I=m.cf||Gb;H=m.bf||Fb;gb={L:I,I:H,f:0,c:0,Vd:"block",Ob:"absolute"};L=m.Cd;kb=I+L;lb=H+L;F=R&1?kb:lb;Jb=new Lc;b.p(t,Kb,"1");b.ab(w,b.ab(w)||0);b.Ib(w,"absolute");S=b.Gb(w,e);b.T(S,"pointerEvents","none");b.Db(S,w);b.kb(S,Jb.fb);b.uc(w,"hidden");if(Vb&&tb){tb.mc=sb;lc=new tb.pb(Vb,tb,K,P);Y.push(lc)}if(Z&&Zb&&Yb){Z.mc=sb;Z.dc=m.dc;nc=new Z.pb(Zb,Yb,Z,a);Y.push(nc)}if(Ib&&M){M.vd=m.vd;M.Ec=M.Ec||0;M.mc=sb;dc=new M.pb(Ib,M,U);!M.ih&&b.p(Ib,Cc,"1");Y.push(dc)}kc(e);a.wc(K,P);Pb();rb(v(m.vd));b.T(t,"visibility","visible")};a.q=function(){s=0;b.q(x,Y,xc);b.Cc(t)};b.F(a)};j.Af=21;j.Jf=22;j.ig=23;j.Pg=24;j.lg=25;j.yf=26;j.Hf=27;j.of=28;j.Wg=31;j.Zg=32;j.Qg=202;j.bh=203;j.tf=206;j.rf=207;j.qf=208;j.fe=209;jssor_1_slider_init=function(){var f=[{l:800,x:.25,K:1.5,k:{c:d.zd,K:d.Rb},a:2,U:-10,G:{l:800,x:-.25,K:1.5,k:{c:d.zd,K:d.Rb},a:2,U:-10}},{l:1200,x:.5,C:2,rb:{zc:3},k:{c:d.ae},a:2,G:{l:1200,a:2}},{l:600,x:.3,fc:{c:[.6,.4]},k:{c:d.Rb,a:d.n},a:2,G:{l:600,x:-.3,k:{c:d.Rb,a:d.n},a:2}},{l:800,x:.25,y:.5,o:-.1,k:{c:d.H,f:d.H,a:d.n,o:d.H},a:2,G:{l:800,x:-.1,y:-.7,o:.1,k:{c:d.H,f:d.H,a:d.n,o:d.H},a:2}},{l:1e3,x:1,O:2,rb:{Yc:3},k:{c:d.jb,a:d.n},a:2,G:{l:1e3,x:-1,O:2,rb:{Yc:3},k:{c:d.jb,a:d.n},a:2}},{l:1e3,y:-1,C:2,rb:{zc:12},k:{f:d.jb,a:d.n},a:2,G:{l:1e3,y:1,C:2,rb:{zc:12},k:{f:d.jb,a:d.n},a:2}},{l:800,y:1,k:{f:d.jb,a:d.n},a:2,G:{l:800,y:-1,k:{f:d.jb,a:d.n},a:2}},{l:1e3,x:-.1,y:-.7,o:.1,fc:{c:[.6,.4],f:[.6,.4],o:[.6,.4]},k:{c:d.H,f:d.H,a:d.n,o:d.H},a:2,G:{l:1e3,x:.2,y:.5,o:-.1,k:{c:d.H,f:d.H,a:d.n,o:d.H},a:2}},{l:800,x:-.2,nb:40,C:12,fc:{c:[.4,.6]},tc:e,Xc:s.Ad,ud:260,k:{c:d.Wc,a:d.cd},a:2,sf:e,z:{f:.5},G:{l:800,x:.2,nb:40,C:12,Xc:s.Ad,ud:1028,k:{c:d.Wc,a:d.cd},a:2,z:{f:.5},Ab:-200}},{l:700,a:2,G:{l:700,a:2}},{l:800,x:1,k:{c:d.jb,a:d.n},a:2,G:{l:800,x:-1,k:{c:d.jb,a:d.n},a:2}}],g={hc:1,ge:5,Tf:{pb:u,jc:f,gf:1},yg:{pb:v},wg:{pb:t}},c=new j("jssor_1",g),i=600;function a(){var d=c.fb.parentNode,b=d.clientWidth;if(b){var e=m.min(i||b,b);c.bg(e)}else h.setTimeout(a,30)}a();b.xb(h,"load",a);b.xb(h,"resize",a);b.xb(h,"orientationchange",a)}}(window,document,Math,null,true,false)
</script>
<style>
.jssorl-009-spin img{animation-name:jssorl-009-spin;animation-duration:1.6s;animation-iteration-count:infinite;animation-timing-function:linear}@keyframes jssorl-009-spin{from{transform:rotate(0);}to{transform:rotate(360deg);}}.jssorb072 .i{position:absolute;color:#000;font-family:"Helvetica neue",Helvetica,Arial,sans-serif;text-align:center;cursor:pointer;z-index:0}.jssorb072 .i .b{fill:#fff;opacity:.3}.jssorb072 .i:hover{opacity:.7}.jssorb072 .iav{color:#fff}.jssorb072 .iav .b{fill:#000;opacity:.5}.jssorb072 .i.idn{opacity:.3}.jssora073{display:block;position:absolute;cursor:pointer}.jssora073 .a{fill:#ddd;fill-opacity:.7;stroke:#000;stroke-width:160;stroke-miterlimit:10;stroke-opacity:.7}.jssora073:hover{opacity:.8}.jssora073.jssora073dn{opacity:.4}.jssora073.jssora073ds{opacity:.3;pointer-events:none}
</style>

</head>
<body class="animsition">
       <div id="container">
    <div id="people"></div>
   </div>
    <form id="form1" runat="server">
           <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
       <div class="page-wrapper">
        <!-- HEADER MOBILE-->
        <header class="header-mobile d-block d-lg-none">
            <div class="header-mobile__bar">
                <div class="container-fluid">
                    <div class="header-mobile-inner">
                        <a class="logo" href="index.html">
                            <img src="images/icon/logo5.png" alt="CoolAdmin" />
                        </a>
                        <button class="hamburger hamburger--slider" type="button">
                            <span class="hamburger-box">
                                <span class="hamburger-inner"></span>
                            </span>
                        </button>
                    </div>
                </div>
            </div>
            <nav class="navbar-mobile">
                <div class="container-fluid" id="divMobiSidmenu" runat="server">
                    
                </div>
            </nav>
        </header>
        <!-- END HEADER MOBILE-->

        <!-- MENU SIDEBAR-->
        <aside class="menu-sidebar d-none d-lg-block">
            <div class="logo">
                <a href="#">
                    <img src="images/icon/logo5.png" alt="Cool Admin" />
                </a>
            </div>
            <div class="menu-sidebar__content js-scrollbar1">
                <nav class="navbar-sidebar" id="divSideMenu" runat="server">
                 
                </nav>
            </div>
        </aside>
        <!-- END MENU SIDEBAR-->

        <!-- PAGE CONTAINER-->
        <div class="page-container">
            <!-- HEADER DESKTOP-->
             <header class="header-desktop" style="height: 50px;">
                <div class="section__content section__content--p30" style="top:30px">
                    <div class="container-fluid">
                        <div class="header-wrap">
                            <%--<form class="form-header" action="" method="POST">
                                <input class="au-input au-input--xl" type="text" name="search" placeholder="Search for datas &amp; reports..." />
                                <button class="au-btn--submit" type="submit" style="height: 43px;">
                                    <i class="zmdi zmdi-search"></i>
                                </button>
                            </form>--%>
                            <div class="header-button" style="margin-top: 1px;" >
                                <div class="noti-wrap" >
                                
                                    <div class="noti__item js-item-menu" id="divNotification" runat="server">
                                       
                                        </div>
                                    </div>
                                </div>
                                <div class="account-wrap" id="divLogin" runat="server">
                                 
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </header>
            <!-- HEADER DESKTOP-->

            <!-- MAIN CONTENT-->
            <div class="main-content">
        <div class="section__content section__content--p30">
          <div class="container-fluid">
            <div class="row">
              <div class="col-md-12">

                       <div class="card"  id="divThumbs" visible="True" runat="server" >
                  <div class="card-header">
                    <strong class="card-title">BIFPCL Picture Gallery</strong>
                       <a href="Gallery.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>&nbsp; Upload</button></a>
                  </div>

                  <div class="card-body" >
                  
               
                  
                     <%--  <div class="vue-misc" id="div3"  runat="server">--%>
                    
                      <div class="row" id="divThumbnails" runat="server">
                        
                               <%--<div id="div4" runat="server"/>--%>
                             <%-- <div class="col-sm-3">
                         <div class="card">
                                    <img class="card-img-top" src="images/bg-title-01.jpg" alt="Card image cap">
                                    <div class="card-body">
                                        <h4 class="card-title mb-3">Card Image Title</h4>
                                        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's
                                            content.
                                        </p>
                                    </div>
                                </div>
                             </div>--%>

                 
                      </div>
                   <%-- </div>--%>
                    <%--  </div>--%>
                    </div>
                           </div>
                <div class="card"  id="divPics" visible="True" runat="server" >
                  <div class="card-header">
                    <strong class="card-title">BIFPCL Picture Gallery</strong>
                       <a href="Galleryshow.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>&nbsp; Back</button></a>
                  </div>

                  <div class="card-body" >
                  
               
                  
                       <div class="vue-misc" id="div1"  runat="server">
                    
                      <div class="row">
                         <div class=" col-md-auto">
                               <div id="divHead" runat="server"/>
<div id="jssor_1" style="position:relative;margin:0 auto;top:0px;left:0px;width:600px;height:500px;overflow:hidden;visibility:hidden;">
<!-- Loading Screen -->
<div data-u="loading" class="jssorl-009-spin" style="position:absolute;top:0px;left:0px;width:100%;height:100%;text-align:center;background-color:rgba(0,0,0,0.7);">
<img style="margin-top:-19px;position:relative;top:50%;width:38px;height:38px;" src="images/spin.svg" />
</div>
<div data-u="slides" id="divSlides" runat="server" style="cursor:default;position:relative;top:0px;left:0px;width:600px;height:500px;overflow:hidden;">
<%--<div>
<img data-u="image" src="upload/various/pics/BIFPCL201018025451.jpeg" />
</div>
<div>
<img data-u="image" src="upload/various/pics/BIFPCL201018025525.jpeg" />
</div>
<div>
<img data-u="image" src="upload/various/pics/BIFPCL201018025551.jpeg" />
</div>
<div>
<img data-u="image" src="upload/various/pics/BIFPCL201018025713.jpeg" />
</div>--%>

</div>
<!-- Bullet Navigator -->
<div data-u="navigator" class="jssorb072" style="position:absolute;bottom:12px;right:12px;" data-autocenter="1" data-scale="0.5" data-scale-bottom="0.75">
<div data-u="prototype" class="i" style="width:24px;height:24px;font-size:12px;line-height:24px;">
<svg viewbox="0 0 16000 16000" style="position:absolute;top:0;left:0;width:100%;height:100%;z-index:-1;">
<circle class="b" cx="8000" cy="8000" r="6666.7"></circle>
</svg>
<div data-u="numbertemplate" class="n"></div>
</div>
</div>
<!-- Arrow Navigator -->
<div data-u="arrowleft" class="jssora073" style="width:40px;height:50px;top:0px;left:30px;" data-autocenter="2" data-scale="0.75" data-scale-left="0.75">
<svg viewbox="0 0 16000 16000" style="position:absolute;top:0;left:0;width:100%;height:100%;">
<path class="a" d="M4037.7,8357.3l5891.8,5891.8c100.6,100.6,219.7,150.9,357.3,150.9s256.7-50.3,357.3-150.9 l1318.1-1318.1c100.6-100.6,150.9-219.7,150.9-357.3c0-137.6-50.3-256.7-150.9-357.3L7745.9,8000l4216.4-4216.4 c100.6-100.6,150.9-219.7,150.9-357.3c0-137.6-50.3-256.7-150.9-357.3l-1318.1-1318.1c-100.6-100.6-219.7-150.9-357.3-150.9 s-256.7,50.3-357.3,150.9L4037.7,7642.7c-100.6,100.6-150.9,219.7-150.9,357.3C3886.8,8137.6,3937.1,8256.7,4037.7,8357.3 L4037.7,8357.3z"></path>
</svg>
</div>
<div data-u="arrowright" class="jssora073" style="width:40px;height:50px;top:0px;right:30px;" data-autocenter="2" data-scale="0.75" data-scale-right="0.75">
<svg viewbox="0 0 16000 16000" style="position:absolute;top:0;left:0;width:100%;height:100%;">
<path class="a" d="M11962.3,8357.3l-5891.8,5891.8c-100.6,100.6-219.7,150.9-357.3,150.9s-256.7-50.3-357.3-150.9 L4037.7,12931c-100.6-100.6-150.9-219.7-150.9-357.3c0-137.6,50.3-256.7,150.9-357.3L8254.1,8000L4037.7,3783.6 c-100.6-100.6-150.9-219.7-150.9-357.3c0-137.6,50.3-256.7,150.9-357.3l1318.1-1318.1c100.6-100.6,219.7-150.9,357.3-150.9 s256.7,50.3,357.3,150.9l5891.8,5891.8c100.6,100.6,150.9,219.7,150.9,357.3C12113.2,8137.6,12062.9,8256.7,11962.3,8357.3 L11962.3,8357.3z"></path>
</svg>
</div>
</div>
<script type="text/javascript">jssor_1_slider_init();</script>
<!-- #endregion Jssor Slider End -->

                    </div>
                      </div>
                    </div>
                      </div>
                    </div>

                 
                   <div id="divMsg" runat="server" />
               
                   
              </div>
            </div>
          </div>
        </div>

      </div>
            <!-- END MAIN CONTENT-->
            <!-- END PAGE CONTAINER-->
        </div>

    </div>
    </form>

    
    
    <!-- Bootstrap JS-->
    <script src="vendor/bootstrap-4.1/popper.min.js"></script>
    <script src="vendor/bootstrap-4.1/bootstrap.min.js"></script>
    <!-- Vendor JS       -->
    <script src="vendor/slick/slick.min.js">
    </script>
    <script src="vendor/wow/wow.min.js"></script>
    <script src="vendor/animsition/animsition.min.js"></script>
    <script src="vendor/bootstrap-progressbar/bootstrap-progressbar.min.js">
    </script>
    <script src="vendor/counter-up/jquery.waypoints.min.js"></script>
    <script src="vendor/counter-up/jquery.counterup.min.js">
    </script>
    <script src="vendor/circle-progress/circle-progress.min.js"></script>
    <script src="vendor/perfect-scrollbar/perfect-scrollbar.js"></script>
    <script src="vendor/chartjs/Chart.bundle.min.js"></script>
    <script src="vendor/select2/select2.min.js">
    </script>
 
    <!-- Main JS-->
    <script src="js/main.js"></script>
   
     
  

   
   
</body>
</html>
