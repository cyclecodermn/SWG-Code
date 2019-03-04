
$(document).ready(function() {

  $('#TotalDeposit').append('<center>xperi2</center>');  
  //ClearCells();
  GetItems();
  newAmount=0.0;
  UpdateTotal(newAmount);

  $('#Cell1').on('click',ActCell1);
  $('#Cell2').on('click',ActCell2);

  $('#AddDlrBtn').on('click',AddDollar);
  $('#AddQuarBtn').on('click',AddQuarter);
  $('#AddDimeBtn').on('click',AddDime);
  $('#AddNickBtn').on('click',AddNickel);

  $('#ChangeRtrnBtn').on('click',ChangeRtrn);
  $('#MkPurchaseBtn').on('click',MkPurchase);
  
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
  //alert('Reached AddDollar');
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
  //var myVar=document.getElementById("vendingTable").rows[1];
  //alert(myVar);
  // alert(document.getElementById("vendingTable").rows[1].cells.namedItem("TotalDeposit").innerHTML);
  AddMoney(0.05);
}
 function AddMoney(addAmount)
 {
  var newTotal=GetCellValue("DepRow");
  
  var newTotal=newTotal+(addAmount.valueOf()*1);
  UpdateTotal(newTotal);
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
      var cellNum='#Cell'+i+'Name';

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
    crntCell='#Cell'+i+'Name';
    newStuff='Cell'+i;
    $(crntCell).text('').append(newStuff);
  }
}
 
 function ActCell1()
 {
   //alert('Cell01');
  $('#Cell1').text('').append('<center>xperi2</center>');
 }

 function ActCell2()
 {
  // alert('Cell02');
  $('#Cell2').append('<center>xperi2</center>');
}

function GetCellValue(rowName)
{
//   var Row = document.getElementById(rowName);
//   var Cells = Row.getElementsByTagName("#TotalDeposit");
//   var Cells = Row.amount.cellID("#TotalDeposit");
// alert(Cells);

var strTotal=document.getElementById("TotalDeposit").innerHTML;

//  var strTotal=document.getElementById("vendingTable").rows[1].cells.namedItem("TotalDeposit").innerHTML;
  var decTotal=strTotal.substr(1,strTotal.length-1).valueOf()*1;
  //var newTotal1=decTotal1+(addAmount.valueOf()*1);
  return decTotal;
}


