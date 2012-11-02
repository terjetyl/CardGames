<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BlackJackOnline._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <!--[if IE 6]>
    <link href="/css/ie6.css" rel="stylesheet" type="text/css" />
    <![endif]-->
    <script src="/javascript/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="/javascript/blackjack.js" type="text/javascript"></script>
    
</head>
<body>
<form id="form1" runat="server">
<div id="outerDiv">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="~/BlackjackWebService.asmx" />
        </Services>
    </asp:ScriptManager>
    
    <div id="header" >
    
        <h1><span>Simple</span> Blackjack</h1>
        
    </div>
    
<%--    <div>
    
        <input id="Button2" type="button" value="button" onclick="doHelloWorld()" />
        <br />
        <asp:TextBox ID="txtHello" runat="server"></asp:TextBox>
    
    </div>
--%>    
    <div id="dealerHand" class="hand" >
        <ul id="dealerHandList"></ul>
        <span class="total"></span>
        <div class="scores">
            Wins: <span class="score">0</span><br />
            <span class="outcome"></span>
        </div>
    </div> <!-- dealerHand -->
    
    <div id="table" class="clear" > DEALER STANDS ON 17 </div>
    
    <div id="playerHand" class="hand" >
        <ul id="playerHandList"></ul>
        <span class="total"></span>
        <div class="scores">
            Wins: <span class="score">0</span><br />
            <span class="outcome"></span>
        </div>
    </div> <!-- playerHand -->
    
    <div class="clear"> </div>
    
    <div id="controls">
        <input id="btnDeal" type="button" value="Deal" onclick="deal()" disabled="disabled" />
        <input id="btnHit" type="button" value="Hit" onclick="hit()" disabled="disabled" />
        <input id="btnStand" type="button" value="Stand" onclick="stand()" disabled="disabled" />
<%--
        <input id="btnChangeText" type="button" value="Change Text" onclick="changeText()" />
        <input id="btnDelayTest" type="button" value="Delay Test" onclick="delayTest()" />
        <input id="btnTestDeal" type="button" value="Test Deal" onclick="testDeal()" />
        <span id="testSpan"></span>
--%>
    </div>
   
</div> <!-- outerdiv -->
</form>    
</body>
</html>
