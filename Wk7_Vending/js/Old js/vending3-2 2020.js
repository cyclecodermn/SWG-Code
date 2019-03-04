
$(document).ready(function() {

  $('#TotalDeposit').append('<center>xperi2</center>');  
  //ClearCells();
  GetItems();
  newAmount=0.0;
  UpdateTotal(newAmount);

  $('#AddDlrBtn').on('click',AddDollar);
  $('#AddQuarBtn').on('click',AddQuarter);
  $('#AddDimeBtn').on('click',AddDime);
  $('#AddNickBtn').on('click',AddNickel);

  $('#ChangeRtrnBtn').on('click',ChangeRtrn);
  $('#MkPurchaseBtn').on('click',MkPurchase);
  

  $('#Cell1').on('click',ActCell1);
  $('#Cell2').on('click',ActCell2);

 });
 
function ChangeRtrn()
{
  var amount='$'+GetCellValue("DepRow").toFixed(2);
  $('#ChangeBox').text('').append(amount);
  
  amount=0;
  var zeroTotal='$'+amount.toFixed(2);
  $('#TotalDeposit').text('').append(zeroTotal);
}

function AddDollar()
{
  AddMoney(1);
}
function AddQuarter()
{
  AddMoney(0.25);
}

function AddDime()
{
  AddMoney(0.10);
}
function AddNickel()
{
  AddMoney(0.05);
}
 function AddMoney(addAmount)
 {
//    var myVar = GetCellValue("DepRow");
//  // alert(myVar);

//   var Row = document.getElementById("DepRow");
//   var Cells = Row.getElementsByTagName("td");
//   var strTotal=Cells[0].innerText;
//   var decTotal=strTotal.substr(1,strTotal.length-1).valueOf()*1;
//   var newTotal=decTotal+(addAmount.valueOf()*1);

  var newTotal=GetCellValue("DepRow");
  var newTotal=newTotal+(addAmount.valueOf()*1);
  
  //$('#TotalDepost').text('').append(newTotal);
  UpdateTotal(newTotal);


 // alert(newTotal*8);
  //var crntVal = $('#TotalDeposit').val();
  //var crntVal = document.getElementById('#TotalDeposit').
  // alert('Reached AddMoney'+crntVal);

 }

function UpdateTotal(amount)
{
  newTotal='$'+amount.toFixed(2);
   //newTotal='$';
   //alert('Reached InitTotal function');
  $('#TotalDeposit').text('').append(newTotal);
}
/////////////////////////////////////////////
////////// Helper Functions ////////////////

 function GetItems()
 {
   var getItemsURL= 'http://localhost:8080/items';
   //alert('Reached success function');
   //$('#change').text('Wind Speed: ')   
   $.ajax({
     type: 'GET',
     url: getItemsURL,
     
     success: function (data,status) 
     {
      for (i=0;i<=9;i++)
      {
      var cellNum='#Cell'+i;

      cellInfo=data[i].name+"<br />";
      cellInfo+="$"+data[i].price+"<br />"+"<br />";
      cellInfo+="Qunatity Left: "+data[i].quantity+"<br />";
      
      cellInfo='<center>'+cellInfo;
      cellInfo+="<center />"
      cellID=i+1;
      cellInfo=cellID+cellInfo+"<br />";
      $(cellNum).text('').append(cellInfo)+'<p>';

    }   
    },
 
 
   });
 
 }

function ClearCells()
{
  for (i=1;i<=9;i++)
  {
    crntCell='#Cell'+i;
    newStuff='Cell'+i;
    $(crntCell).text('').append(newStuff);
  }
}
 
 function ActCell1(event)
 {
  // alert('Cell01');
  $('#Cell1').text('').append('<center>xperi2</center>');
 }

 function ActCell2(event)
 {
  // alert('Cell02');
  $('#Cell2').append('<center>xperi2</center>');
}

function GetCellValue(rowName)
{
  var Row = document.getElementById(rowName);
  var Cells = Row.getElementsByTagName("td");
  var strTotal=Cells[0].innerText;
  var decTotal=strTotal.substr(1,strTotal.length-1).valueOf()*1;
  //var newTotal1=decTotal1+(addAmount.valueOf()*1);
  return decTotal;
}


